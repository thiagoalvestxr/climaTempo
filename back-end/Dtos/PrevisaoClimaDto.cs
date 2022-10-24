namespace ClimaTempo.Dtos
{
    public class PrevisaoClimaDto
    {
        public string? UF { get; set; }

        public string? Cidade { get; set; }

        public string? Clima { get; set; }

        public string? DiaSemana { get; set; }

        public string? DataPrevisao { get; set; }

        public double TemperaturaMinima { get; set; }

        public double TemperaturaMaxima { get; set; }
    }
}