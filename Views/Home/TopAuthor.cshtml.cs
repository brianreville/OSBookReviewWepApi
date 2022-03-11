using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OSBookReviewWepApi.Models;
using OSBookReviewWepApi.Services;
using System.Threading.Tasks;

namespace OSBookReviewWepApi.Views.Home
{
    public class TopAuthorModel : PageModel
    {
        private readonly IDataClass _data;

        public List<Author> Authors { get; set; }
        public TopAuthorModel(IDataClass _data)
        {
            Authors = new();
            this._data = _data;
        }

        public async Task OnGetAsync()
        {
            Authors = await _data.GetListAsync();
        }
    }
}
