using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using teste.clima.infra.contrato;
using teste.clima.models.ViewModel;

namespace teste.clima.infra.repo
{
    public  class CidadePrevisaoRepo : ICidadePrevisaoRepo
    {
        System.Globalization.CultureInfo cuInfo;
        String ConnectionString;

        public CidadePrevisaoRepo(string _config)
        {
            ConnectionString = _config;
            cuInfo = new System.Globalization.CultureInfo("pt-BR");
        }

        public async Task<CidadePrevisaoVM> ListarAsync(string cidade)
        {
            CidadePrevisaoVM model = new CidadePrevisaoVM();

            using (var ctx = new models.Models.ClimaTempoSimplesContext(ConnectionString))
            {
                var resp = await ctx.PrevisaoClimas.Include("Cidade.Estado")
                    .Where(p => p.Cidade.Nome.Contains(cidade) && p.DataPrevisao >= DateTime.Now.Date)
                    .OrderBy(p => p.DataPrevisao)
                    .Take(7)
                    .Select(o => new CidadePrevisaoItemVM()
                    {
                        Data = o.DataPrevisao,
                        DiaSemana = cuInfo.DateTimeFormat.GetDayName(o.DataPrevisao.DayOfWeek),
                        Maxima = o.TemperaturaMaxima.HasValue ? o.TemperaturaMaxima.Value : 0,
                        Minima = o.TemperaturaMinima.HasValue ? o.TemperaturaMinima.Value : 0,
                        Tempo = o.Clima
                    })
                    .ToListAsync();

                model.CidadePrevisaoItems = resp;
            }

            return model;
        }
    }
}
