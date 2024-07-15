using LeaveManagementSystem.Web.Models.LeaveAllocations;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace LeaveManagementSystem.Web.Services.LeaveAllocation
{
    public interface ILeaveAllocationService
    {
        Task AllocateLeave(string EmployeeId);
        Task <List<Data.LeaveAllocation>> GetAllocations(string? userId);
        Task<EmployeeAllocationsVM> GetEmployeeAllocations(string? userId);
        Task<List<EmployeesListVM>> GetEmployees();
        Task Editallocation(LeaveAllocationEditVM allocationEditVM);
        Task<LeaveAllocationsVM> GetEmployeeAllocation(int allocationId);
    }
}
