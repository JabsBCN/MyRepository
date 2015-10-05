var app = angular.module("ApplicationModule");

app.service("SPACRUDService", function ($http) {
    this.getArtists = function() {
        return $http.get("/api/ArtistsAPI");
    };
});