using Entity.Entity;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entity.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EntityDbContext dbContext;
            public EmployeeController(EntityDbContext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Employee emp) 
        {
            var employee = new Employee
            {
                Id =emp.Id,
                Name = emp.Name,
                Salary = emp.Salary,
                Email = emp.Email,
                DateOfBirth = emp.DateOfBirth
            };
            dbContext.EmployeeTable.Add(employee);
            dbContext.SaveChanges();
            return RedirectToAction("Add");
        }
    }
}
