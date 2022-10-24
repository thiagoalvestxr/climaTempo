using AutoMapper;
using ClimaTempo.Data;
using ClimaTempo.Dtos;
using ClimaTempo.Middlewares;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => 
{
    options.AddPolicy("CORSPolicy", builder => 
    {
        builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000");
    });    
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

var sqlConBuilder = new SqlConnectionStringBuilder();
sqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("SQLDbConnection");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(sqlConBuilder.ConnectionString));

builder.Services.AddScoped<ICidadeRepo, CidadeRepo>();
builder.Services.AddScoped<IPrevisaoClimaRepo, PrevisaoClimaRepo>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseCors("CORSPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();


app.MapGet("api/v1/cidades", async(ICidadeRepo repo, IMapper mapper) => {
    var cidades = await repo.ObtemCidades();
    return Results.Ok(mapper.Map<IEnumerable<CidadeDto>>(cidades));
});

app.MapGet("api/v1/cidades/{id}", async(IPrevisaoClimaRepo repo, IMapper mapper, int id) => {
    var previsoes = await repo.ObtemPrevisaoSemanalCidade(id);
    if (previsoes != null)
    {
        return Results.Ok(mapper.Map<IEnumerable<PrevisaoClimaDto>>(previsoes));
    }
    return Results.NotFound();
});

app.MapGet("api/v1/previsoes/frias", async(IPrevisaoClimaRepo repo, IMapper mapper, int top) => {
    var previsoes = await repo.ObtemPrevisaoCidadesMaisFrias(top);
    return Results.Ok(mapper.Map<IEnumerable<PrevisaoClimaDto>>(previsoes));
});

app.MapGet("api/v1/previsoes/quentes", async(IPrevisaoClimaRepo repo, IMapper mapper, int top) => {
    var previsoes = await repo.ObtemPrevisaoCidadesMaisQuentes(top);
    return Results.Ok(mapper.Map<IEnumerable<PrevisaoClimaDto>>(previsoes));
});

app.Run();