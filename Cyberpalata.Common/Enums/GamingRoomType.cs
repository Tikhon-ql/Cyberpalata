using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Common.Enums
{
    public class GamingRoomType : Enumeration
    {
        //TODO: delete it
        public static GamingRoomType Vip = new(1, nameof(Vip));
        public static GamingRoomType Common = new(2, nameof(Common));
        public GamingRoomType(int id, string name) : base(id, name)
        {
        }
    }
}
