using EmployeeApiMvc.Data;
using EmployeeApiMvc.Models;
using EmployeeApiMvc.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApiMvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DataContext _context;
        public EmployeeController(DataContext context)
        {
            _context = context;
        }
        // GET: EmployeeController1
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            List<EmployeeDto> result = new List<EmployeeDto>();
            if(employees != null)
            {
                foreach(var employee in employees)
                {
                    var Employee = new EmployeeDto()
                    {
                        Id = employee.Id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        DateOfBirth = employee.DateOfBirth,
                        Email = employee.Email,
                        Salary = employee.Salary
                    };
                    result.Add(Employee);
                }
                return View(result);
            }
            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Employee employeeData)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        FirstName = employeeData.FirstName,
                        LastName = employeeData.LastName,
                        DateOfBirth = employeeData.DateOfBirth,
                        Email = employeeData.Email,
                        Salary = employeeData.Salary
                    };

                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Employee created successfuly";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Couldn't create an employee ";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
