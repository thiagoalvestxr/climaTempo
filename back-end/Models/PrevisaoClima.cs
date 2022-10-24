using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimaTempo.Models
{
    public class PrevisaoClima
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Cidade")]
        public int CidadeId { get; set; }

        public DateTime DataPrevisao { get; set; }

        [Required]
        [MaxLength(15)]
        public string? Clima { get; set; }

        [Column(TypeName = "numeric(3, 1)")]
        public double? TemperaturaMinima { get; set; }

        [Column(TypeName = "numeric(3, 1)")]
        public double? TemperaturaMaxima { get; set; }

        public Cidade? Cidade { get; set; }
    }
}