﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste.clima.models.ViewModel
{
    public class ClimaCidadeVM
    {
        public List<ClimaCidadeItemVM> ? CidadesQuentes { get; set; }
        public List<ClimaCidadeItemVM> ? CidadesFrias { get; set; }
    }
}
