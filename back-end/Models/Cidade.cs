using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimaTempo.Models
{
    public class Cidade
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Estado")]
        public int EstadoId { get; set; }

        [Required]
        [MaxLength(30)]
        public string? Nome { get; set; }

        public Estado? Estado { get; set; }

        public ICollection<PrevisaoClima>? Previsoes { get; set; }
    }
}