using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Common.Enums
{
    public class JoinRequestState : Enumeration
    {
        public static JoinRequestState InProgress = new(1, "InProgress");
        public static JoinRequestState Accepted = new(2, "Accepted");
        public static JoinRequestState Rejected = new(3, "Rejected");
        public static JoinRequestState None = new(4, "None");

        public JoinRequestState(int id, string name) : base(id, name)
        {
        }
    }
}
