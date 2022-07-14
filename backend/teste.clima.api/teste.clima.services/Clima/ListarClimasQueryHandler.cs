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

namespace teste.clima.services.Clima
{
    public class ListarClimasQueryHandler : IRequestHandler<ListarClimasQuery, ClimaCidadeVM>
    {
        IConfiguration configuration;
        public ListarClimasQueryHandler(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<ClimaCidadeVM> Handle(ListarClimasQuery request, CancellationToken cancellationToken)
        {
            models.ViewModel.ClimaCidadeVM model = new ClimaCidadeVM();
            IClimaCidadesRepo repo = new ClimaCidadeRepo(configuration.GetConnectionString("ConexaoDb"));
            model.CidadesQuentes = await repo.ListarMaximas(DateTime.Now);
            model.CidadesFrias = await repo.ListarMinimas(DateTime.Now);
            return model;
        }
    }
}
