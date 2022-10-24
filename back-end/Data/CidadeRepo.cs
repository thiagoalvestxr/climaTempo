using ClimaTempo.Models;
using Microsoft.EntityFrameworkCore;

namespace ClimaTempo.Data
{
    public class CidadeRepo : ICidadeRepo
    {
        private AppDbContext _appDbContext;

        public CidadeRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;           
        }

        public async Task<IEnumerable<Cidade>> ObtemCidades()
        {
            return await _appDbContext.Cidade
                .AsNoTracking()
                .Include(i => i.Estado)
                .OrderBy(i => i.Nome)
                .ThenBy(i => i.Estado!.Nome)
                .ToArrayAsync();
        }
    }
}