using GitHubSearchPage.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GitHubSearchPage.Controllers
{
    public class HomeController : Controller
    {
        //GitHubRESTService instance will be used to send HTTP requests.
        private GitHubRESTService service = new GitHubRESTService();
        private static RepositorySearchResults results = new RepositorySearchResults();

        public ActionResult Index()
        {
            return View();
        }

        /*
         * This method takes an input string from the user and
         * calls the service with the specified string.
         * Returns a list of RepositoryViewModel
         */
        [HttpPost]
        public JsonResult Search(string searchString)
        {
            if (String.IsNullOrEmpty(searchString))
                return new JsonResult();
            ViewBag.Message = searchString;
            var res = service.GetRepos(searchString);
            results = res;
            return Json(Util.Util.Convert(res));
        }

        /*
         * Get all bookmarks stored in the current session.
         */
        [HttpGet]
        public JsonResult Bookmarks()
        {
            return Json(GetBookmarks(), JsonRequestBehavior.AllowGet);
        }

        /*
         * Add bookmark to the current session.  
         */
        [HttpPost]
        public void AddBookmark(int RepoId)
        {
            var repo = results.Items.Find(r => r.Id == RepoId);
            if (repo == null) return;

            if (Session["repositories"] == null)
            {
                var list = new List<Repository>();
                list.Add(repo);
                Session["repositories"] = list;
            }
            else
            {
                var repositories = Session["repositories"] as List<Repository>;
                if (repositories.Contains(repo)) return;
                repositories.Add(repo);
                Session["repositories"] = repositories;
            }
        }
        /*
         * Get all bookmarks stored in the users session.
         */
        private List<RepositoryViewModel> GetBookmarks()
        {
            var bookmarks = Session["repositories"] as List<Repository>;
            return Util.Util.Convert(bookmarks);
        }
    }
}