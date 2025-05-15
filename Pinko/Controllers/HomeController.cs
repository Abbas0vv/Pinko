using Microsoft.AspNetCore.Mvc;
using Pinko.Database.Repositories;

namespace Pinko.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;

        public HomeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAll();
            return View(employees);
        }
    }
}
