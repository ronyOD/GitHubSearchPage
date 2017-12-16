using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubSearchPage.Models
{
    public class RepositorySearchResults
    {
        public int Total_Count { get; set; }
        public bool Incomplete_Results { get; set; }
        public List<Repository> Items { get; set; }
    }
}