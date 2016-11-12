//Script permettant de récupérer les coordonnées GPS à l'aide du navigateur

var latitude;
var longitude;

function afficherPosition() {
    // Condition vérifiant si le navigateur permet la géolocalisation
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function(position) {
            var pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };

            latitude = position.coords.latitude;
            longitude = position.coords.longitude;
            alert('Position trouvée! Lat: ' + latitude + "   Lon: " + longitude);
            
        }, function() {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    } else {
        // Code exécuté si le navigateur ne permet pas la géolocalisation
        handleLocationError(false, infoWindow, map.getCenter());
    }
}




