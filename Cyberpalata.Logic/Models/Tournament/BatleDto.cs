﻿namespace Cyberpalata.Logic.Models.Tournament
{
    public class BatleDto
    {
        public DateTime Date { get; set; }
        public TeamDto? FirstTeam { get; set; }
        public TeamDto? SecondTeam { get; set; }
        public bool IsFirstTeamApproved { get; set; }
        public bool IsSecondTeamApproved { get; set; }
        public int RoundNumber { get; set; }
    }
}
