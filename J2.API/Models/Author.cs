using System.ComponentModel.DataAnnotations;

namespace J2.API.Models
{
    [Auditable]
    public class Author:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Book> Books { get; set; }

    }
}
