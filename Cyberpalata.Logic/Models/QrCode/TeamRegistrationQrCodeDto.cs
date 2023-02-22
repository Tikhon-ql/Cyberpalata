using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Models.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.QrCode
{
    public class TeamRegistrationQrCodeDto
    {
        public byte[] BitmapBytes { get; set; }
        public DateTime Date { get; set; }
        public TeamDto Team { get; set; }
        public TournamentDto Tournament { get; set; }
    }
}
