using OSBookReviewWepApi.Models;

namespace OSBookReviewWepApi.Services
{
    public interface IDataClass
    {
        Task<bool> AddAsync(BookReview p);
        Task<BookReview> GetIndv(int id);
        Task<List<Author>> GetListAsync();
        Task<List<BookReview>> GetListAsync(int aid);
        Task<bool> UpdateAsync(BookReview p);
        Task<bool> UpdateAsync(List<BookReview> books);
        Task<IEnumerable<Author>> GetAuthors();
        Task<List<Author>> GetListAsync(string name);
    }
}