using MediatR;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using teste.clima.models.ViewModel;

namespace teste.clima.services.Cidade
{
    public class SelecionarCidadePrevisaoQuery : IRequest<CidadePrevisaoVM>
    {
        [Required(ErrorMessage = "Digite o nome da cidade")]
        public string NomeCidade { get; set; } = string.Empty;
    }
}
