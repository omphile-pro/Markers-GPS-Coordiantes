using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Markers_GPS_Coordiantes.Data;
using Microsoft.AspNetCore.Authorization;

namespace Markers_GPS_Coordiantes.Controllers
{
    public class UsersController : Controller
    {
        dbsMarkersContext _context = new dbsMarkersContext();

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var dbsMarkersContext = _context.Users.Include(u => u.Center).Include(u => u.Gender).Include(u => u.Role);
            return View(await dbsMarkersContext.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Index(string markerssearch)

        {
            ViewData["GetMarkersDetails"] = markerssearch;

            var markerquery = from x in _context.Users.Include(u => u.Center).Include(u => u.Gender).Include(u => u.Role) select x;
            if (!String.IsNullOrEmpty(markerssearch))
            {
                markerquery = markerquery.Where(x => x.Loginname.Contains(markerssearch) || x.Firstname.Contains(markerssearch) || x.Lastname.Contains(markerssearch));
            }
            return View(await markerquery.AsNoTracking().ToListAsync());
        }
        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.Center)
                .Include(u => u.Gender)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.UsersId == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["CenterId"] = new SelectList(_context.Center, "CenterId", "CenterName");
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "GenderDescription");
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleDescription");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsersId,RoleId,CenterId,UsersToken,Loginname,Password,GenderId,Firstname,Lastname,EmailAddress,MobileNo,Telephone,Displayname,PostalAddress,PhysicalAddress,LastModifiedByUsersId,LastModifiedDate,CreatedByUsersId,CreateDate,IsDeleted")] Users users)
        {
            if (ModelState.IsValid)
            {
                _context.Add(users);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CenterId"] = new SelectList(_context.Center, "CenterId", "CenterName", users.CenterId);
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "GenderDescription", users.GenderId);
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleDescription", users.RoleId);
            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            ViewData["CenterId"] = new SelectList(_context.Center, "CenterId", "CenterName", users.CenterId);
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "GenderDescription", users.GenderId);
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleDescription", users.RoleId);
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsersId,RoleId,CenterId,UsersToken,Loginname,Password,GenderId,Firstname,Lastname,EmailAddress,MobileNo,Telephone,Displayname,PostalAddress,PhysicalAddress,LastModifiedByUsersId,LastModifiedDate,CreatedByUsersId,CreateDate,IsDeleted")] Users users)
        {
            if (id != users.UsersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.UsersId))
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
            ViewData["CenterId"] = new SelectList(_context.Center, "CenterId", "CenterName", users.CenterId);
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "GenderDescription", users.GenderId);
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleDescription", users.RoleId);
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.Center)
                .Include(u => u.Gender)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.UsersId == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _context.Users.FindAsync(id);
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UsersId == id);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
