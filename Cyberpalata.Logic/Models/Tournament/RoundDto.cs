﻿using Cyberpalata.DataProvider.Models.Tournaments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Tournament
{
    public class RoundDto
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public List<BatleDto> Batles { get; set; }
    }
}
