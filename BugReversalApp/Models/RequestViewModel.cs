using BugReversalApp.Models.Entities;
using BugReversalApp.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BugReversalApp.Models
{/*
    public class RequestViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public List<Guid> TransactionId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } // Navigation property to access User details
        public bool Approved { get; set; } = false;

    }*/


    /* public class RequestViewModel
     {
         public Guid Id { get; set; }
         public Guid UserId { get; set; }
         public string UserName { get; set; } = string.Empty;
         public decimal Amount { get; set; }
         public bool Approved { get; set; }

         public List<Guid> TransactionId { get; set; }
     }*/
    public class RequestViewModel
    {
        public Guid Id { get; set; }
        public List<Guid> TransactionId { get; set; } = new List<Guid>();
        public bool Approved { get; set; } = false;
    }

}

