using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Filters
{
    public class NotificationFilter : BaseFilter<Notification>
    {
        public Maybe<bool> IsActual { get; set; }
        public Maybe<Guid> UserId { get; set; }
        public Maybe<bool> NotificationProceded { get; set; }
        public Maybe<List<Guid>> NotificationIds { get; set; }

        public override IQueryable<Notification> EnrichQuery(IQueryable<Notification> query)
        {
            if(IsActual.HasValue)
            {
                if(IsActual.Value)
                    query = query.Where(q=>q.CreatedDate > DateTime.UtcNow);
                else
                    query = query.Where(q=>q.CreatedDate < DateTime.UtcNow);
            }
            if (UserId.HasValue)
                query = query.Where(q=>q.User.Id == UserId.Value);
            if (NotificationProceded.HasValue)
                query = query.Where(q => q.SentDate.HasValue == NotificationProceded.Value);
            if (NotificationIds.HasValue)
                query = query.Where(q => NotificationIds.Value.Contains(q.Id));
            return query;
        }
    }
}
