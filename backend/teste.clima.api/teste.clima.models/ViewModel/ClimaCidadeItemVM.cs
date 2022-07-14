using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste.clima.models.ViewModel
{
    public class ClimaCidadeItemVM
    {
        public int Id { get; set; }
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public decimal ? Temperatura { get; set; }
    }
}
