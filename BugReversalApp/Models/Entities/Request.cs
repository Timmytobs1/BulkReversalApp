using BugReversalApp.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugReversalApp.Models.Entities
{
    public class Request
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid TransactionId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } // Navigation property to access User details

        [Required]
        public RequestStatus Status { get; set; } = RequestStatus.Pending;

        public bool Approved { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
