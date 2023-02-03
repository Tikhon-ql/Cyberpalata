using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.User
{
    public class ProfileViewModel
    {
        public string Username { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int BookingsCount { get; set; }
        public List<Guid> BookingsIds { get; set; }
    }
}
