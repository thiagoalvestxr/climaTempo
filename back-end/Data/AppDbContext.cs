using ClimaTempo.Models;
using Microsoft.EntityFrameworkCore;

namespace ClimaTempo.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Cidade> Cidade => Set<Cidade>();

        public DbSet<PrevisaoClima> PrevisaoClima => Set<PrevisaoClima>();
    }
}