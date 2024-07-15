namespace LeaveManagementSystem.Web.Models.LeaveAllocations
{
    public class EmployeeAllocationsVM : EmployeesListVM
    {   
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.DateTime)]
        public DateOnly DateOfBirth { get; set; }
        public bool IsCompletedAllocation { get; set; }
        public List<LeaveAllocationsVM> LeaveAllocations { get; set; }
    }
}
