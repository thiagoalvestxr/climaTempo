using ClimaTempo.Models;

namespace ClimaTempo.Data
{
    public interface IPrevisaoClimaRepo
    {
        Task<IEnumerable<PrevisaoClima>> ObtemPrevisaoSemanalCidade(int id);

        Task<IEnumerable<PrevisaoClima>> ObtemPrevisaoCidadesMaisFrias(int top);

        Task<IEnumerable<PrevisaoClima>> ObtemPrevisaoCidadesMaisQuentes(int top);
    }
}