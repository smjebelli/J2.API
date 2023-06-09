using System.Security.Principal;

namespace J2.API.Models
{
    public class Book:BaseEntity
    {
        public string Title { get; set; }
        public string Isbn { get; set; }
        public Author Author { get; set; }
        public DateTime DatePublished { get; set; }
        public string Genre { get; set; }
    }
}
