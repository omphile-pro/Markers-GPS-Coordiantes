using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Markers_GPS_Coordiantes.Data;
using Microsoft.AspNetCore.Http;
using Markers_GPS_Coordiantes.Enumerators;
using System.IO;
using OfficeOpenXml;

namespace Markers_GPS_Coordiantes.Controllers
{
    public class MarkersGpscoordinatesController : Controller
    {

        dbsMarkersContext _context = new dbsMarkersContext();
        IHttpContextAccessor _sessionAccessor;
        int roleID = 0;

        public MarkersGpscoordinatesController(IHttpContextAccessor sessionAccessor)
        {
            _sessionAccessor = sessionAccessor;
        }

        // GET: MarkersGpscoordinates
        public async Task<IActionResult> Index()
        {
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.Administrator && roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK
            try
            {
                var dbsMarkersContext = _context.MarkersGpscoordinates.Include(m => m.Center).Include(m => m.Exam).Include(m => m.Gender).Include(m => m.Position).Include(m => m.Race).Include(m => m.Subject).Include(m => m.Users);
                return View(await dbsMarkersContext.ToListAsync());
            }
            catch (Exception ex) 
            {
                return BadRequest();
            }
        }

        // GET: MarkersGpscoordinates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.Administrator && roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK

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
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.Administrator && roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MarkersId,SubjectId,CenterId,UsersId,RaceId,ExamId,GenderId,PositionId,CentreNumber,FullName,IdNumber,PhysicalAddress,PostalCode,PersalNumber,WorkTelephone,HomeTelephone,Cellphone,Latitude,Longitude,CreatedDate,CreatedByUsersId")] MarkersGpscoordinates markersGpscoordinates)
        {
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.Administrator && roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK

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
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.Administrator && roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarkersId,SubjectId,CenterId,UsersId,RaceId,ExamId,GenderId,PositionId,CentreNumber,FullName,IdNumber,PhysicalAddress,PostalCode,PersalNumber,WorkTelephone,HomeTelephone,Cellphone,Latitude,Longitude,CreatedDate,CreatedByUsersId")] MarkersGpscoordinates markersGpscoordinates)
        {
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.Administrator && roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK
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
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.Administrator && roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK
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
        public IActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Import(IFormFile formFile)
        {
            if (formFile == null || formFile.Length <= 0)
            {
                return Ok("No spreadsheet uploaded");
            }

            if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return Ok("Spreadsheet uploaded is not of type .xlsx");
            }

            var newMarkers = new List<MarkersGpscoordinates>();

            using (var stream = new MemoryStream())
            {
                await formFile.CopyToAsync(stream);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        newMarkers.Add(new MarkersGpscoordinates()
                        {
                            CentreNumber = worksheet.Cells[row, 1].Value.ToString().Trim(),
                            FullName = worksheet.Cells[row, 3].Value.ToString().Trim(),
                            GenderId = (Convert.ToString(worksheet.Cells[row, 3].Value.ToString().Trim().ToLower()) == "male" ? 1 : 2),
                            RaceId = 1,
                            IdNumber = worksheet.Cells[row, 6].Value.ToString().Trim(),
                            SubjectId = 1,
                            PositionId = 1,
                            PhysicalAddress = worksheet.Cells[row, 10].Value.ToString().Trim(),
                            PostalCode = worksheet.Cells[row, 11].Value.ToString().Trim(),
                            PersalNumber = worksheet.Cells[row, 12].Value.ToString().Trim(),
                            WorkTelephone = worksheet.Cells[row, 13].Value.ToString().Trim(),
                            HomeTelephone = worksheet.Cells[row, 14].Value.ToString().Trim(),
                            Cellphone = worksheet.Cells[row, 15].Value.ToString().Trim(),
                            Latitude = Convert.ToDecimal(worksheet.Cells[row, 16].Value.ToString().Trim()),
                            Longitude = Convert.ToDecimal(worksheet.Cells[row, 17].Value.ToString().Trim()),
                            UsersId = 5,
                            ExamId = 4,
                            CreatedByUsersId = 3,
                            CenterId = 3,
                        });
                    }

                    if (newMarkers.Count() > 0)
                    {

                        _context.MarkersGpscoordinates.AddRange(newMarkers);
                        await _context.SaveChangesAsync();
                    }

                    return View("ImportedMarkers", newMarkers);

                }
            }

            // add list to db ..  
            // here just read and return  

            return Ok("Finished");
        }


      



        private bool MarkersGpscoordinatesExists(int id)
        {
            return _context.MarkersGpscoordinates.Any(e => e.MarkersId == id);
        }
    }
}
