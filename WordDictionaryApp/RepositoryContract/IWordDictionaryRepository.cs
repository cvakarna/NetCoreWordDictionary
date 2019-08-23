using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordDictionaryApp.RepositoryContract
{
    public interface IWordDictionaryRepository
    {
        /// <summary>
        /// Method To Create A Create Word Dictionary By Uploading A File 
        /// </summary>
        /// <param name="uploadFile">Uploaded File</param>
        /// <returns></returns>
        Task CreateWordDictionaryAsync(IFormFile uploadFile);

        /// <summary>
        /// Method To Search A Given Word In A Dictionary and Return Value If Found
        /// </summary>
        /// <param name="word">search word</param>
        /// <returns>Value in a Dictionary</returns>
        Task<string> SearchAsync(string word);
    }
}
