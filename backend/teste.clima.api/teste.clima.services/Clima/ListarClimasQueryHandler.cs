using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using teste.clima.models.ViewModel;

namespace teste.clima.services.Clima
{
    public class ListarClimasQueryHandler : IRequestHandler<ListarClimasQuery, ClimaCidadeVM>
    {
        public Task<ClimaCidadeVM> Handle(ListarClimasQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
