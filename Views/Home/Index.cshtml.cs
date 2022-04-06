using Microsoft.AspNetCore.Mvc.RazorPages;
using OSBookReviewWepApi.Models;
using OSBookReviewWepApi.Services;

namespace OSBookReviewWepApi.Views.Home
{
    public class IndexModel : PageModel
    {
        private readonly IDataClass _data;

        public List<Author> _authors { get; set; }
        public List<BookReview> _books { get; set; } 
        public IndexModel(IDataClass _data)
        {
            this._data = _data;
            _authors = new List<Author>();
            _books = new List<BookReview>();
        }

        public async Task OnGetAsync()
        {
            await FillList();
        }

        public async void GetBooks()
        {
            _books = await GetBooksList();
        }

        public async Task FillList()
        {
            _authors = await GetList();
        }

        public async void GetAuthors(string authorname)
        {
            _authors = await GetList(authorname);
        }

        private async Task<List<Author>> GetList()
        {
            _authors.Clear();
            return _authors = await _data.GetListAsync();
        }

        private async Task<List<Author>> GetList(string authorname)
        {
            return await _data.GetListAsync(authorname);
        }

        private async Task<List<BookReview>> GetBooksList()
        {
            _books.Clear();
            return _books;
        }
    }
}
