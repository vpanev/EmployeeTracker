using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeTrackerApp.Data;
using Exam.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackerApp.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class WebHookController : ControllerBase
    {
        private EmployeeRepository Repository { get; }

        public WebHookController(EmployeeRepository repository)
        {
            Repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult> Post(List<Employee> value)
        {
            if (Request.Headers["X-Fourth-Token"] != Utils.Token)
                return Unauthorized();

            await Repository.AddEmployeesAsync(value);

            return RedirectToAction("Index", "Home");
        }
    }
}
