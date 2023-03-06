using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Logic.Models.Identity;

namespace Cyberpalata.Logic.Models
{
    public class ChatDto
    {
        public Guid Id { get; set; }
        public UserDto UserToJoin { get; set; } = new(); 
        public UserDto Captain { get; set; } = new();
        public bool IsDeleted { get; set; }
        public List<MessageDto> Messages { get; set; } = new();
    }
}
