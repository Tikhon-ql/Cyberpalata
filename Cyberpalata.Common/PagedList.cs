namespace Cyberpalata.Common
{
    public class PagedList<T>
    {
        public PagedList(List<T> items, int currentPageNumber, int pageSize, int totalItemsCount)
        {
            Items = items;
            CurrentPageNumber = currentPageNumber;
            PageSize = pageSize == 0 ? 1 : pageSize;
            TotalItemsCount = totalItemsCount;
        }


        public List<T> Items { get; }
        public int CurrentPageNumber { get; }
        public int PageSize { get; }
        public int TotalItemsCount { get; }
    }
}