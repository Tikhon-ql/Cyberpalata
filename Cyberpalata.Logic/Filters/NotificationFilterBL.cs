using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Filters
{
    public class NotificationFilterBL : BaseFilterBL
    {
        public Maybe<bool> IsActual { get;set; }
        public Maybe<Guid> UserId { get; set; }
        public Maybe<bool> IsChecked { get; set; }
    }
}
