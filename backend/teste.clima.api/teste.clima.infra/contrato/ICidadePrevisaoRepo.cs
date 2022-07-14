using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste.clima.infra.contrato
{
    public interface ICidadePrevisaoRepo
    {
        public Task<models.ViewModel.CidadePrevisaoVM> ListarAsync(string cidade);


    }
}
