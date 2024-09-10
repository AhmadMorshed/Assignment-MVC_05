using Company.Data.Entities;
using Company.Services.Interfaces;
using Company.Services.Interfaces.Employee.Dto;
using Company.Services.Services;
using Company.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult Index(string searchInp)
        {
            //ViewBag.Message = "Hello From Employee Index (ViewBag)";
            //ViewData["TextMessage"] = "Hello From Employee Index (ViewData)";
            //TempData["TextMessage"] = "Hello From Employee Index (TempData)";
            IEnumerable<EmployeeDto> employees = new List<EmployeeDto>();
            if (string.IsNullOrEmpty(searchInp))
            {
                employees = _employeeService.GetAll();

            }
            else
            {
                employees = _employeeService.GetEmployeeByName(searchInp);

            }
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _departmentService.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Add(employee);
                }
                return RedirectToAction(nameof(Index));

                ModelState.AddModelError("EmployeeError", "ValidationErrors");

                return View(employee);
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("EmployeeError", ex.Message);
                return View(employee);
            }


        }
        public IActionResult Details(int? id, string viewName = "Details")
        {

            var employee = _employeeService.GetById(id);

            if (employee is null)

                return RedirectToAction("NotFoundPage", null, "Home");

            return View(viewName, employee);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            return Details(id, "Update");
        }
        //[HttpPost]
        //public IActionResult Update(int? id, EmployeeDto employeee)
        //{
        //    if (employeee.DepartmentId != id.Value)
        //        return RedirectToAction("NotFoundPage", null, "Home");
        //    _employeeService.Update(employeee);

        //    return RedirectToAction(nameof(Index));
        //}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);

            if (employee is null)

                return RedirectToAction("NotFoundPage", null, "Home");
            return RedirectToAction(nameof(Index));
        }
    } 
}
