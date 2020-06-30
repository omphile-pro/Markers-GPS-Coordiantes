using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Markers_GPS_Coordiantes.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using OfficeOpenXml;
using RestSharp;
using Markers_GPS_Coordiantes.Enumerators;


namespace Markers_GPS_Coordiantes.Controllers
{
    public class MarkerApplicationReportController : Controller
    {
        dbsMarkersContext _context = new dbsMarkersContext();
        
        public string marker;
        public string seniormarker;
        public string deputychiefmarker;




        public IActionResult Index()
        {
            List<VMarkerApplicationReport> supList = _context.VMarkerApplicationReport.Select(x => new VMarkerApplicationReport
            {
                IdentityNo = x.IdentityNo,
                Surname = x.Surname,
                Subject = x.Subject,
                Language = x.Language,
                Paper = x.Paper,
                Position = x.Position,
                CurrentPosition = x.CurrentPosition,
                QualificationYear = x.QualificationYear,
                QualificationDescription = x.QualificationDescription,
                MojarSubjects=x.QualificationDescription,
                CourseLevel = x.CourseLevel,
                LevelOfDegree= x.CourseLevel,
                LevelOfDiploma= x.LevelOfDiploma,
                TeachingExperience= x.TeachingExperience,
                ExperienceInNcsCaps =x.ExperienceInNcsCaps,
                SubjectExperience = x.SubjectExperience,
                Fetexperience=x.Fetexperience,
                Year=x.Year,
                Expr1= x.Expr1,
                Expr2= x.Expr2,
                Grade = x.Grade,
                NameofschooIInstitution =x.NameofschooIInstitution,
                PercentageofLearners = x.PercentageofLearners,
                YearAvg = x.YearAvg,
                TaughtByAverage= x.TaughtByAverage,
                DistrictYear = x.DistrictYear,
                CandidatesByDistrictPercentage= x.CandidatesByDistrictPercentage,
                PercentageYear=x.PercentageYear,
                ProvincePercentage=x.ProvincePercentage


            }).ToList();
            return View();
        }

