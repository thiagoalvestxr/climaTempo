using ClimaTempo.Models;

namespace ClimaTempo.Data
{
    public interface ICidadeRepo
    {
        Task<IEnumerable<Cidade>> ObtemCidades();
    }
}