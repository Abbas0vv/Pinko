using Pinko.Database.Models;
using Pinko.Database.ViewModels;

namespace Pinko.Database.Interfaces;

public interface IEmployeeRepository
{
    public List<Employee> GetAll();
    public List<Employee> GetSome(int value);
    public Employee GetById(int id);
    public void Insert(CreateEmployeeViewModel model);
    public void Update(int id, UpdateEmployeeViewModel model);
    public void Delete(int id);
}
