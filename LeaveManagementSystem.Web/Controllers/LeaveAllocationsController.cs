using LeaveManagementSystem.Web.Models.LeaveAllocations;
using LeaveManagementSystem.Web.Services.LeaveAllocation;
using LeaveManagementSystem.Web.Services.LeaveType;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class LeaveAllocationsController(ILeaveAllocationService _leaveAllocationService,
        ILeaveTypesService _leaveTypesService) : Controller
    {
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> Index()
        {
            var employees = await _leaveAllocationService.GetEmployees();
            return View(employees);
        }

        [Authorize(Roles = Roles.Administrator)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AllocateLeave(string? id)
        {
            await _leaveAllocationService.AllocateLeave(id);
            return RedirectToAction(nameof(Details), new { userId = id });
        }
        public async Task<IActionResult> Details(string? userId)
        {
            var employeeVm = await _leaveAllocationService.GetEmployeeAllocations(userId);
            return View(employeeVm);
        }

        [Authorize(Roles =Roles.Administrator)]
        public async Task<IActionResult> EditAllocation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocation = await _leaveAllocationService.GetEmployeeAllocation(id.Value);
            if (allocation == null)
            {
                return NotFound();
            }
            return View(allocation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocation(LeaveAllocationEditVM allocation)
        {
            if(await _leaveTypesService.DaysExceedMaximum(allocation.LeaveType.Id, allocation.Days))
            {
                ModelState.AddModelError("Days", "Exceeded the maximum allocation of days possible");
            }
            if (ModelState.IsValid)
            {
                await _leaveAllocationService.Editallocation(allocation);
                return RedirectToAction(nameof(Details), new { userId = allocation.Employee.Id });
            }
            var days = allocation.Days;
            allocation = (LeaveAllocationEditVM)await _leaveAllocationService.GetEmployeeAllocation(allocation.Id);
            allocation.Days = days;
            return View(allocation);
        }
    }
}
