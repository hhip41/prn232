namespace FirstWebAPIProject
{
    public class UrlQueryParameters
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        // Optional: validate giá trị tối đa/tối thiểu
        private const int maxPageSize = 50;

        public int ValidatedPageSize
        {
            get
            {
                return (PageSize > maxPageSize) ? maxPageSize : PageSize;
            }
        }
    }
}
