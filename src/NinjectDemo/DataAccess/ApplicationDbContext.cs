using System;
using System.Data.Entity;
using NinjectDemo.Domain;

namespace NinjectDemo.DataAccess
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext()
			: base("name=DefaultConnection")
		{
		}

		public DbSet<User> Users { get; set; }       
		
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().ToTable("Users");
			modelBuilder.Entity<Role>().ToTable("Roles");
			modelBuilder.Entity<UserRole>().ToTable("UserRoles");
			modelBuilder.Entity<UserLogin>().ToTable("UserLogins");
			modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
		}

	}
}

