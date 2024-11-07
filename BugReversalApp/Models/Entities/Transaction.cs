using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Transactions;
using BugReversalApp.Models.Enum;

namespace BugReversalApp.Models.Entities
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(50)]
        public string SenderAccount { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string ReceiverAccount { get; set; } = string.Empty;

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public TransactionType Type { get; set; }

        [Required]
        public ReversalTransactionStatus Status { get; set; } = ReversalTransactionStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
