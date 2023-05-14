using System.ComponentModel.DataAnnotations;

namespace SampleApi.Models
{
    public class SignUpRequest : IUpdatetracked
    {
        public int Id { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? EmailAddress { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        public virtual DateTimeOffset? CreatedAt { get { return DateTimeOffset.UtcNow; } set { } }
    }
}
