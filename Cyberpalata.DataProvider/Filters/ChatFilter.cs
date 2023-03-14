using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Filters
{
    public class ChatFilter : BaseFilter<Chat>
    {
        public Maybe<Guid> UserId { get;set; }
        public override IQueryable<Chat> EnrichQuery(IQueryable<Chat> query)
        {
            query = query.Where(q => !q.IsDeleted);
            if (UserId.HasValue)
                query = query.Where(q => q.Captain.Id == UserId.Value || q.UserToJoin.Id == UserId.Value);
            return query;
        }
    }
}