        public async Task<IActionResult> ExportToExcel(VMarkerApplicationReport model)
        {
            byte[] result;
            List<VMarkerApplicationReport> reportList = new List<VMarkerApplicationReport>();


            var position = "";
            var subj = "";



            reportList = await _context.VMarkerApplicationReport.Where(b => b.Position == position && b.Subject == subj).ToListAsync();


            List<VMarkerApplicationReport> supList = _context.VMarkerApplicationReport.Select(x => new VMarkerApplicationReport
            {
                IdentityNo = x.IdentityNo,
                Surname = x.Surname,
                Subject = x.Subject,
                Language = x.Language,
                Paper = x.Paper,
                Position = x.Position,
                CurrentPosition = x.CurrentPosition,
                QualificationYear = x.QualificationYear,
                QualificationDescription = x.QualificationDescription,
                MojarSubjects = x.MojarSubjects,
                CourseLevel = x.CourseLevel,
                LevelOfDegree = x.LevelOfDegree,
                LevelOfDiploma = x.LevelOfDiploma,
                TeachingExperience = x.TeachingExperience,
                ExperienceInNcsCaps = x.ExperienceInNcsCaps,
                SubjectExperience = x.SubjectExperience,
                Fetexperience = x.Fetexperience,
                Year = x.Year,
                Expr1 = x.Expr1,
                Expr2 = x.Expr2,
                Grade = x.Grade,
                NameofschooIInstitution = x.NameofschooIInstitution,
                PercentageofLearners = x.PercentageofLearners,
                YearAvg = x.YearAvg,
                TaughtByAverage = x.TaughtByAverage,
                DistrictYear = x.DistrictYear,
                CandidatesByDistrictPercentage = x.CandidatesByDistrictPercentage,
                PercentageYear = x.PercentageYear,
                ProvincePercentage = x.ProvincePercentage,
            }).ToList();


            ExcelPackage pck = new ExcelPackage();
            
            //var sheet = pck.Workbook.Worksheets[1];


            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Marker");
            ExcelWorksheet sm = pck.Workbook.Worksheets.Add("Senior Marker");
            ExcelWorksheet dm = pck.Workbook.Worksheets.Add("Deputy Chief Marker");

            ws.Cells["A1"].Value = "IdentityNo";
            ws.Cells["B1"].Value = "Surname";
            ws.Cells["C1"].Value = "Subject";
            ws.Cells["D1"].Value = "Language";
            ws.Cells["E1"].Value = "Paper";
            ws.Cells["F1"].Value = "Position";
            ws.Cells["G1"].Value = "CurrentPosition";
            ws.Cells["H1"].Value = "QualificationYear";
            ws.Cells["I1"].Value = "QualificationDescription";
            ws.Cells["J1"].Value = "MojarSubjects";
            ws.Cells["K1"].Value = "LevelOfDegree";
            ws.Cells["L1"].Value = "LevelOfDiploma";
            ws.Cells["M1"].Value = "TeachingExperience";
            ws.Cells["N1"].Value = "ExperienceInNcsCaps";
            ws.Cells["O1"].Value = "SubjectExperience";
            ws.Cells["P1"].Value = "Fetexperience";
            ws.Cells["Q1"].Value = "Year";
            ws.Cells["R1"].Value = "Expr1";
            ws.Cells["S1"].Value = "Expr2";
            ws.Cells["T1"].Value = "Grade";
            ws.Cells["U1"].Value = "NameofschooIInstitution";
            ws.Cells["V1"].Value = "PercentageofLearners";
            ws.Cells["W1"].Value = "YearAvg";
            ws.Cells["X1"].Value = "DistrictYear";
            ws.Cells["Y1"].Value = "CandidatesByDistrictPercentage";
            ws.Cells["Z1"].Value = "PercentageYear";
            ws.Cells["Z1"].Value = "ProvincePercentage";

            //Senior Marker
            sm.Cells["A1"].Value = "IdentityNo";
            sm.Cells["B1"].Value = "Surname";
            sm.Cells["C1"].Value = "Subject";
            sm.Cells["D1"].Value = "Language";
            sm.Cells["E1"].Value = "Paper";
            sm.Cells["F1"].Value = "Position";
            sm.Cells["G1"].Value = "CurrentPosition";
            sm.Cells["H1"].Value = "QualificationYear";
            sm.Cells["H1"].Value = "QualificationYear";
            sm.Cells["J1"].Value = "MojarSubjects";
            sm.Cells["K1"].Value = "LevelOfDegree";
            sm.Cells["L1"].Value = "LevelOfDiploma";
            sm.Cells["M1"].Value = "TeachingExperience";
            sm.Cells["N1"].Value = "ExperienceInNcsCaps";
            sm.Cells["O1"].Value = "SubjectExperience";
            sm.Cells["P1"].Value = "Fetexperience";
            sm.Cells["Q1"].Value = "Year";
            sm.Cells["R1"].Value = "Expr1";
            sm.Cells["S1"].Value = "Expr2";
            sm.Cells["T1"].Value = "Grade";
            sm.Cells["U1"].Value = "NameofschooIInstitution";
            sm.Cells["V1"].Value = "PercentageofLearners";
            sm.Cells["W1"].Value = "YearAvg";
            sm.Cells["X1"].Value = "DistrictYear";
            sm.Cells["Y1"].Value = "CandidatesByDistrictPercentage";
            sm.Cells["Z1"].Value = "PercentageYear";
            sm.Cells["Z1"].Value = "ProvincePercentage";

            //Deputy Chief Marker
            dm.Cells["A1"].Value = "IdentityNo";
            dm.Cells["B1"].Value = "Surname";
            dm.Cells["C1"].Value = "Subject";
            dm.Cells["D1"].Value = "Language";
            dm.Cells["E1"].Value = "Paper";
            dm.Cells["F1"].Value = "Position";
            dm.Cells["G1"].Value = "CurrentPosition";
            dm.Cells["H1"].Value = "QualificationYear";
            dm.Cells["H1"].Value = "QualificationYear";
            dm.Cells["J1"].Value = "MojarSubjects";
            dm.Cells["K1"].Value = "LevelOfDegree";
            dm.Cells["L1"].Value = "LevelOfDiploma";
            dm.Cells["M1"].Value = "TeachingExperience";
            dm.Cells["N1"].Value = "ExperienceInNcsCaps";
            dm.Cells["O1"].Value = "SubjectExperience";
            dm.Cells["P1"].Value = "Fetexperience";
            dm.Cells["Q1"].Value = "Year";
            dm.Cells["R1"].Value = "Expr1";
            dm.Cells["S1"].Value = "Expr2";
            dm.Cells["T1"].Value = "Grade";
            dm.Cells["U1"].Value = "NameofschooIInstitution";
            dm.Cells["V1"].Value = "PercentageofLearners";
            dm.Cells["W1"].Value = "YearAvg";
            dm.Cells["X1"].Value = "DistrictYear";
            dm.Cells["Y1"].Value = "CandidatesByDistrictPercentage";
            dm.Cells["Z1"].Value = "PercentageYear";
            dm.Cells["Z1"].Value = "ProvincePercentage";

            int rowStart = 2;
            foreach (var item in reportList)
            {
                // ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;

                ws.Cells[string.Format("A{0}", rowStart)].Value = item.IdentityNo;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.Surname;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Subject;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.Language;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.Paper;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.Position;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.CurrentPosition;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.QualificationYear;
                ws.Cells[string.Format("I{0}", rowStart)].Value = item.QualificationDescription;
                ws.Cells[string.Format("J{0}", rowStart)].Value = item.MojarSubjects;
                ws.Cells[string.Format("K{0}", rowStart)].Value = item.LevelOfDegree;
                ws.Cells[string.Format("L{0}", rowStart)].Value = item.LevelOfDiploma;
                ws.Cells[string.Format("M{0}", rowStart)].Value = item.TeachingExperience;
                ws.Cells[string.Format("N{0}", rowStart)].Value = item.ExperienceInNcsCaps;
                ws.Cells[string.Format("O{0}", rowStart)].Value = item.SubjectExperience;
                ws.Cells[string.Format("P{0}", rowStart)].Value = item.Fetexperience;
                ws.Cells[string.Format("Q{0}", rowStart)].Value = item.Year;
                ws.Cells[string.Format("R{0}", rowStart)].Value = item.Expr1;
                ws.Cells[string.Format("S{0}", rowStart)].Value = item.Expr2;
                ws.Cells[string.Format("T{0}", rowStart)].Value = item.Grade;
                ws.Cells[string.Format("U{0}", rowStart)].Value = item.NameofschooIInstitution;
                ws.Cells[string.Format("V{0}", rowStart)].Value = item.PercentageofLearners;
                ws.Cells[string.Format("W{0}", rowStart)].Value = item.YearAvg;
                ws.Cells[string.Format("X{0}", rowStart)].Value = item.DistrictYear;
                ws.Cells[string.Format("Y{0}", rowStart)].Value = item.CandidatesByDistrictPercentage;
                ws.Cells[string.Format("Z{0}", rowStart)].Value = item.PercentageYear;
                ws.Cells[string.Format("Z{0}", rowStart)].Value = item.ProvincePercentage;

                //Senior Marker
                sm.Cells[string.Format("A{0}", rowStart)].Value = item.IdentityNo;
                sm.Cells[string.Format("B{0}", rowStart)].Value = item.Surname;
                sm.Cells[string.Format("C{0}", rowStart)].Value = item.Subject;
                sm.Cells[string.Format("D{0}", rowStart)].Value = item.Language;
                sm.Cells[string.Format("E{0}", rowStart)].Value = item.Paper;
                sm.Cells[string.Format("F{0}", rowStart)].Value = item.Position;
                sm.Cells[string.Format("G{0}", rowStart)].Value = item.CurrentPosition;
                sm.Cells[string.Format("H{0}", rowStart)].Value = item.QualificationYear;
                sm.Cells[string.Format("I{0}", rowStart)].Value = item.QualificationDescription;
                sm.Cells[string.Format("J{0}", rowStart)].Value = item.MojarSubjects;
                sm.Cells[string.Format("K{0}", rowStart)].Value = item.LevelOfDegree;
                sm.Cells[string.Format("L{0}", rowStart)].Value = item.LevelOfDiploma;
                sm.Cells[string.Format("M{0}", rowStart)].Value = item.TeachingExperience;
                sm.Cells[string.Format("N{0}", rowStart)].Value = item.ExperienceInNcsCaps;
                sm.Cells[string.Format("O{0}", rowStart)].Value = item.SubjectExperience;
                sm.Cells[string.Format("P{0}", rowStart)].Value = item.Fetexperience;
                sm.Cells[string.Format("Q{0}", rowStart)].Value = item.Year;
                sm.Cells[string.Format("R{0}", rowStart)].Value = item.Expr1;
                sm.Cells[string.Format("S{0}", rowStart)].Value = item.Expr2;
                sm.Cells[string.Format("T{0}", rowStart)].Value = item.Grade;
                sm.Cells[string.Format("U{0}", rowStart)].Value = item.NameofschooIInstitution;
                sm.Cells[string.Format("V{0}", rowStart)].Value = item.PercentageofLearners;
                sm.Cells[string.Format("W{0}", rowStart)].Value = item.YearAvg;
                sm.Cells[string.Format("X{0}", rowStart)].Value = item.DistrictYear;
                sm.Cells[string.Format("Y{0}", rowStart)].Value = item.CandidatesByDistrictPercentage;
                sm.Cells[string.Format("Z{0}", rowStart)].Value = item.PercentageYear;
                sm.Cells[string.Format("Z{0}", rowStart)].Value = item.ProvincePercentage;

                //Deputy Chief Marker
                dm.Cells[string.Format("A{0}", rowStart)].Value = item.IdentityNo;
                dm.Cells[string.Format("B{0}", rowStart)].Value = item.Surname;
                dm.Cells[string.Format("C{0}", rowStart)].Value = item.Subject;
                dm.Cells[string.Format("D{0}", rowStart)].Value = item.Language;
                dm.Cells[string.Format("E{0}", rowStart)].Value = item.Paper;
                dm.Cells[string.Format("F{0}", rowStart)].Value = item.Position;
                dm.Cells[string.Format("G{0}", rowStart)].Value = item.CurrentPosition;
                dm.Cells[string.Format("H{0}", rowStart)].Value = item.QualificationYear;
                dm.Cells[string.Format("I{0}", rowStart)].Value = item.QualificationDescription;
                dm.Cells[string.Format("J{0}", rowStart)].Value = item.MojarSubjects;
                dm.Cells[string.Format("K{0}", rowStart)].Value = item.LevelOfDegree;
                dm.Cells[string.Format("L{0}", rowStart)].Value = item.LevelOfDiploma;
                dm.Cells[string.Format("M{0}", rowStart)].Value = item.TeachingExperience;
                dm.Cells[string.Format("N{0}", rowStart)].Value = item.ExperienceInNcsCaps;
                dm.Cells[string.Format("O{0}", rowStart)].Value = item.SubjectExperience;
                dm.Cells[string.Format("P{0}", rowStart)].Value = item.Fetexperience;
                dm.Cells[string.Format("Q{0}", rowStart)].Value = item.Year;
                dm.Cells[string.Format("R{0}", rowStart)].Value = item.Expr1;
                dm.Cells[string.Format("S{0}", rowStart)].Value = item.Expr2;
                dm.Cells[string.Format("T{0}", rowStart)].Value = item.Grade;
                dm.Cells[string.Format("U{0}", rowStart)].Value = item.NameofschooIInstitution;
                dm.Cells[string.Format("V{0}", rowStart)].Value = item.PercentageofLearners;
                dm.Cells[string.Format("W{0}", rowStart)].Value = item.YearAvg;
                dm.Cells[string.Format("X{0}", rowStart)].Value = item.DistrictYear;
                dm.Cells[string.Format("Y{0}", rowStart)].Value = item.CandidatesByDistrictPercentage;
                dm.Cells[string.Format("Z{0}", rowStart)].Value = item.PercentageYear;
                dm.Cells[string.Format("Z{0}", rowStart)].Value = item.ProvincePercentage;

                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            sm.Cells["A:AZ"].AutoFitColumns();
            result = pck.GetAsByteArray();
            var now = DateTime.Now.ToString("yyyy-MM-dd");

            return File(result, "application/vnd.ms-excel", now + ".xlsx" );



        }


    }
}