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

        public JoinRequestState(int id, string name) : base(id, name)
        {
        }

        public static JoinRequestState Parse(string name)
        {
            if(name == "InProgress")
                return InProgress;
            if(name == "Accepted")
                return Accepted;
            if(name == "Rejected")
                return Rejected;
            return new JoinRequestState(-1, name);
        }
    }
}
