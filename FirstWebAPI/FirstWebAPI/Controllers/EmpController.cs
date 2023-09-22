using FirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private RepositoryEmp _repositoryEmployee;
        public EmpController(RepositoryEmp repository)
        {
            _repositoryEmployee = repository;
        }
        [HttpGet] //annotations
        // GET: EmployeeController

        //view
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = _repositoryEmployee.GetAllEmp();
            return employees;
        }

        //find
        [HttpPost]
        public Employee EmployeeDetails(int id)
        {
            Employee employees = _repositoryEmployee.GetEmployeeId(id);
            return employees;
        }
        //edit 
        [HttpPut]
        public Employee EditEmployee(int id, [FromBody] Employee updatedEmployee)
        {

            updatedEmployee.EmployeeId = id; // Ensure the ID in the URL matches the EmployeeId



            Employee savedEmployee = _repositoryEmployee.UpdateEmployee(updatedEmployee);
            return savedEmployee;
        }
        [HttpDelete("/DeleteEmployee")]
        public string DeleteEmployee(int id)
        {
            int employeestatus = _repositoryEmployee.DeleteEmployee(id);
            if (employeestatus == 0)
            {
                return "Employee does not exist in the Database";
            }
            else
            {
                return "Employee Successfully Deleted";
            }
        }
        [HttpPost("/AddEmployee")]
        public string AddEmployee(Employee newEmployee)
        {
            int employeestatus = _repositoryEmployee.AddEmployee(newEmployee);
            if (employeestatus == 0)
            {
                return "Employee Not Added To Database Since it already exist";
            }
            else
            {
                return "Employee Added To Database";
            }
        }
    }
}
