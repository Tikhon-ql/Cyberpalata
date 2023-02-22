using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.QrCode
{
    public class TeamRegistrationQrCodeModel
    {
        public string Url { get; set; }
        public Guid TeamId { get; set; }
        public Guid TournamentId { get; set; }
    }
}
