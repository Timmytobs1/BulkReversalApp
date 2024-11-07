using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BugReversalApp.Models.Entities
{
    [Index(nameof(AccountNumber), IsUnique = true)]
    public class Account
    {
        [Key]
        public Guid Id { get; set; } 

        [Required, StringLength(50)]
        public string AccountNumber { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string AccountName { get; set; } = string.Empty;

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; } = 0m; 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
