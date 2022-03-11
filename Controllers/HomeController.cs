using Microsoft.AspNetCore.Mvc;
using OSBookReviewWepApi.Models;
using OSBookReviewWepApi.Services;
using OSBookReviewWepApi.Views.Home;
using System.Diagnostics;

namespace OSBookReviewWepApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataClass _data;

        public HomeController(ILogger<HomeController> logger, IDataClass _data)
        {
            _logger = logger;
            this._data = _data;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Author()
        {
            return View(new AuthorModel(_data));
        }

        public IActionResult TopAuthor()
        {
            return View(new TopAuthorModel(_data));
        }

        public IActionResult Publisher()
        {
            return View(new PublisherModel(_data));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}