using System.Collections.Generic;
using System.Threading.Tasks;
using Exam.Data;
using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTrackerApp.Data
{
	public class EmployeeRepository
	{
		private readonly AppDbContext context;

		public EmployeeRepository(AppDbContext context)
		{
			this.context = context;
		}

		public virtual async Task<List<Employee>> GetEmployeesAsync()
		{
			return await context.Employees.ToListAsync();
		}

        public async Task AddEmployeesAsync(List<Employee> emp)
		{
			using (var transaction = context.Database.BeginTransactionAsync())
            {
				await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Employees ON;");
				await context.AddRangeAsync(emp);
				await context.SaveChangesAsync();
				await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Employees OFF;");
				await transaction.Result.CommitAsync();
			}
		}
	}
}
