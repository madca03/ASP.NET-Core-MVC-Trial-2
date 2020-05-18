using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreDBFirstRestful.Models;
using EFCoreDBFirstRestful.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDBFirstRestful.Controllers
{
    public class EmployeesController : BaseAPIController
    {
        public EmployeesController(EmployeeContext context) : base(context) {}

        // GET: /api/employees
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Index()
        {
            var query = db.Employees.Join(db.Skills,
                            employee => employee.SkillID,
                            skill => skill.SkillID,
                            (employee, skill) => new EmployeeViewModel
                            {
                                EmployeeID = employee.EmployeeID,
                                EmployeeName = employee.EmployeeName,
                                PhoneNumber = employee.PhoneNumber,
                                Skill = skill.Title,
                                YearsExperience = (int)employee.YearsExperience
                            });

            return SendSuccessStatus(await query.ToListAsync());
        }

        // GET: /api/employees/:id
        [HttpGet]
        [Route("api/[controller]/{id:regex(^[[0-9]]+$)}")]
        public async Task<IActionResult> Show(int id)
        {
            var employeeFromDb = await db.Employees.FindAsync(id);

            if (employeeFromDb == null) return SendIDNotFoundStatus();

            var skill = await db.Skills.FindAsync(employeeFromDb.SkillID);

            var employee = new EmployeeViewModel
            {
                EmployeeID = id,
                EmployeeName = employeeFromDb.EmployeeName,
                PhoneNumber = employeeFromDb.EmployeeName,
                Skill = skill == null ? null : skill.Title,
                YearsExperience = (int)employeeFromDb.YearsExperience
            };

            return SendSuccessStatus(employee);
        }

    }
}