using System;
using System.Data.Entity;
using Domain.NinjectDemo;

namespace NinjectDemo.DataAccess
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext()
			: base("name=DefaultConnection")
		{
		}

		public DbSet<Article> Articles { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Lecture> Lectures { get; set; }
		public DbSet<Step> Steps { get; set; }
		public DbSet<User> Users { get; set; }       
		public DbSet<StepProgress> StepProgresses { get; set; }
		public DbSet<Subscription> Subscriptions { get; set; }
		public DbSet<Transaction> TransactionLogs { get; set; }

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

