using Pinko.Database.Models;
using Pinko.Database.ViewModels;

namespace Pinko.Database.Interfaces;

public interface IEmployeeRepository
{
    public List<Employee> GetAll();
    public Employee GetById(int id);
    public void Insert(EmployeeViewModel model);
    public void Update(int id, EmployeeViewModel model);
    public void Delete(int id);
}
