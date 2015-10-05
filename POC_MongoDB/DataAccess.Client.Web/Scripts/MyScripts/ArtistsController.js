angular.module("ApplicationModule")
    .controller("ArtistsController", [
        "SPACRUDService", "$scope", function(artistsService, $scope) {
            artistsService.getArtists().then(function successArtists(response) {
                $scope.artists = response.data;
            });

        }
    ]);