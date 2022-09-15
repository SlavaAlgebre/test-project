using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    public class Message
    {
        public int Id { get; set; }


        public int MessageSubjectId { get; set; }
        public MessageSubject? MessageSubject { get; set; }

        public int ContactId { get; set; }
        public Contact? Contact { get; set; }

        [StringLength(300)]
        public string Message_text { get; set; } = string.Empty;
    }
}
