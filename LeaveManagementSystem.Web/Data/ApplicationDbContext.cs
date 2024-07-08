using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<IdentityRole>().HasData(
				new IdentityRole
				{
					Id = "da0bd94c-8740-4966-b73f-ab473ebb2e3b",
					Name = "Employee",
					NormalizedName = "EMPLOYEE"
				},
				new IdentityRole
				{
					Id = "dfbb7190-a1ac-4486-8901-301a954e4778",
					Name = "Supervisor",
					NormalizedName = "SUPERVISOR"
				},
				new IdentityRole
				{
					Id = "d278c2d4-b79e-4db9-803a-7e76a803a9e0",
					Name = "Administrator",
					NormalizedName = "ADMINISTRATOR"
				}
			);

			var hasher = new PasswordHasher<ApplicationUser>();
			builder.Entity<ApplicationUser>()
				.HasData(new ApplicationUser
				{
					Id = "08c8d0e3-6ccc-4cf2-92aa-2fa1bb99bbdb",
					Email = "admin@localhost.com",
					NormalizedEmail = "ADMIN@LOCALHOST.COM",
					NormalizedUserName = "ADMIN@LOCALHOST.COM",
					UserName = "admin@localhost.com",
					PasswordHash = hasher.HashPassword(null, "P@ssword1"),
					EmailConfirmed = true,
					FirstName = "Default",
					LastName = "Admin",
					DateOfBirth = new DateOnly(2001,07,19)
				});

			builder.Entity<IdentityUserRole<string>>().HasData(
				new IdentityUserRole<string>
				{
					RoleId = "d278c2d4-b79e-4db9-803a-7e76a803a9e0",
					UserId = "08c8d0e3-6ccc-4cf2-92aa-2fa1bb99bbdb"
                });
		}

        public DbSet<LeaveType> LeaveTypes { get; set; }	
	}
}
