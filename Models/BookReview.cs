namespace OSBookReviewWepApi.Models
{
    public class BookReview
    {
        public int BDID { get; set; }
        public int Userid { get; set; }
        public int Rating { get; set; }
        public decimal OverallRating { get; set; }
        public string? PublisherName { get; set; }
        public string? AuthorName { get; set; }
        public string? Username { get; set; }
    }
}
