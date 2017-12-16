using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace GitHubSearchPage.Models
{
    public class GitHubRESTService
    {
        /*
        * This method consumes GitHub's API over HTTP,
        * using a search string from the client.
        * The incoming JSON will be converted to an object of type RepositorySearchResults.
        */
        public RepositorySearchResults GetRepos(string searchString)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create
            ("https://api.github.com/search/repositories?q="+searchString);
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36(KHTML, like Gecko) Chrome/58.0.3029.110 Safari / 537.36";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = string.Empty;
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }
            var releases = JsonConvert.DeserializeObject<RepositorySearchResults>(content);
            return releases;
        }
    }
}