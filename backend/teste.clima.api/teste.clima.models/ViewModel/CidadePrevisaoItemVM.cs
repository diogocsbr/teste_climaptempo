using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste.clima.models.ViewModel
{
    public class CidadePrevisaoItemVM
    {
        public DateTime Data { get;set; }
        public string DataStr { get { return this.Data.ToString("dd/MM/yyyy");  } }
        public string DiaSemana { get; set; } = string.Empty;
        public string Tempo { get; set; } = string.Empty;
        public decimal Minima { get; set; }
        public decimal Maxima { get; set; }
    }
}
