using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Models
{
    public class RepositoryEmp
    {
        private NorthwindContext _context;
        public RepositoryEmp(NorthwindContext context)
        {
            _context = context;
        }
        public List<Employee> GetAllEmp()
        {
            
                return _context.Employees.ToList();
            
        }
        public Employee GetEmployeeId(int id)
        {
            Employee employee = _context.Employees.Find(id);
            return employee;
        }

        public Employee UpdateEmployee(Employee updatedEmployee)
        {
            _context.Employees.Update(updatedEmployee);
            _context.SaveChanges();
            return updatedEmployee;
        }
        public int AddEmployee(Employee newEmployee)
        {
            _context.Employees.Add(newEmployee);
            return _context.SaveChanges();
        }
       
        public int DeleteEmployee(int id)
        {
            Employee emp = _context.Employees.Find(id);
            _context.Employees.Remove(emp);
            return _context.SaveChanges();
        }
    }
}

