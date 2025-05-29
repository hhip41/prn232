namespace FirstWebAPIProject.DTOs
{
    public class PagedResponse<T>
    {
        public List<T> Items { get; set; }
        public int TotalRecords { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public PagedResponse()
        {
            Items = new List<T>();
        }

        public PagedResponse(List<T> items, int totalRecords, int currentPage, int pageSize)
        {
            Items = items;
            TotalRecords = totalRecords;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }
    }
}
