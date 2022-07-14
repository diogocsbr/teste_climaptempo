using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using teste.clima.models.ViewModel;

namespace teste.clima.services.Cidade
{
    public class SelecionarCidadePrevisaoQueryHandler : IRequestHandler<SelecionarCidadePrevisaoQuery, CidadePrevisaoVM>
    {
        public Task<CidadePrevisaoVM> Handle(SelecionarCidadePrevisaoQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
