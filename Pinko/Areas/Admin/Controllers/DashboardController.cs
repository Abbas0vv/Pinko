using Microsoft.AspNetCore.Mvc;
using Pinko.Database.Repositories;
using Pinko.Database.ViewModels;

namespace Pinko.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    private EmployeeRepository _employeeRepository;

    public DashboardController(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    #region Create
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(EmployeeViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        _employeeRepository.Insert(model);
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Read
    [HttpGet]
    public IActionResult Index()
    {
        var employees = _employeeRepository.GetAll();
        return View(employees);
    } 
    #endregion

    #region Update
    [HttpGet]
    public IActionResult Update(int id)
    {
        var employee = _employeeRepository.GetById(id);
        var model = new EmployeeViewModel()
        {
            Name = employee.Name,
            Surname = employee.Surname,
            About = employee.About,
            Position = employee.Position
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult Update(int id, EmployeeViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        _employeeRepository.Update(id, model);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Delete
    [HttpGet]
    public IActionResult Delete(int id)
    {
        _employeeRepository.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    #endregion
}
