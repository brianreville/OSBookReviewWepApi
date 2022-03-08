namespace OSBookReviewWepApi.Models
{
    public class BookReview
    {
        public int BDID { get; set; }
        public int Userid { get; set; }
        public int Rating { get; set; }
        public decimal OverallRating { get; set; }
        public string? PublisherName { get; set; }
        public string? BookName { get; set; }
        public string? AuthorName { get; set; }
        public string? Username { get; set; }
        public string? ImageUrlS { get; set; }
        public string? ImageUrlM { get; set; }
        public string? ImageUrlL { get; set; }
    }
}
