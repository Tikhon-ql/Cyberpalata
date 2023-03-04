using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Filters
{
    public class NotificationFilter : BaseFilter<Notification>
    {
        public Maybe<bool> IsActual { get; set; }
        public Maybe<Guid> UserId { get; set; }
        public Maybe<bool> IsChecked { get; set; }
        public override IQueryable<Notification> EnrichQuery(IQueryable<Notification> query)
        {
            if(IsActual.HasValue)
            {
                if(IsActual.Value)
                    query = query.Where(q=>q.Date > DateTime.UtcNow);
                else
                    query = query.Where(q=>q.Date < DateTime.UtcNow);
            }
            if (UserId.HasValue)
                query = query.Where(q=>q.User.Id == UserId.Value);
            if (IsChecked.HasValue)
                query = query.Where(q => q.IsChecked == IsChecked.Value);
            return query;
        }
    }
}
