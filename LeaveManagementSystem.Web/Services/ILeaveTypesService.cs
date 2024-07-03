using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.Services
{
    public interface ILeaveTypesService
    {
        Task<bool> CheckIfLeaveTypeExist(string name);
        Task<bool> CheckIfLeaveTypeExistForEdit(LeaveTypeUpdateVM leaveTypeUpdate);
        Task Create(LeaveTypeCreateVM model);
        Task Edit(LeaveTypeUpdateVM model);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<LeaveTypeReadOnlyVM>> GetAll();
        bool LeaveTypeExists(int id);
        Task Remove(int id);
    }
}