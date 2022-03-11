using System.ComponentModel.DataAnnotations;

namespace OSBookReviewWepApi.Models
{
    public class Login
    {
        [Key]
        public int Userid { get; set; }
        public int Uaid { get; set; }
        public int AccessLevel { get; set; }
        public string? UserName { get; set; }
        public string? UserPword { get; set; }
        public string? AccessToken { get; set; }
        public bool ValidUser { get; set; }
        public string? RegisteredDeviceCode { get; set; }
        public bool DeviceRegistered { get; set; }

    }
}
