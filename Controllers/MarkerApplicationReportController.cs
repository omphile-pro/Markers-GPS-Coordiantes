//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Markers_GPS_Coordiantes.Data;
//using Microsoft.AspNetCore.Http;
//using System.IO;
//using OfficeOpenXml;
//using RestSharp;
//using Markers_GPS_Coordiantes.Enumerators;
//using System.Diagnostics;

//namespace Markers_GPS_Coordiantes.Controllers
//{
//    public class MarkerApplicationReportController : Controller
//    {
//        payMarkerContext _context = new payMarkerContext();
        
//        public string marker;
//        public string seniormarker;
//        public string deputychiefmarker;




//        public IActionResult Index()
//        {
//            List<VMarkerApplicationReport> supList = _context.VMarkerApplication.Select(x => new VMarkerApplicationReport
//            {
//                IdentityNo = x.IdentityNo,
//                Surname = x.Surname,
//                Subject = x.Subject,
//                Language = x.Language,
//                Paper = x.Paper,
//                Position = x.Position,
//                CurrentPosition = x.CurrentPosition,
//                QualificationYear = x.QualificationYear,
//                QualificationDescription = x.QualificationDescription,
//                MojarSubjects=x.QualificationDescription,
//                CourseLevel = x.CourseLevel,
//                LevelOfDegree= x.CourseLevel,
//                LevelOfDiploma= x.LevelOfDiploma,
//                TeachingExperience= x.TeachingExperience,
//                ExperienceInNcsCaps =x.ExperienceInNcsCaps,
//                SubjectExperience = x.SubjectExperience,
//                Fetexperience=x.Fetexperience,
//                Year=x.Year,
//                Expr1= x.Expr1,
//                Expr2= x.Expr2,
//                Grade = x.Grade,
//                NameofschooIInstitution =x.NameofschooIInstitution,
//                PercentageofLearners = x.PercentageofLearners,
//                YearAvg = x.YearAvg,
//                TaughtByAverage= x.TaughtByAverage,
//                DistrictYear = x.DistrictYear,
//                CandidatesByDistrictPercentage= x.CandidatesByDistrictPercentage,
//                PercentageYear=x.PercentageYear,
//                ProvincePercentage=x.ProvincePercentage


//            }).ToList();
//            return View();
//        }

//        public async Task<IActionResult> ExportToExcel(VMarkerApplicationReport model)
//        {
//            List<VMarkerApplicationReport> reportList = new List<VMarkerApplicationReport>();
//            List<VMarkerApplicationReport> subjectList = new List<VMarkerApplicationReport>();


//            reportList = _context.VMarkerApplicationReport.ToList();

//            var subjects = reportList.Select(x => x.Subject).Distinct();
//            var positions = reportList.Select(x => x.Position).Distinct();

            
//            foreach (string subject in subjects)
//            {
//                ExcelPackage pck = new ExcelPackage();
//                Debug.WriteLine(subject);
                
//                foreach(string posi in positions)
//                {
//                    ExcelWorksheet workSheets = pck.Workbook.Worksheets.Add(posi);

//                    workSheets.Cells["A1"].Value = "IdentityNo";
//                    workSheets.Cells["B1"].Value = "Surname";
//                    workSheets.Cells["C1"].Value = "Subject";
//                    workSheets.Cells["D1"].Value = "Language";
//                    workSheets.Cells["E1"].Value = "Paper";
//                    workSheets.Cells["F1"].Value = "Position";
//                    workSheets.Cells["G1"].Value = "CurrentPosition";
//                    workSheets.Cells["H1"].Value = "QualificationYear";
//                    workSheets.Cells["I1"].Value = "QualificationDescription";
//                    workSheets.Cells["J1"].Value = "MojarSubjects";
//                    workSheets.Cells["K1"].Value = "LevelOfDegree";
//                    workSheets.Cells["L1"].Value = "LevelOfDiploma";
//                    workSheets.Cells["M1"].Value = "TeachingExperience";
//                    workSheets.Cells["N1"].Value = "ExperienceInNcsCaps";
//                    workSheets.Cells["O1"].Value = "SubjectExperience";
//                    workSheets.Cells["P1"].Value = "Fetexperience";
//                    workSheets.Cells["Q1"].Value = "Year";
//                    workSheets.Cells["R1"].Value = "Expr1";
//                    workSheets.Cells["S1"].Value = "Expr2";
//                    workSheets.Cells["T1"].Value = "Grade";
//                    workSheets.Cells["U1"].Value = "NameofschooIInstitution";
//                    workSheets.Cells["V1"].Value = "PercentageofLearners";
//                    workSheets.Cells["W1"].Value = "YearAvg";
//                    workSheets.Cells["X1"].Value = "DistrictYear";
//                    workSheets.Cells["Y1"].Value = "CandidatesByDistrictPercentage";
//                    workSheets.Cells["Z1"].Value = "PercentageYear";
//                    workSheets.Cells["Z1"].Value = "ProvincePercentage";
//                    int rowStart = 2;

