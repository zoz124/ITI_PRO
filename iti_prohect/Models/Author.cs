using System.ComponentModel.DataAnnotations;

namespace iti_prohect.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; } = string.Empty;

        public string? Bio { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
