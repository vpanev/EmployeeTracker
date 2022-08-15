using EmployeeTrackerApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeeTrackerApp.Data;
using Exam.Models;
using Newtonsoft.Json;
using X.PagedList;

namespace EmployeeTrackerApp.Controllers
{
	public class HomeController : Controller
	{
        private static readonly HttpClient Client = new();

        private EmployeeRepository Repository { get; }

        public HomeController(EmployeeRepository repository)
		{
			Repository = repository;
        }

        [HttpPost]
		public async Task<ActionResult> Subscribe(string date)
        {
            DateTime dt;

            var validDate = DateTime.TryParse(
                date,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dt);

            if (!validDate)
            {
                return new BadRequestResult();
            }

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(Utils.GetWebServiceURL(date)),
                Method = HttpMethod.Get,
                Headers =
                {
                    {"Accept-Client", "Fourth-Monitor"}
                }
            };

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseAsJson = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<WebServiceResponse>(responseAsJson);
                Utils.Token = deserialized?.Token;
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
		public async Task<ActionResult> Index(
			string sortOrder,
			string searchString,
			string currentFilter,
			int page = 1)
		{
			ViewData["CurrentSort"] = sortOrder;
			ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
			ViewData["DateSortParam"] = sortOrder == "date_asc" ? "date_desc" : "date_asc";

			if (searchString != null)
			{
				page = 1;
			}
			else
			{
				searchString = currentFilter;
			}

			ViewData["CurrentFilter"] = searchString;

			List<Employee> employees = await Repository.GetEmployeesAsync();

            if (!string.IsNullOrEmpty(searchString))
			{
				employees = employees.Where(e => e.EmployeeId == int.Parse(searchString)).ToList();
			}

            this.SortEmployees(sortOrder, ref employees);

            return View("Index", employees.ToPagedList(page, 10));
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

        public List<Employee> SortEmployees(string sortOrder, ref List<Employee> employees)
        {
            switch (sortOrder)
            {
                case "id_desc":
                    employees = employees.OrderByDescending(e => e.EmployeeId).ToList();
                    break;
                case "date_asc":
                    employees = employees.OrderBy(e => e.When).ToList();
                    break;
                case "date_desc":
                    employees = employees.OrderByDescending(e => e.When).ToList();
                    break;
                default:
                    employees = employees.OrderBy(e => e.EmployeeId).ToList();
                    break;
            }

            return employees;
        }
	}
}