//                    var markers = await _context.VMarkerApplicationReport.Where(b => b.Subject == subject && b.Position == posi).ToListAsync();
//                    foreach (var marker in markers)
//                    {
//                        // ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;

//                        workSheets.Cells[string.Format("A{0}", rowStart)].Value = marker.IdentityNo;
//                        workSheets.Cells[string.Format("B{0}", rowStart)].Value = marker.Surname;
//                        workSheets.Cells[string.Format("C{0}", rowStart)].Value = marker.Subject;
//                        workSheets.Cells[string.Format("D{0}", rowStart)].Value = marker.Language;
//                        workSheets.Cells[string.Format("E{0}", rowStart)].Value = marker.Paper;
//                        workSheets.Cells[string.Format("F{0}", rowStart)].Value = marker.Position;
//                        workSheets.Cells[string.Format("G{0}", rowStart)].Value = marker.CurrentPosition;
//                        workSheets.Cells[string.Format("H{0}", rowStart)].Value = marker.QualificationYear;
//                        workSheets.Cells[string.Format("I{0}", rowStart)].Value = marker.QualificationDescription;
//                        workSheets.Cells[string.Format("J{0}", rowStart)].Value = marker.MojarSubjects;
//                        workSheets.Cells[string.Format("K{0}", rowStart)].Value = marker.LevelOfDegree;
//                        workSheets.Cells[string.Format("L{0}", rowStart)].Value = marker.LevelOfDiploma;
//                        workSheets.Cells[string.Format("M{0}", rowStart)].Value = marker.TeachingExperience;
//                        workSheets.Cells[string.Format("N{0}", rowStart)].Value = marker.ExperienceInNcsCaps;
//                        workSheets.Cells[string.Format("O{0}", rowStart)].Value = marker.SubjectExperience;
//                        workSheets.Cells[string.Format("P{0}", rowStart)].Value = marker.Fetexperience;
//                        workSheets.Cells[string.Format("Q{0}", rowStart)].Value = marker.Year;
//                        workSheets.Cells[string.Format("R{0}", rowStart)].Value = marker.Expr1;
//                        workSheets.Cells[string.Format("S{0}", rowStart)].Value = marker.Expr2;
//                        workSheets.Cells[string.Format("T{0}", rowStart)].Value = marker.Grade;
//                        workSheets.Cells[string.Format("U{0}", rowStart)].Value = marker.NameofschooIInstitution;
//                        workSheets.Cells[string.Format("V{0}", rowStart)].Value = marker.PercentageofLearners;
//                        workSheets.Cells[string.Format("W{0}", rowStart)].Value = marker.YearAvg;
//                        workSheets.Cells[string.Format("X{0}", rowStart)].Value = marker.DistrictYear;
//                        workSheets.Cells[string.Format("Y{0}", rowStart)].Value = marker.CandidatesByDistrictPercentage;
//                        workSheets.Cells[string.Format("Z{0}", rowStart)].Value = marker.PercentageYear;
//                        workSheets.Cells[string.Format("Z{0}", rowStart)].Value = marker.ProvincePercentage;
//                        rowStart++;
//                    }
//                    workSheets.Cells["A:AZ"].AutoFitColumns();

//                }

//                string filePath = "C:\\Users/Rendani Mulaudzi/Desktop/Files/" + subject + ".xlsx";

//                FileInfo fi = new FileInfo(filePath);
//                pck.SaveAs(fi);
//            }
//            return View("~/Views/True/MarkersReport.cshtml");
//        }


//    }
//}