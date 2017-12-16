using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubSearchPage.Models
{
    public class RepositoryViewModel
    {
        public RepositoryViewModel(Repository repo)
        {
            this.RepoId = repo.Id;
            this.RepoName = repo.Name;
            this.RepoAvatarUrl = repo.Owner.Avatar_Url;
        }
        public int RepoId { get; set; }
        public string RepoName { get; set; }
        public string RepoAvatarUrl { get; set; }
    }
}