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
    public class MarkersGpscoordinatesController : Controller
    {
        dbsMarkersContext _context = new dbsMarkersContext();
        // GET: MarkersGpscoordinates
        public async Task<IActionResult> Index()
        {
            var dbsMarkersContext = _context.MarkersGpscoordinates.Include(m => m.Center).Include(m => m.Exam).Include(m => m.Gender).Include(m => m.Position).Include(m => m.Race).Include(m => m.Subject).Include(m => m.Users);
            return View(await dbsMarkersContext.ToListAsync());
        }

        // GET: MarkersGpscoordinates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markersGpscoordinates = await _context.MarkersGpscoordinates
                .Include(m => m.Center)
                .Include(m => m.Exam)
                .Include(m => m.Gender)
                .Include(m => m.Position)
                .Include(m => m.Race)
                .Include(m => m.Subject)
                .Include(m => m.Users)
                .FirstOrDefaultAsync(m => m.MarkersId == id);
            if (markersGpscoordinates == null)
            {
                return NotFound();
            }

            return View(markersGpscoordinates);
        }

        // GET: MarkersGpscoordinates/Create
        public IActionResult Create()
        {
            ViewData["CenterId"] = new SelectList(_context.Center, "CenterId", "CenterName");
            ViewData["ExamId"] = new SelectList(_context.Exam, "ExamId", "PaperNumber");
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "GenderDescription");
            ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "PositionDescription");
            ViewData["RaceId"] = new SelectList(_context.Race, "RaceId", "RaceDescription");
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectName");
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Loginname");
            return View();
        }

        // POST: MarkersGpscoordinates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MarkersId,SubjectId,CenterId,UsersId,RaceId,ExamId,GenderId,PositionId,CentreNumber,FullName,IdNumber,PhysicalAddress,PostalCode,PersalNumber,WorkTelephone,HomeTelephone,Cellphone,Latitude,Longitude,CreatedDate,CreatedByUsersId")] MarkersGpscoordinates markersGpscoordinates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(markersGpscoordinates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CenterId"] = new SelectList(_context.Center, "CenterId", "CenterName", markersGpscoordinates.CenterId);
            ViewData["ExamId"] = new SelectList(_context.Exam, "ExamId", "PaperNumber", markersGpscoordinates.ExamId);
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "GenderDescription", markersGpscoordinates.GenderId);
            ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "PositionDescription", markersGpscoordinates.PositionId);
            ViewData["RaceId"] = new SelectList(_context.Race, "RaceId", "RaceDescription", markersGpscoordinates.RaceId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectName", markersGpscoordinates.SubjectId);
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Loginname", markersGpscoordinates.UsersId);
            return View(markersGpscoordinates);
        }

        // GET: MarkersGpscoordinates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markersGpscoordinates = await _context.MarkersGpscoordinates.FindAsync(id);
            if (markersGpscoordinates == null)
            {
                return NotFound();
            }
            ViewData["CenterId"] = new SelectList(_context.Center, "CenterId", "CenterName", markersGpscoordinates.CenterId);
            ViewData["ExamId"] = new SelectList(_context.Exam, "ExamId", "PaperNumber", markersGpscoordinates.ExamId);
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "GenderDescription", markersGpscoordinates.GenderId);
            ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "PositionDescription", markersGpscoordinates.PositionId);
            ViewData["RaceId"] = new SelectList(_context.Race, "RaceId", "RaceDescription", markersGpscoordinates.RaceId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectName", markersGpscoordinates.SubjectId);
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Loginname", markersGpscoordinates.UsersId);
            return View(markersGpscoordinates);
        }

        // POST: MarkersGpscoordinates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarkersId,SubjectId,CenterId,UsersId,RaceId,ExamId,GenderId,PositionId,CentreNumber,FullName,IdNumber,PhysicalAddress,PostalCode,PersalNumber,WorkTelephone,HomeTelephone,Cellphone,Latitude,Longitude,CreatedDate,CreatedByUsersId")] MarkersGpscoordinates markersGpscoordinates)
        {
            if (id != markersGpscoordinates.MarkersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(markersGpscoordinates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkersGpscoordinatesExists(markersGpscoordinates.MarkersId))
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
            ViewData["CenterId"] = new SelectList(_context.Center, "CenterId", "CenterName", markersGpscoordinates.CenterId);
            ViewData["ExamId"] = new SelectList(_context.Exam, "ExamId", "PaperNumber", markersGpscoordinates.ExamId);
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "GenderDescription", markersGpscoordinates.GenderId);
            ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "PositionDescription", markersGpscoordinates.PositionId);
            ViewData["RaceId"] = new SelectList(_context.Race, "RaceId", "RaceDescription", markersGpscoordinates.RaceId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectName", markersGpscoordinates.SubjectId);
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Loginname", markersGpscoordinates.UsersId);
            return View(markersGpscoordinates);
        }

        // GET: MarkersGpscoordinates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markersGpscoordinates = await _context.MarkersGpscoordinates
                .Include(m => m.Center)
                .Include(m => m.Exam)
                .Include(m => m.Gender)
                .Include(m => m.Position)
                .Include(m => m.Race)
                .Include(m => m.Subject)
                .Include(m => m.Users)
                .FirstOrDefaultAsync(m => m.MarkersId == id);
            if (markersGpscoordinates == null)
            {
                return NotFound();
            }

            return View(markersGpscoordinates);
        }

        // POST: MarkersGpscoordinates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var markersGpscoordinates = await _context.MarkersGpscoordinates.FindAsync(id);
            _context.MarkersGpscoordinates.Remove(markersGpscoordinates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkersGpscoordinatesExists(int id)
        {
            return _context.MarkersGpscoordinates.Any(e => e.MarkersId == id);
        }
    }
}
