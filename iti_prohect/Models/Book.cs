using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace iti_prohect.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string ISBN { get; set; } = string.Empty;

        public int AuthorId { get; set; }
        public int CategoryId { get; set; }

        // Navigation properties
        [ValidateNever]
        public Author Author { get; set; } = null!;
        [ValidateNever]
        public Category Category { get; set; } = null!;

        public ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
    }
}
