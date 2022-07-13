using System;
using System.Collections.Generic;

namespace teste.clima.models.Models
{
    public partial class PrevisaoClima
    {
        public int Id { get; set; }
        public int CidadeId { get; set; }
        public DateTime DataPrevisao { get; set; }
        public string Clima { get; set; }
        public decimal? TemperaturaMinima { get; set; }
        public decimal? TemperaturaMaxima { get; set; }

        public virtual Cidade Cidade { get; set; }
    }
}
