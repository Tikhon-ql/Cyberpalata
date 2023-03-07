using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Filters
{
    public class MessageFilter : BaseFilter<Message>
    {
        public Maybe<Guid> UserId { get;set; }
    }
}
