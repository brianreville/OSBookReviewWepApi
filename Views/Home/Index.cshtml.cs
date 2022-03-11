using Microsoft.AspNetCore.Mvc.RazorPages;
using OSBookReviewWepApi.Models;
using OSBookReviewWepApi.Services;

namespace OSBookReviewWepApi.Views.Home
{
    public class IndexModel : PageModel
    {
        private readonly IDataClass _data;

        public List<Author> _authors { get; set; } = new();
        public IndexModel(IDataClass _data)
        {
            this._data = _data;
        }

        public void OnGet()
        {
            FillList();
        }

        private async void FillList()
        {
            _authors = await GetList();
        }

        private async Task<List<Author>> GetList()
        {
            _authors.Clear();
            return _authors = await _data.GetListAsync();
        }
    }
}
