using GitHubSearchPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubSearchPage.Util
{
    public class Util
    {
        /*
         * This method converts a RepositorySearchResults instance
         * to a list of RepositoryViewModel.
         */
        public static List<RepositoryViewModel> Convert(RepositorySearchResults results)
        {
            List<RepositoryViewModel> res = new List<RepositoryViewModel>();
            if(results != null && results.Items != null)
            {
                foreach (Repository item in results.Items)
                {
                    res.Add(new RepositoryViewModel(item));
                }
                return res;
            }
            return null;
        }

        /*
         * This method converts List<Repository> instance
         * to a list of RepositoryViewModel.
         */
        public static List<RepositoryViewModel> Convert(List<Repository> list)
        {
            List<RepositoryViewModel> res = new List<RepositoryViewModel>();
            if(list != null)
            {
                foreach (Repository item in list)
                {
                    res.Add(new RepositoryViewModel(item));
                }
                return res;
            }
            return null;
        }
    }
}