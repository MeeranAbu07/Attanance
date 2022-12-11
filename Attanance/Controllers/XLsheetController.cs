using Attanance.Models;
using Attanance.ViewModels;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Attanance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XLsheetController : ControllerBase
    {
        private readonly AppDbContext _db;

        public XLsheetController(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        [HttpPost("Spouse")]
        public async Task<IActionResult> SpouseAllowanceDataUploadExcel([FromForm] FileUploadViewModel request)
        
        {
            
                string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var fileextension = Path.GetExtension(request.File.FileName);
                var filename = Guid.NewGuid().ToString() + fileextension;
                var filepath = Path.Combine(assemblyLocation, filename);
                System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("De-de");
                using (FileStream fs = System.IO.File.Create(filepath))
                {
                    request.File.CopyTo(fs);
                }
                int rowno = 1;
                XLWorkbook workbook = XLWorkbook.OpenFromTemplate(filepath);
                var sheets = workbook.Worksheets.First();
                var rows = sheets.Rows().ToList();
            foreach (var row in rows)
            {
            //    List<string> x = new List<string>();
            //    if(rowno == 1)
            //    {
            //        list = row.Cells().ToList();
            //        x.Add(y);
            //    }
                if (rowno != 1)
                {
                    var test = row.Cell(1).Value.ToString();
                    if (string.IsNullOrWhiteSpace(test) || string.IsNullOrEmpty(test))
                    {
                        break;
                    }
                    MakUser makUser = new MakUser();
                    MakParentDetails makParentDetails = new MakParentDetails();
                    ExcelUserss excelUserss = new ExcelUserss();
                    ExcelAddress address = new ExcelAddress();
                    ExcelHome home = new ExcelHome();
                    MakCollageDeatils makCollageDeatils;

                    // makUser = _db.MakUsers.Where(s => s.Name == row.Cell(2).Value.ToString()).FirstOrDefault();
                    List<string> x = _db.ExcelUsersses.Select(x => x.Uid).ToList();
                    if (makUser == null)
                    {
                        makUser = new MakUser();
                    }
                    //makUser.Id = ;
                    excelUserss.Name = row.Cell(1).Value.ToString();
                    excelUserss.Uid = row.Cell(2).Value.ToString();
                    excelUserss.Age = row.Cell(3).GetValue<Int32>();
                    if(!x.Contains(excelUserss.Uid))
                    {
                        _db.ExcelUsersses.Add(excelUserss);
                        _db.SaveChanges();
                    }
                    
                    address.Uid = excelUserss.Uid;
                    address.Address = row.Cell(5).Value.ToString();
                    address.Aid = row.Cell(4).Value.ToString();
                    _db.excelAddresses.Add(address);
                    _db.SaveChanges();

                    home.Aid = address.Aid;
                    home.RentOrOwn = row.Cell(7).Value.ToString();
                    _db.ExcelHomes.Add(home);
                    _db.SaveChanges();

                }
                else
                {
                    rowno = 2;
                }
            }
                _db.SaveChanges();
                return Ok("successfully Added");
            
            //catch (Exception ex)
            //{
            //    throw new EffismNexGenIdamException($"Failed to Update -{ex.Message}");
            //}

        }
    }
}
