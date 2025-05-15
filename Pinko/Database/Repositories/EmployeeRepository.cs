using Pinko.Database.Interfaces;
using Pinko.Database.Models;
using Pinko.Database.ViewModels;
using Pinko.Helpers.Extentions;

namespace Pinko.Database.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly PinkoDbContext _context;
    private readonly IWebHostEnvironment _environment;
    private const string FOLDER_NAME = "Uploads/Employee";

    public EmployeeRepository(PinkoDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public List<Employee> GetAll()
    {
        return _context.Employees.OrderBy(e => e.Id).ToList();
    }
    public List<Employee> GetSome(int value)
    {
        return _context.Employees.OrderBy(e => e.Id).Take(value).ToList();
    }

    public Employee GetById(int id)
    {
        return _context.Employees.FirstOrDefault(e => e.Id == id);
    }
    public void Insert(EmployeeViewModel model)
    {
        var employee = new Employee()
        {
            Name = model.Name,
            Surname = model.Surname,
            About = model.About,
            Position = model.Position,
            ImageUrl = model.File.CreateFile(_environment.WebRootPath, FOLDER_NAME)
        };

        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public void Update(int id, EmployeeViewModel model)
    {
        var employee = GetById(id);

        employee.Name = model.Name;
        employee.Surname = model.Surname;
        employee.About = model.About;
        employee.Position = model.Position;

        if (model.File != null) 
        employee.ImageUrl = model.File.UpdateFile(_environment.WebRootPath, FOLDER_NAME, employee.ImageUrl);

        _context.Employees.Update(employee);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var employee = GetById(id);
        FileExtention.RemoveFile(Path.Combine(_environment.WebRootPath, FOLDER_NAME, employee.ImageUrl));
        _context.Employees.Remove(employee);
        _context.SaveChanges();
    }
}
