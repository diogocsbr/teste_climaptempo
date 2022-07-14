using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using teste.clima.models.ViewModel;

namespace teste.clima.infra.contrato
{
    public interface IClimaCidadesRepo
    {
        public Task<List<ClimaCidadeItemVM>> ListarMaximas(DateTime data);
        public Task<List<ClimaCidadeItemVM>> ListarMinimas(DateTime data);
    }
}
