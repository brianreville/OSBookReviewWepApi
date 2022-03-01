using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OSBookReviewWepApi.Models;
using OSBookReviewWepApi.Services;

namespace OSBookReviewWepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // TODO: Uncomment and implement authorization when mobile app ready initally , web site required for future for login in authorisation
    // uncomment to add bearer token authorization
    //[Authorize("Bearer")]
    public class BookController : ControllerBase
    {
        private readonly IDataClass _data;

        public BookController(IDataClass data)
        {
            _data = data;
        }

        // public api calls

        // public get command to return a list of authors
        [HttpGet]
        [Route("GetAuthors")]
        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            List<Author> authors = await GetAuthorList();
            return authors;
        }
        // public get command to return a list of books by a specifc author
        [Route("GetAuthorBooks")]
        public async Task<IEnumerable<BookReview>> GetBooksAsync(int aid)
        {
            List<BookReview> books = await GetAuthorBooks(aid);
            return books;
        }
        // public post command to add a review
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> AddBookReview([FromBody] BookReview book)
        {
            bool res = await AddRecord(book);
            return res ? Ok() : BadRequest("Error in adding book review");
        }
        // public put command to update a record
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateBookReview([FromBody] BookReview book)
        {
            bool res = await UpdateRecord(book);
            return res ? Ok() : BadRequest("Error in updating book review");
        }

        // private methods to call on the data service

        // return a list of authors from the data service
        private async Task<List<Author>> GetAuthorList()
        {
            return await _data.GetListAsync();
        }
        // returns a list of books belonging to a specific author using the authors id from the data service
        private async Task<List<BookReview>> GetAuthorBooks(int aid)
        {
            return await _data.GetListAsync(aid);
        }
        // add record using data service
        private async Task<bool> AddRecord(BookReview book)
        {
            return await _data.AddAsync(book);
        }
        // updates a record using the data service
        private async Task<bool> UpdateRecord(BookReview book)
        {
            return await _data.UpdateAsync(book);
        }
    }
}
