using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace iti_prohect.Models
{
    public class BorrowRecord
    {
        public int Id { get; set; }                  

   
        public int BookId { get; set; }
        public int MemberId { get; set; }

        public DateTime BorrowDate { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }         // null = لسه ما اترجعش

        public bool IsReturned => ReturnDate.HasValue;

        // Navigation
        [ValidateNever]
        public Book Book { get; set; } = null!;
        [ValidateNever]
        public Member Member { get; set; } = null!;
    }
}
