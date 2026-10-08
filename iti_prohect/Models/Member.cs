using System.ComponentModel.DataAnnotations;

namespace iti_prohect.Models
{
    public class Member
    {

     
            public int Id { get; set; }                       // Primary Key

            [Required, StringLength(150)]
            public string FullName { get; set; } = string.Empty;

            [Required, EmailAddress, StringLength(150)]
            public string Email { get; set; } = string.Empty; // Unique

            [Phone, StringLength(20)]
            public string? Phone { get; set; }

            public DateTime JoinDate { get; set; } = DateTime.UtcNow;

            public ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
        }
}
