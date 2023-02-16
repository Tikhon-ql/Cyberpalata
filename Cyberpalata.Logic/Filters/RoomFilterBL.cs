using CSharpFunctionalExtensions;
using Cyberpalata.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Filters
{
    public class RoomFilterBL : BaseFilterBL
    {
        public Maybe<RoomType> Type { get; set; }
        public Maybe<bool> IsVip { get; set; }
    }
}
