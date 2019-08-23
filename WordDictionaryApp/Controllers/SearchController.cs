using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WordDictionaryApp.RepositoryContract;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WordDictionaryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : Controller
    {
        readonly IWordDictionaryRepository _wordDict;
        public SearchController(IWordDictionaryRepository wordDict)
        {
            this._wordDict = wordDict;
        }
        [HttpGet]
        public async Task<string> SearchAsync(string searchWord)
        {
            string result = await this._wordDict.SearchAsync(searchWord);
            return result;
        }
    }
}
