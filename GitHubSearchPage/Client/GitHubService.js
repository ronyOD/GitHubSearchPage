(function () {
    "use strict";

    angular.module("GitHubApp")
        .service('GitHubService',
        ['$http', function ($http) {

            this.Search = function (searchString) {
                return $http({
                    url: 'Home/Search',
                    method: 'POST',
                    data: { searchString: searchString }
                });
            }

            this.AddBookmark = function (id) {
                return $http({
                    url: 'Home/AddBookmark',
                    method: 'POST',
                    data: { RepoId: id }
                });
            }

            this.GetBookmarks = function () {
                return $http({
                    url: 'Home/Bookmarks',
                    method: 'GET'
                });
            }
        }]);
}());