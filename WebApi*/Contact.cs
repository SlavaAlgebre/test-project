using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    public class Contact
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string ContactName { get; set; } = string.Empty;

        [StringLength(11)]
        public string Phone { get; set; } = string.Empty;

        [StringLength(50)]
        public string Email { get; set; } = string.Empty;
    }
}
