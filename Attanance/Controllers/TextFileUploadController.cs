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

            string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fileextension = Path.GetExtension(parent.File.FileName);
            var filename = Guid.NewGuid().ToString() + fileextension;
            var filepath = Path.Combine(assemblyLocation, filename);

            List<string[]> values = new List<string[]>();
            List<string> res = new();
            List<TextFileUpload> textFileUpload = new List<TextFileUpload>();

           // string FileToRead = @"D:\New folder\textfile.txt";
            using (StreamReader ReaderObject = new StreamReader(filename))
            {
                string Line;
                // ReaderObject reads a single line, stores it in Line string variable and then displays it on console
                while ((Line = ReaderObject.ReadLine()) != null)
                {
                    textFileUpload.AddRange((IEnumerable<TextFileUpload>)Line.AsQueryable());
                    //Console.WriteLine(Line);
                }
            }
            foreach( var mak in textFileUpload)
            {
                _db.TextFileUpload.Add(mak);

            }

            _db.SaveChanges();
                           return Ok("successfully Added");
                
        }
    }
}
