using Attanance.Models;
using Attanance.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Attanance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextFileUploadController : ControllerBase
    {
        private readonly AppDbContext _db;

        public TextFileUploadController(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }
        [HttpPost("textfile")]
        public async Task<IActionResult> ParentAllowanceDataUploadExcel([FromForm] TextFileUploadViewModel parent)
        {
            try
            {
                string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var fileextension = Path.GetExtension(parent.File.FileName);
                var filename = Guid.NewGuid().ToString() + fileextension;
                var filepath = Path.Combine(assemblyLocation, filename);
                using (FileStream fs = System.IO.File.Create(filepath))
                {
                    parent.File.CopyTo(fs);
                }
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(string)),
            new DataColumn("Name", typeof(string)),
            new DataColumn("EmployeeCode",typeof(string)),
                });
                List<TextFileUpload> file = new();
                foreach (string row in filepath.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        dt.Rows.Add();
                        int i = 0;
                        foreach (string cell in row.Split(','))
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell;
                            i++;
                            
                        }
                    }
                   // file.AddRange(file);
                }
                _db.TextFileUpload.AddRange(file);
                _db.SaveChanges();
                return Ok("successfully Added");
            }
            catch (Exception ex)
            {
                throw new ($"Failed to Update -{ex.Message}");
            }

        }
    }
}
