using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubSearchPage.Models
{
    public class License
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Spdx_Id { get; set; }
        public string Url { get; set; }
    }
}