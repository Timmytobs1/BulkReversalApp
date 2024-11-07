namespace BugReversalApp.Models
{
    public class RequestViewModel
    {


            public Guid Id { get; set; }
            public List<Guid> TransactionId { get; set; } = new List<Guid>();
            public bool Approved { get; set; } = false;

         
    }

}

