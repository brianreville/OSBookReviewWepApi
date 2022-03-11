using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OSBookReviewWepApi.Services;

namespace OSBookReviewWepApi.Views.Home
{
    public class PublisherModel : PageModel
    {
        private readonly IDataClass _data;

        public string Name { get; set; }

        public PublisherModel(IDataClass _data)
        {
            this._data = _data;
        }

        public void OnGet()
        {
            Name = "Test";

        }
    }
}
