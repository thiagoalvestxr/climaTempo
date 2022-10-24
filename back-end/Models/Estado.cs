using System.ComponentModel.DataAnnotations;

namespace ClimaTempo.Models
{
    public class Estado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(2)]
        public string? UF { get; set; }

        public ICollection<Cidade>? Cidades { get; set; }
    }
}