namespace OSBookReviewWepApi.Models
{
    public class Author
    {
        public int AID { get; set; }
        public string? AuthorName { get; set; }
        public List<BookReview>? AuthorBooks { get; set; }
    }
}
