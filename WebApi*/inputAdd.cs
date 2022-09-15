using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    public class inputAdd
    {
        [StringLength(50)]
        public string ContactName { get; set; } = string.Empty;

        [StringLength(11)]
        public string Phone { get; set; } = string.Empty;

        [StringLength(50)]
        public string Email { get; set; } = string.Empty;

        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(300)]
        public string Message_text { get; set; } = string.Empty;
    }
}
