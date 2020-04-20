﻿using System;
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
    public class MarkersReportController : Controller
    {
        dbsMarkersContext _context = new dbsMarkersContext();

        public IActionResult Index()
        {
            List<VMarkersGpscoordinates> supList = _context.VMarkersGpscoordinates.Select(x => new VMarkersGpscoordinates
            {
                FullName = x.FullName,
                PhysicalAddress = x.PhysicalAddress,
                CentreNumber = x.CentreNumber,
                CenterName = x.CenterName,
                SubjectName = x.SubjectName,
                PaperNumber = x.PaperNumber,
                PositionDescription = x.PositionDescription,
                Distance = x.Distance
            }).ToList();
            return View(supList);
        }

        public async Task<IActionResult> ExportToExcel()
        {
            byte[] result;

            List<VMarkersGpscoordinates> supList = _context.VMarkersGpscoordinates.Select(x => new VMarkersGpscoordinates
            {
                FullName = x.FullName,
                PhysicalAddress = x.PhysicalAddress,
                CentreNumber = x.CentreNumber,
                CenterName = x.CenterName,
                SubjectName = x.SubjectName,
                PaperNumber = x.PaperNumber,
                PositionDescription = x.PositionDescription,
                Distance = x.Distance
            }).ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Reports");

            ws.Cells["A1"].Value = "FullName";
            ws.Cells["B1"].Value = "PhysicalAddress";
            ws.Cells["C1"].Value = "CentreNumber";
            ws.Cells["D1"].Value = "CenterName";
            ws.Cells["E1"].Value = "SubjectName";
            ws.Cells["F1"].Value = "PaperNumber";
            ws.Cells["G1"].Value = "PositionDescription";
            ws.Cells["H1"].Value = "Distance";

            int rowStart = 2;
            foreach (var item in supList)
            {
                // ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;

                ws.Cells[string.Format("A{0}", rowStart)].Value = item.FullName;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.PhysicalAddress;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.CentreNumber;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.CenterName;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.SubjectName;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.PaperNumber;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.PositionDescription;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.Distance;

                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            result = pck.GetAsByteArray();


            return File(result, "application/vnd.ms-excel", "test.xls");
        } public async Task<IActionResult> UsersReport()
            {
            var dbsMarkersContext = _context.VusersReport.OrderBy(g => g.CenterName);
            return View(await dbsMarkersContext.ToListAsync());
        }

        }
    }
