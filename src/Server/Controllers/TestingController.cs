using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMUD.Server.Data;
using BlazorMUD.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorMUD.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TestingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TestingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<object>> Get()
        {
            return await _context.AreaTemplates.ToListAsync();
        }

        // // GET: api/testbed
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
        // {
        //     return await _context.Users.ToListAsync();
        // }

        // // GET: api/testbed/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<ApplicationUser>> GetApplicationUser(string id)
        // {
        //     var applicationUser = await _context.Users.FindAsync(id);

        //     if (applicationUser == null)
        //     {
        //         return NotFound();
        //     }

        //     return applicationUser;
        // }

        // // PUT: api/testbed/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutApplicationUser(string id, ApplicationUser applicationUser)
        // {
        //     if (id != applicationUser.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(applicationUser).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!ApplicationUserExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // // POST: api/testbed
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<ApplicationUser>> PostApplicationUser(ApplicationUser applicationUser)
        // {
        //     _context.Users.Add(applicationUser);
        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateException)
        //     {
        //         if (ApplicationUserExists(applicationUser.Id))
        //         {
        //             return Conflict();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return CreatedAtAction("GetApplicationUser", new { id = applicationUser.Id }, applicationUser);
        // }

        // // DELETE: api/testbed/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteApplicationUser(string id)
        // {
        //     var applicationUser = await _context.Users.FindAsync(id);
        //     if (applicationUser == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Users.Remove(applicationUser);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool ApplicationUserExists(string id)
        // {
        //     return _context.Users.Any(e => e.Id == id);
        // }
    }
}
