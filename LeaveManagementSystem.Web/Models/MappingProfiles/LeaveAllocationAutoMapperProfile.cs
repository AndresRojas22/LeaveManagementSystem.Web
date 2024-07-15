using AutoMapper;
using LeaveManagementSystem.Web.Models.LeaveAllocations;
using LeaveManagementSystem.Web.Models.Period;

namespace LeaveManagementSystem.Web.Models.MappingProfiles
{
    public class LeaveAllocationAutoMapperProfile : Profile
    {
        public LeaveAllocationAutoMapperProfile()
        {
            CreateMap<LeaveAllocation, LeaveAllocationsVM>();
            CreateMap<ApplicationUser, EmployeesListVM>();
            CreateMap<Data.Period, PeriodVM>();
            CreateMap<LeaveAllocation, LeaveAllocationEditVM>();
        }
    }
}
