/*using BugReversalApp.Data;
using BugReversalApp.Models.Entities;
using BugReversalApp.Models;
using BugReversalApp.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BugReversalApp.Controllers
{
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MakeRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeRequest(RequestViewModel request)
        {
            var userId = Guid.Parse(HttpContext.Session.GetString("UserId"));
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            if (request.TransactionId == null || !request.TransactionId.Any())
            {
                ModelState.AddModelError("", "No transaction IDs provided.");
                return View(request);
            }

            foreach (var transactionId in request.TransactionId)
            {
                var newRequest = new Request
                {
                    TransactionId = transactionId,
                    UserId = userId,
                    Status = RequestStatus.Pending
                };
                _context.Requests.Add(newRequest);
            }

            _context.SaveChanges();
            return View("Confirmed");
        }

        [HttpGet]
        public IActionResult ViewRequests()
        {
            var requests = _context.Requests
                .Where(x => x.Status != RequestStatus.Approved)
                .ToList();
            return View(requests);
        }

        [HttpGet]
        public IActionResult ReviewRequest(Guid id)
        {
            var request = _context.Requests.FirstOrDefault(x => x.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            // Map `Request` to `RequestViewModel`, ensuring `TransactionId` is a list
            var requestViewModel = new RequestViewModel
            {
                Id = request.Id,
                TransactionId = new List<Guid> { request.TransactionId }, // Convert single `TransactionId` to List<Guid>
                UserId = request.UserId
            };

            HttpContext.Session.SetString("RequestId", id.ToString());
            return View(requestViewModel);
        }

        [HttpPost]
        public IActionResult ApproveRequest(bool approved)
        {
            var requestIdString = HttpContext.Session.GetString("RequestId");
            if (string.IsNullOrEmpty(requestIdString) || !Guid.TryParse(requestIdString, out var requestId))
            {
                return NotFound();
            }

            var request = _context.Requests.FirstOrDefault(x => x.Id == requestId);
            if (request == null)
            {
                return NotFound();
            }

            request.Status = approved ? RequestStatus.Approved : RequestStatus.Rejected;

            if (approved)
            {
                var transaction = _context.Transactions.FirstOrDefault(x => x.Id == request.TransactionId);
                if (transaction != null)
                {
                    var account = _context.Accounts.FirstOrDefault(x => x.AccountNumber == transaction.SenderAccount);
                    if (account != null)
                    {
                        account.Balance += transaction.Amount;
                    }
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Confirmed()
        {
            return View();
        }
    }
}*/




using BugReversalApp.Data;
using BugReversalApp.Models.Entities;
using BugReversalApp.Models;
using BugReversalApp.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace BulkReversal.Controllers
{
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RequestController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MakeRequest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MakeRequest(RequestViewModel request)
        {
            var userId = Guid.Parse(HttpContext.Session.GetString("UserId"));
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var c = request.TransactionId;
            for (int i = 0; i <= request.TransactionId.Count - 1; i++)
            {
                Request newRequest = new Request
                {
                    TransactionId = request.TransactionId[i],
                    UserId = userId
                };
                _context.Requests.Add(newRequest);
                _context.SaveChanges();
            }

            return View("Confirmed");
        }
        [HttpGet]
        public IActionResult ViewRequests()
        {
            var requests = _context.Requests.Where(x => x.Approved != true).ToList();
            return View(requests);
        }
        [HttpGet]
        public IActionResult ReviewRequest(Guid Id)
        {
            var request = _context.Requests.FirstOrDefault(x => x.Id == Id);
            HttpContext.Session.SetString("RequestId", Id.ToString());
            return View(request);

        }
        [HttpPost]
        public IActionResult ApproveRequest(Request request)
        {
            var Id = Guid.Parse(HttpContext.Session.GetString("RequestId"));
            var get = _context.Requests.FirstOrDefault(x => x.Id == Id);
            Console.WriteLine(Id);
            var check = request.Approved;
            if (check == true)
            {
                get.Approved = true;
                var transaction = _context.Transactions.FirstOrDefault(x => x.Id == get.TransactionId);
                var account = _context.Accounts.FirstOrDefault(x => x.AccountNumber == transaction.SenderAccount);
                account.Balance = account.Balance + transaction.Amount;
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Falseeeeeeeeeeeeeeeeeeeeeeeeeeee");
            }
            _context.SaveChanges();
            return View("Success");
        }

        public IActionResult Success()

        {
            return View();
        }

        public IActionResult Confirmed()
        {
            return View();
        }
    }
}




