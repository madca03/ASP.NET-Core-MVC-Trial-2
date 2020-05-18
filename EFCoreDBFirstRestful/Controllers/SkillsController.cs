using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreDBFirstRestful.Constants;
using EFCoreDBFirstRestful.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDBFirstRestful.Controllers
{
    public class SkillsController : BaseAPIController
    {
        public SkillsController(EmployeeContext context) : base(context) {}

        // GET: /api/skills
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Index()
        {
            var responseJson = new
            {
                status = APIResponseStatusCodes.SUCCESS,
                result = await db.Skills.ToListAsync()
            };

            return Ok(responseJson);
        }

        // GET: /api/skills/:id
        [HttpGet]
        [Route("api/[controller]/{id:regex(^[[0-9]]+$)}")]
        public async Task<IActionResult> Show(int id)
        {
            var skill = await db.Skills.FindAsync(id);

            if (skill == null) return SendIDNotFoundStatus();

            return SendSuccessStatus(skill);
        }

        // POST: /api/skills
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Create(string title)
        {
            var skill = db.Skills.Where(s => s.Title == title);

            if (skill != null) return SendResourceExists("skill already exists");

            db.Add(new Skills { Title = title });
            await db.SaveChangesAsync();
            return SendSuccessStatus();
        }

        // PUT: /api/skills/:id
        [HttpPut]
        [Route("api/[controller]/{id:regex(^[[0-9]]+$)}")]
        public async Task<IActionResult> Edit(int id, string title)
        {
            var skill = await db.Skills.FindAsync(id);

            if (skill == null) return SendIDNotFoundStatus();

            skill.Title = title;
            db.Update(skill);
            await db.SaveChangesAsync();
            return SendSuccessStatus();
        }

        // DELETE: /api/skills/:id
        [HttpDelete]
        [Route("api/[controller]/{id:regex(^[[0-9]]+$)}")]
        public async Task<IActionResult> Delete(int id)
        {
            var skill = await db.Skills.FindAsync(id);

            if (skill == null) return SendIDNotFoundStatus();

            db.Skills.Remove(skill);
            await db.SaveChangesAsync();
            return SendSuccessStatus();
        }
    }
}