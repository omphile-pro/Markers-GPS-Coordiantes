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
    public class MarkersController : Controller
    {
        dbsMarkersContext _context = new dbsMarkersContext();
        // GET: Markers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Marker.ToListAsync());
        }

        // GET: Markers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marker = await _context.Marker
                .FirstOrDefaultAsync(m => m.IdentityNo == id);
            if (marker == null)
            {
                return NotFound();
            }

            return View(marker);
        }

        // GET: Markers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Markers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdentityNo,MarkerToken,Name,Surname,Initials,Gender,Title,Persal,MaidenName,Nationality,DeletedDate,DeletedByUsersId,LastModifiedByUsersId,LastModifiedDate,CreatedByUsersId,CreateDate,IsDeleted")] Marker marker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marker);
        }

        // GET: Markers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marker = await _context.Marker.FindAsync(id);
            if (marker == null)
            {
                return NotFound();
            }
            return View(marker);
        }

        // POST: Markers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdentityNo,MarkerToken,Name,Surname,Initials,Gender,Title,Persal,MaidenName,Nationality,DeletedDate,DeletedByUsersId,LastModifiedByUsersId,LastModifiedDate,CreatedByUsersId,CreateDate,IsDeleted")] Marker marker)
        {
            if (id != marker.IdentityNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkerExists(marker.IdentityNo))
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
            return View(marker);
        }

        // GET: Markers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marker = await _context.Marker
                .FirstOrDefaultAsync(m => m.IdentityNo == id);
            if (marker == null)
            {
                return NotFound();
            }

            return View(marker);
        }

        // POST: Markers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marker = await _context.Marker.FindAsync(id);
            _context.Marker.Remove(marker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkerExists(int id)
        {
            return _context.Marker.Any(e => e.IdentityNo == id);
        }
    }
}
