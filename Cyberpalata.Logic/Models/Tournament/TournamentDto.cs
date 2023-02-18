﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Tournament
{
    public class TournamentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int TeamsMaxCount { get; set; }
        public TeamDto Winner { get; set; }
        public List<PrizeDto> Prizes { get; set; }
        public List<TeamDto> Teams { get; set; }
        public List<RoundDto> Rounds { get; set; }
    }
}