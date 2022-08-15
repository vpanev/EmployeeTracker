using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}
		public virtual DbSet<Employee> Employees { get; set; }


		protected override void OnModelCreating(ModelBuilder b)
		{
			b.Entity<Employee>(e =>
			{
				e.HasKey(x => x.EmployeeId);
			});
		}
	}
}
