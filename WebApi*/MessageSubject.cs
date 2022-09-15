using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    public class MessageSubject
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
    }
}
