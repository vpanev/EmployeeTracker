using System;
using System.Collections.Generic;
using EmployeeTrackerApp.Controllers;
using EmployeeTrackerApp.Data;
using Exam.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace EmployeeTrackerApp.UnitTests
{
	public class Tests
	{
		protected Mock<EmployeeRepository> employeeRepository;
		[SetUp]
		public void Setup()
		{
			var employees = new List<Employee>();
			employees.Add(new Employee {EmployeeId = 1, When = DateTime.Now});
			employees.Add(new Employee {EmployeeId = 2, When = DateTime.Now});
			employees.Add(new Employee {EmployeeId = 3, When = DateTime.Now});
			var mockSet = new Mock<DbSet<Employee>>();

			var options = new DbContextOptionsBuilder<AppDbContext>().Options;

			var mockContext = new Mock<AppDbContext>(options);
			mockContext.Setup(x => x.Employees).Returns(mockSet.Object);

			employeeRepository = new Mock<EmployeeRepository>(mockContext.Object);
			employeeRepository.Setup(x => x.GetEmployeesAsync()).ReturnsAsync(employees);
		}

		[Test]
		public void Subscribe_BadDate_ReturnsBadRequest()
		{
			var homeController = new HomeController(employeeRepository.Object);
			string date = "2022-22-22";

			var result = homeController.Subscribe(date);

			Assert.IsInstanceOf<BadRequestResult>(result.Result);
		}

		[Test]
		public void Subscribe_GoodDate_ReturnsValidActionResult()
		{
			var homeController = new HomeController(employeeRepository.Object);
			string date = "2022-12-01";

			var result = homeController.Subscribe(date);

			var actionResult = result.Result as RedirectToActionResult;

			Assert.AreEqual("Index", actionResult?.ActionName);
			Assert.AreEqual("Home", actionResult?.ControllerName);
		}
	
		[Test]
		public void Index_Returns_ValidView()
		{
			var homeController = new HomeController(employeeRepository.Object);

			var result = homeController.Index(null, null, null, 1);

			var viewResult = result.Result as ViewResult;

			Assert.AreEqual("Index", viewResult?.ViewName);
		}
	}
}