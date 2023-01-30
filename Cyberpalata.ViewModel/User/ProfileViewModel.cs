using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.User
{
    public class ProfileViewModel
    {
        public UserViewModel User { get; set; } = new();
        public List<UserBookingViewModel> Bookings { get; set; } = new();
    }
}
