using Microsoft.EntityFrameworkCore;
using WebApi;

namespace WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MessageSubject> MessageSubjects { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<WebApi.outputAdd>? output { get; set; }

        public DbSet<WebApi.outputGet>? outputGet { get; set; }
    }
}
