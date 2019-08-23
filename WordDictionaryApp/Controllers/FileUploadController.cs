using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordDictionaryApp.RepositoryContract;

namespace WordDictionaryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : Controller
    {

        readonly IWordDictionaryRepository _wordDict;
        public FileUploadController(IWordDictionaryRepository wordDict)
        {
            this._wordDict = wordDict;
        }

        [HttpPost]
        [RequestSizeLimit(209_715_200)]
        public async Task<string> UploadFileAsync([FromForm]List<IFormFile> files)
        {
            try
            {
                if (files.Count == 1)
                {
                    var uploadFile = files[0];
                    await this._wordDict.CreateWordDictionaryAsync(uploadFile);
                }
                else
                {
                    return "Please Upload Only One File...";
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return "File Uploaded.";
            
        }
    }
}