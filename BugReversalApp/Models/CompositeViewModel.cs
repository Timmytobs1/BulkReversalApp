using BugReversalApp.Models.Entities;

namespace BugReversalApp.Models
{
    public class CompositeViewModel
    {
        public User User { get; set; } = new User();
        public List<User> Users { get; set; } = new List<User>();
        public Request Request { get; set; } = new Request();
        public List<Request> Requests { get; set; } = new List<Request>();

        // Optional constructor for ease of use
        public CompositeViewModel()
        {
            Users = new List<User>();
            Requests = new List<Request>();
        }
    }
}
