namespace LeaveManagementSystem.Web.Data;

public class LeaveAllocation : BaseEntity
{
    public LeaveType? leaveType { get; set; }
    public int leaveTypeId { get; set; }
    public ApplicationUser? Employee { get; set; }
    public string EmployeeId { get; set; }
    public Period? Period { get; set; }
    public int PeriodId { get; set; }
    public int Days { get; set; }
}
