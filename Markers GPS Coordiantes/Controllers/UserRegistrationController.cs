using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Markers_GPS_Coordiantes.Models;

namespace Markers_GPS_Coordiantes.Controllers
{
    public class UserRegistrationController : Controller
    {
        private readonly ApplicationUserClass _context;

        public UserRegistrationController(ApplicationUserClass context)
        {
            _context = context;
        }

        // GET: UserRegistration
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserRegistration.ToListAsync());
        }

        // GET: UserRegistration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRegistration = await _context.UserRegistration
                .FirstOrDefaultAsync(m => m.UsersID == id);
            if (userRegistration == null)
            {
                return NotFound();
            }

            return View(userRegistration);
        }

        // GET: UserRegistration/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserRegistration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsersID,Username,Password,ConfirmPassword,UserEmail,Gender,RolesPermisions")] UserRegistration userRegistration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userRegistration);
        }

        // GET: UserRegistration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRegistration = await _context.UserRegistration.FindAsync(id);
            if (userRegistration == null)
            {
                return NotFound();
            }
            return View(userRegistration);
        }

        // POST: UserRegistration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsersID,Username,Password,ConfirmPassword,UserEmail,Gender,RolesPermisions")] UserRegistration userRegistration)
        {
            if (id != userRegistration.UsersID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userRegistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserRegistrationExists(userRegistration.UsersID))
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
            return View(userRegistration);
        }

        // GET: UserRegistration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRegistration = await _context.UserRegistration
                .FirstOrDefaultAsync(m => m.UsersID == id);
            if (userRegistration == null)
            {
                return NotFound();
            }

            return View(userRegistration);
        }

        // POST: UserRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userRegistration = await _context.UserRegistration.FindAsync(id);
            _context.UserRegistration.Remove(userRegistration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserRegistrationExists(int id)
        {
            return _context.UserRegistration.Any(e => e.UsersID == id);
        }
    }
}
