namespace Cyberpalata.ViewModel.Response.Rooms
{
    public class RoomCollectionViewModel
    {
        public List<RoomItemViewModel> Items { get; set; } = new();
        public int TotalItemsCount { get; set; }
        public int PageSize { get; set; }
    }
}
