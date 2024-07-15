using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Web.Data.Configurations
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole <string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole <string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "d278c2d4-b79e-4db9-803a-7e76a803a9e0",
                    UserId = "08c8d0e3-6ccc-4cf2-92aa-2fa1bb99bbdb"
                });
        }
    }
}
