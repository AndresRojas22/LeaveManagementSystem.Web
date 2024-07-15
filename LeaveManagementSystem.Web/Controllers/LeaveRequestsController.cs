using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize]
    public class LeaveRequestsController : Controller
    {
        //Employee view requests
        public async Task<IActionResult> Index()
        {
            return View();
        }
        //Employee create requets
        public async Task<IActionResult> Create()
        {
            return View();
        }
        //Employee create requests
        [HttpPost]
        public async Task<IActionResult> Create(int create /*Use a VM*/)
        {
            return View();
        }
        //Employee cancel requests
        [HttpPost]
        public async Task<IActionResult> Cancel(int leaveRequestId)
        {
            return View();
        }
        // Admin/Supe review requests
        public async Task<IActionResult> ListRequests()
        {
            return View();
        }
        // Admin/Supe review requests
        public async Task<IActionResult> Review(int leaveRequestId)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Review(/* Use a VM */)
        {
            return View();
        }

    }
}
