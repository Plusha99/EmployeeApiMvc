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
        public ActionResult Index()
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

        // GET: EmployeeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
