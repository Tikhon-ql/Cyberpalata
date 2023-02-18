﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Tournaments
{
    public class Tournament : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int TeamsMaxCount { get; set; }
        //public int RoundsMaxCount { get;set; }
        public virtual Team? Winner { get; set; }
        public virtual List<Team>? Teams { get; set; }
        public virtual List<Prize>? Prizes { get; set; }
        public virtual List<Round>? Rounds { get; set; }
    }
}