using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Markers_GPS_Coordiantes.Data;
using Microsoft.AspNetCore.Http;

namespace Markers_GPS_Coordiantes.Controllers
{
    public class UsersRolesController : Controller
    {
        dbsMarkersContext _context = new dbsMarkersContext();
        private readonly IHttpContextAccessor _sessionAccessor;
        public UsersRolesController(IHttpContextAccessor sessionAccessor)
        {
            _sessionAccessor = sessionAccessor;     //  DEPENDENCY INJECTION
        }
        // GET: UsersRoles
        public async Task<IActionResult> Index()
        {
            var dbsMarkersContext = _context.UsersRole.Include(u => u.CreatedByUsers).Include(u => u.Role).Include(u => u.Users);
            return View(await dbsMarkersContext.ToListAsync());
        }

        // GET: UsersRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersRole = await _context.UsersRole
                .Include(u => u.CreatedByUsers)
                .Include(u => u.Role)
                .Include(u => u.Users)
                .FirstOrDefaultAsync(m => m.UsersRoleId == id);
            if (usersRole == null)
            {
                return NotFound();
            }

            return View(usersRole);
        }

        // GET: UsersRoles/Create
        public IActionResult Create()
        {
            ViewData["CreatedByUsersId"] = new SelectList(_context.Users, "UsersId", "Loginname");
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleDescription");
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Loginname");
            return View();
        }

        // POST: UsersRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VUsersRole usersRole)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //  CREATE A USER FIRST
                    var newUsersRole = new UsersRole()
                    {
                        UsersId = usersRole.UsersId,
                        RoleId = usersRole.RoleId,
                        CreatedByUsersId = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetString("usersID"))
                    };

                    _context.UsersRole.Add(newUsersRole);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex) 
                {
                    //  DO SOMETHING WHEN ERROR OCCURS E.G Send Email
                    Console.WriteLine(ex.Message);
                }
            }
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleDescription", usersRole.RoleId);
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Loginname", usersRole.UsersId);
            return View(usersRole);
        }
        // GET: UsersRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersRole = await _context.UsersRole.FindAsync(id);
            if (usersRole == null)
            {
                return NotFound();
            }
            ViewData["CreatedByUsersId"] = new SelectList(_context.Users, "UsersId", "Loginname", usersRole.CreatedByUsersId);
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleDescription", usersRole.RoleId);
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Loginname", usersRole.UsersId);
            return View(usersRole);
        }

        // POST: UsersRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsersRoleId,UsersId,RoleId,CreatedByUsersId,CreateDate")] UsersRole usersRole)
        {
            if (id != usersRole.UsersRoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usersRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersRoleExists(usersRole.UsersRoleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedByUsersId"] = new SelectList(_context.Users, "UsersId", "Loginname", usersRole.CreatedByUsersId);
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleDescription", usersRole.RoleId);
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Loginname", usersRole.UsersId);
            return View(usersRole);
        }

        // GET: UsersRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersRole = await _context.UsersRole
                .Include(u => u.CreatedByUsers)
                .Include(u => u.Role)
                .Include(u => u.Users)
                .FirstOrDefaultAsync(m => m.UsersRoleId == id);
            if (usersRole == null)
            {
                return NotFound();
            }

            return View(usersRole);
        }

        // POST: UsersRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usersRole = await _context.UsersRole.FindAsync(id);
            _context.UsersRole.Remove(usersRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersRoleExists(int id)
        {
            return _context.UsersRole.Any(e => e.UsersRoleId == id);
        }
    }
}
