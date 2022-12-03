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
                    TempData["successMessage"] = " Employee created successfuly";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = " Couldn't create an employee ";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                var employee = _context.Employees.SingleOrDefault(x => x.Id == Id);
                if(employee != null)
                {
                    var employeeView = new EmployeeDto()
                    {
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        DateOfBirth = employee.DateOfBirth,
                        Email = employee.Email,
                        Salary = employee.Salary
                    };
                    return View(employeeView);
                }
                else
                {
                    TempData["errorMessage"] = $" Employee details not avalibale with the Id {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(EmployeeDto model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        Id = model.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        DateOfBirth = model.DateOfBirth,
                        Email = model.Email,
                        Salary = model.Salary
                    };
                    _context.Employees.Update(employee);
                    _context.SaveChanges();
                    TempData["successMessage"] = " Model details updated";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["erroeMessage"] = " Model data is invalid";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                var employee = _context.Employees.SingleOrDefault(x => x.Id == Id);
                if(employee != null)
                {
                    var employeeView = new EmployeeDto()
                    {
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        DateOfBirth = employee.DateOfBirth,
                        Email = employee.Email,
                        Salary = employee.Salary
                    };
                    return View(employeeView);
                }
                else
                {
                    TempData["errorMessage"] = $" Employee details not avalibale with the Id {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete(EmployeeDto model)
        {
            try
            {
                var employee = _context.Employees.SingleOrDefault(x => x.Id == model.Id);
                if(employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    TempData["successMessage"] = " Employee deleted";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $" Employee details not avalibale with the Id {model.Id}";
                    return RedirectToAction("Index");
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
