using Microsoft.AspNetCore.Mvc;
using Pinko.Database.Interfaces;
using Pinko.Database.Repositories;

namespace Pinko.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            var employees = _employeeRepository.GetSome(3);
            return View(employees);
        }
    }
}
