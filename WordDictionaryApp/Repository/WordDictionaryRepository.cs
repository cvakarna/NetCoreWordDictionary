using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WordDictionaryApp.RepositoryContract;

namespace WordDictionaryApp.Repository
{
    public class WordDictionaryRepository : IWordDictionaryRepository
    {
        private  HashSet<string> _dictionaryWords;
        public WordDictionaryRepository()
        {
            _dictionaryWords = new HashSet<string>();
        }
        public async Task CreateWordDictionaryAsync(IFormFile uploadFile)
        {
            List<string> listOfWords = new List<string>();
            using (var reader = new StreamReader(uploadFile.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    var newLine = reader.ReadLine();
                    var stringOfWords = Regex.Split(newLine, @"[' &.,?$+-]+"); //Excluding special characters
                    listOfWords.AddRange(stringOfWords);
                }
            }
            //remove duplicates 
            this._dictionaryWords = listOfWords.ToHashSet();
        }

        public async Task<string> SearchAsync(string input)
        {
            
            if (input != null)
            {
                //Check Whether Given Word Is There Or Not In A Dictionary
                if (this._dictionaryWords.Contains(input))
                {
                    return input;
                }
            }

            return "Sorry!!! Given Word '" + input+"' Not Found.";
        }
    }
}
