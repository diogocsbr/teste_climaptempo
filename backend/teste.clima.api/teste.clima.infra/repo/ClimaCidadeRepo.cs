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
    public class ClimaCidadeRepo : IClimaCidadesRepo
    {
        String ConnectionString { get; }
        public ClimaCidadeRepo(string _config)
        {
            ConnectionString = _config;
        }

        public async Task<List<ClimaCidadeItemVM>> ListarMaximas(DateTime data)
        {
            List<ClimaCidadeItemVM> model = new List<ClimaCidadeItemVM>();

            using (var ctx = new models.Models.ClimaTempoSimplesContext(ConnectionString))
            {
                model = await ctx.PrevisaoClimas.Include("Cidade.Estado")
                    .Where(p => p.DataPrevisao.Date == data.Date)
                    .OrderByDescending(p => p.TemperaturaMaxima)
                    .ThenBy(p => p.Cidade.Nome)
                    .ThenBy(p => p.Cidade.Estado.Uf)
                    .Take(3)
                    .Select(o => new ClimaCidadeItemVM()
                    {
                        Cidade = o.Cidade.Nome,
                        Estado = o.Cidade.Estado.Nome,
                        Temperatura = o.TemperaturaMaxima
                    })
                    .ToListAsync();

            }

            return model;
        }

        public async Task<List<ClimaCidadeItemVM>> ListarMinimas(DateTime data)
        {
            List<ClimaCidadeItemVM> model = new List<ClimaCidadeItemVM>();

            using (var ctx = new models.Models.ClimaTempoSimplesContext(ConnectionString))
            {
                model = await ctx.PrevisaoClimas.Include("Cidade.Estado")
                    .Where(p => p.DataPrevisao.Date == data.Date)
                    .OrderBy(p => p.TemperaturaMinima)
                    .ThenBy(p => p.Cidade.Nome)
                    .ThenBy(p => p.Cidade.Estado.Uf)
                    .Take(3)
                    .Select(o => new ClimaCidadeItemVM()
                    {
                        Cidade = o.Cidade.Nome,
                        Estado = o.Cidade.Estado.Nome,
                        Temperatura = o.TemperaturaMinima
                    })
                    .ToListAsync();
            }

            return model;
        }

    }
}
