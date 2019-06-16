namespace identity_rest_service.Helpers
{
    public class PaginationHeader
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public PaginationHeader(int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            this.TotalItems = totalItems;
            this.TotalPages = totalPages;
            this.CurrentPage = currentPage;
            this.ItemsPerPage = itemsPerPage;
        }
    }
}