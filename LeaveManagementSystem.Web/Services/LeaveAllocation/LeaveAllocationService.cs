using AutoMapper;
using LeaveManagementSystem.Web.Models.LeaveAllocations;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LeaveManagementSystem.Web.Services.LeaveAllocation
{
    public class LeaveAllocationService(ApplicationDbContext _context, IHttpContextAccessor _httpContextAccessor
        , UserManager<ApplicationUser> _userManager, IMapper _mapper) : ILeaveAllocationService
    {
        public async Task AllocateLeave(string EmployeeId)
        {
            //Get all the leave types
            var leaveTypes = await _context.LeaveTypes
                .Where(q => !q.LeaveAllocations.Any(x => x.EmployeeId == EmployeeId))
                .ToListAsync();

            //Get the current period based on the year
            var currentDate = DateTime.Now;
            var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);
            var monthsRemaining = period.EndDate.Month - currentDate.Month;
            //Foreach leave type, create an allocation entry
            foreach (var leaveType in leaveTypes)
            {
                //Works but not best practice
                //var allocationExist = await AllocationExists(EmployeeId, period.Id, leaveType.Id);
                //if (allocationExist)
                //{
                //    continue;
                //}
                var accuralRate =  decimal.Divide(leaveType.NumberOfDays, 12);
                var leaveAllocation = new Data.LeaveAllocation
                {
                    EmployeeId = EmployeeId,
                    leaveTypeId = leaveType.Id,
                    PeriodId = period.Id,
                    Days = (int)Math.Ceiling(accuralRate * monthsRemaining)
                };
                _context.Add(leaveAllocation);
            }
            await _context.SaveChangesAsync();
        }

        public async Task Editallocation(LeaveAllocationEditVM allocationEditVM)
        {
            var leaveAllocation = await GetEmployeeAllocation(allocationEditVM.Id) ?? throw new Exception
                ("Leave allocation record does not exist.");
            leaveAllocation.Days = allocationEditVM.Days;
            //Option 1 _context.Update(leaveAllocation);
            //Option 2 _context.Entry(leaveAllocation).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

            await _context.LeaveAllocations
                .Where(q => q.Id == allocationEditVM.Id)
                .ExecuteUpdateAsync(s => s.SetProperty(e => e.Days, allocationEditVM.Days));
        }

        public async Task <List<Data.LeaveAllocation>> GetAllocations(string? userId)
        {
            string employeeId = string.Empty;
            if(!userId.IsNullOrEmpty())
            {
                employeeId = userId;
            }
            else
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
                employeeId = user.Id;
            }
            var currentDate = DateTime.Now;
            //var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);
            //var leaveAllocations = await _context.LeaveAllocations
            //    .Include(q => q.leaveType)
            //    .Include(q => q.Period)
            //    .Where(q => q.EmployeeId == user.Id && q.Period.Id == period.Id)
            //    .ToListAsync();

            var leaveAllocations = await _context.LeaveAllocations
                .Include(q => q.leaveType)
                .Include(q => q.Period)
                .Where(q => q.EmployeeId == employeeId && q.Period.EndDate.Year == currentDate.Year)
                .ToListAsync();

            return leaveAllocations;
        }

        public async Task<EmployeeAllocationsVM> GetEmployeeAllocations(string? userId)
        {
            var user = string.IsNullOrEmpty(userId)
                ? await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User)
                : await _userManager.FindByIdAsync(userId);

            var allocations = await GetAllocations(user.Id);
            var allocationsVmList = _mapper.Map<List<Data.LeaveAllocation>, List<LeaveAllocationsVM>>(allocations);
            var leaveTypesCount = await _context.LeaveTypes.CountAsync();
            //_mapper.Map<origen, destino> De que tipo => a que tipo quieres convertir

            var employeeVm = new EmployeeAllocationsVM
            {
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                LeaveAllocations = allocationsVmList,
                IsCompletedAllocation = leaveTypesCount == allocations.Count()
            };

            return employeeVm;
        }

        public async Task<List<EmployeesListVM>> GetEmployees()
        {
            var users = await _userManager.GetUsersInRoleAsync(Roles.Employee);
            var employees = _mapper.Map<List<ApplicationUser>, List<EmployeesListVM>>(users.ToList());

            return employees;
        }

        private async Task<bool> AllocationExists(string userId, int periodId, int LeaveTypeId)
        {
            var exists = await _context.LeaveAllocations.AnyAsync(q =>
            q.EmployeeId == userId 
            && q.leaveTypeId == LeaveTypeId
            && q.PeriodId == periodId
            );

            return exists;
        }

        public async Task<LeaveAllocationsVM> GetEmployeeAllocation(int allocationId)
        {
            var allocation = await _context.LeaveAllocations
                .Include(q => q.leaveType)
                .Include(q => q.Employee)
                .FirstOrDefaultAsync(q => q.Id == allocationId);
            var model = _mapper.Map<LeaveAllocationEditVM>(allocation);

            return model;
        }
    }
}
