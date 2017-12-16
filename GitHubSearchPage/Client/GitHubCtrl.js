(function () {
    "use strict";

    angular.module('GitHubApp')
        .controller('GitHubCtrl',
        ['$scope', 'GitHubService',
            function ($scope, GitHubService) {

                $scope.hideButton = false;

                $scope.Search = function (searchString) {
                    GitHubService.Search(searchString)
                        .then(successCallback, errorCallback);

                    function successCallback(response) {
                        // show bookmark button
                        $scope.hideButton = false;
                        // store response.data in scope
                        $scope.Repositories = response.data;
                    }
                    function errorCallback(error) {
                        console.log(error);
                    }
                };

                $scope.AddBookmark = function (id) {
                    GitHubService.AddBookmark(id)
                        .then(successCallback, errorCallback);

                    function successCallback(response) {
                        // filter out repo from view
                        $scope.Repositories = $scope.Repositories.filter(repo => repo.RepoId !== id);
                    }
                    function errorCallback(error) {
                        console.log(error);
                    }
                }

                $scope.GetBookmarks = function () {
                    GitHubService.GetBookmarks()
                        .then(successCallback, errorCallback);

                    function successCallback(response) {
                        // hide bookmark button
                        $scope.hideButton = true;
                        // feed view with bookmarked repositories
                        $scope.Repositories = response.data;
                    }
                    function errorCallback(error) {
                        console.log(error);
                    }
                }

                $scope.GoHome = function () {
                    $scope.Repositories = null;
                }

            }]);
}());