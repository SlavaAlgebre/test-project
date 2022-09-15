using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    public class outputGet
    {
        public int Id { get; set; }
        public int MessageSubjectId { get; set; }
        public int ContactId { get; set; }

        [StringLength(300)]
        public string Message_text { get; set; } = string.Empty;
    }
}
