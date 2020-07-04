using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Markers_GPS_Coordiantes.Data;

namespace Markers_GPS_Coordiantes.Controllers
{
    public class CurrentEmploymentsController : Controller
    {
        private readonly dbsMarkersContext _context;

        public CurrentEmploymentsController(dbsMarkersContext context)
        {
            _context = context;
        }

        // GET: CurrentEmployments
        public async Task<IActionResult> Index()
        {
            var dbsMarkersContext = _context.CurrentEmployment.Include(c => c.IdentityNoNavigation);
            return View(await dbsMarkersContext.ToListAsync());
        }

        // GET: CurrentEmployments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentEmployment = await _context.CurrentEmployment
                .Include(c => c.IdentityNoNavigation)
                .FirstOrDefaultAsync(m => m.CurrentEmploymentId == id);
            if (currentEmployment == null)
            {
                return NotFound();
            }

            return View(currentEmployment);
        }

        // GET: CurrentEmployments/Create
        public IActionResult Create()
        {
            ViewData["IdentityNo"] = new SelectList(_context.Marker, "IdentityNo", "IdentityNo");
            return View();
        }

        // POST: CurrentEmployments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CurrentEmploymentId,IdentityNo,NameOftheSchoolOffice,CentreNumber,District,CurrentPosition,EmploymentType,Retiring")] CurrentEmployment currentEmployment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(currentEmployment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityNo"] = new SelectList(_context.Marker, "IdentityNo", "IdentityNo", currentEmployment.IdentityNo);
            return View(currentEmployment);
        }

        // GET: CurrentEmployments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentEmployment = await _context.CurrentEmployment.FindAsync(id);
            if (currentEmployment == null)
            {
                return NotFound();
            }
            ViewData["IdentityNo"] = new SelectList(_context.Marker, "IdentityNo", "IdentityNo", currentEmployment.IdentityNo);
            return View(currentEmployment);
        }

        // POST: CurrentEmployments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CurrentEmploymentId,IdentityNo,NameOftheSchoolOffice,CentreNumber,District,CurrentPosition,EmploymentType,Retiring")] CurrentEmployment currentEmployment)
        {
            if (id != currentEmployment.CurrentEmploymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currentEmployment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrentEmploymentExists(currentEmployment.CurrentEmploymentId))
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
            ViewData["IdentityNo"] = new SelectList(_context.Marker, "IdentityNo", "IdentityNo", currentEmployment.IdentityNo);
            return View(currentEmployment);
        }

        // GET: CurrentEmployments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentEmployment = await _context.CurrentEmployment
                .Include(c => c.IdentityNoNavigation)
                .FirstOrDefaultAsync(m => m.CurrentEmploymentId == id);
            if (currentEmployment == null)
            {
                return NotFound();
            }

            return View(currentEmployment);
        }

        // POST: CurrentEmployments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var currentEmployment = await _context.CurrentEmployment.FindAsync(id);
            _context.CurrentEmployment.Remove(currentEmployment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurrentEmploymentExists(int id)
        {
            return _context.CurrentEmployment.Any(e => e.CurrentEmploymentId == id);
        }
    }
}
