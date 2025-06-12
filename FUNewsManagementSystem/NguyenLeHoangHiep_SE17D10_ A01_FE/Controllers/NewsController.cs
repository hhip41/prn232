using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace NguyenLeHoangHiep_SE17D10__A01_FE.Controllers
{
    public class NewsController : Controller
    {
        private readonly HttpClient _httpClient;

        public NewsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7080/api/");
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
        {
            // Validate parameters
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 5;

            var response = await _httpClient.GetAsync("news/active");
            if (!response.IsSuccessStatusCode) return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var allNews = JsonSerializer.Deserialize<List<NewsViewModel>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<NewsViewModel>();

            // Calculate pagination
            var totalItems = allNews.Count;
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            var skipItems = (page - 1) * pageSize;
            var pagedNews = allNews.Skip(skipItems).Take(pageSize).ToList();

            // Create pagination info
            var paginationInfo = new PaginationInfo
            {
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize,
                TotalItems = totalItems,
                HasPrevious = page > 1,
                HasNext = page < totalPages
            };

            // Create view model
            var viewModel = new NewsIndexViewModel
            {
                News = pagedNews,
                Pagination = paginationInfo
            };

            return View(viewModel);
        }
    }

    public class NewsViewModel
    {
        public string NewsTitle { get; set; } = string.Empty;
        public string NewsContent { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }

    public class NewsIndexViewModel
    {
        public List<NewsViewModel> News { get; set; } = new List<NewsViewModel>();
        public PaginationInfo Pagination { get; set; } = new PaginationInfo();
    }

    public class PaginationInfo
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }

        public int StartPage => Math.Max(1, CurrentPage - 2);
        public int EndPage => Math.Min(TotalPages, CurrentPage + 2);
    }
}