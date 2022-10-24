using ClimaTempo.Models;
using Microsoft.EntityFrameworkCore;

namespace ClimaTempo.Data
{
    public class PrevisaoClimaRepo : IPrevisaoClimaRepo
    {
        private AppDbContext _appDbContext;

        public PrevisaoClimaRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;           
        }

        public async Task<IEnumerable<PrevisaoClima>> ObtemPrevisaoSemanalCidade(int id)
        {
            return await _appDbContext.PrevisaoClima
                .AsNoTracking()
                .Include(i => i.Cidade!.Estado)
                .Where(i => i.CidadeId == id && i.DataPrevisao >= Hoje && i.DataPrevisao < Hoje.AddDays(7))
                .ToArrayAsync();
        }
        
        public async Task<IEnumerable<PrevisaoClima>> ObtemPrevisaoCidadesMaisFrias(int top)
        {
            return await ObtemPrevisaCidadeTemperaturaMaximaQuery()
                .Reverse()
                .Take(top)
                .Reverse()
                .ToArrayAsync();
        }

        public async Task<IEnumerable<PrevisaoClima>> ObtemPrevisaoCidadesMaisQuentes(int top)
        {
            return await ObtemPrevisaCidadeTemperaturaMaximaQuery()
                .Take(top)
                .ToArrayAsync();
        }

        private DateTime Hoje => DateTime.Today;

        private IQueryable<PrevisaoClima> ObtemPrevisaCidadeTemperaturaMaximaQuery()
        {
            return _appDbContext.PrevisaoClima
                .AsNoTracking()
                .Include(i => i.Cidade!.Estado)
                .Where(i => i.DataPrevisao == Hoje)
                .OrderByDescending(i => i.TemperaturaMaxima)
                .ThenBy(i => i.Cidade!.Nome)
                .ThenBy(i => i.Cidade!.Estado!.Nome);
        }
    }
}