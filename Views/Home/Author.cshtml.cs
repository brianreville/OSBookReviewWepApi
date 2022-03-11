using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OSBookReviewWepApi.Services;

namespace OSBookReviewWepApi.Views.Home
{
    public class AuthorModel : PageModel
    {
        private readonly IDataClass _data;

        [BindProperty]
        public string AuthorName { get; set; }

        public AuthorModel(IDataClass _data)
        {
            this._data = _data;
        }

        public void OnGet()
        {
            AuthorName = "Test Author Name";
        }
    }
}
