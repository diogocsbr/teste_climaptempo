using MediatR;

using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using teste.clima.infra.contrato;
using teste.clima.infra.repo;
using teste.clima.models.ViewModel;

namespace teste.clima.services.Cidade
{
    public class SelecionarCidadePrevisaoQueryHandler : IRequestHandler<SelecionarCidadePrevisaoQuery, CidadePrevisaoVM>
    {
        IConfiguration _config;
        public SelecionarCidadePrevisaoQueryHandler(IConfiguration config)
        {
            _config = config;
        }

        public async Task<CidadePrevisaoVM> Handle(SelecionarCidadePrevisaoQuery request, CancellationToken cancellationToken)
        {
            ICidadePrevisaoRepo repo = new CidadePrevisaoRepo(_config.GetConnectionString("ConexaoDb"));
            return await repo.ListarAsync(request.NomeCidade);
        }
    }
}
