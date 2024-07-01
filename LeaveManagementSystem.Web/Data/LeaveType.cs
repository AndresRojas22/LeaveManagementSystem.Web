using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Web.Data
{
    public class LeaveType
    {
        //Primary key is called Id
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }
        public int NumberOfDays { get; set; }
    }
}
