var latitude;
var longitude;
var map;


function initMap() {


    map = new google.maps.Map(document.getElementById('map'), { //Insére une carte dans le div spécifié par l'id 'map'
        center: {                                               //Place le centre de la carte aux coordonnées spécifiées, ici, Wollongong, Australie
            lat: -34.397,  
            lng: 150.644
        },
        zoom: 10                                                //Niveau du zoom, plus la valeur est grande, plus le zoom est grand
    });
    var infoWindow = new google.maps.InfoWindow({               //Variable permettant de faire apparaitre une infobulle sur la carte
        map: map
    });

    
    if (navigator.geolocation) {                            
        navigator.geolocation.getCurrentPosition(function(position) {
            var pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude

            };
            latitude = position.coords.latitude;
            longitude = position.coords.longitude;
            infoWindow.setPosition(pos);                        //Affiche l'infobulle à la même position que la carte sera centrée

            alert('Position trouvée! Lat: ' + latitude + "   Lon: " + longitude);
             map.setCenter(pos);                               //Centre la carte sur la position actuelle de l'utilisateur
        }, function() {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    } else {
        // Le navigateur ne comprend pas de service de géolocalisation
        handleLocationError(false, infoWindow, map.getCenter());
    }
}

function handleLocationError(browserHasGeolocation, infoWindow, pos) {        //Fonction effectuée à la suite du setCenter(), elle affichera une erreur si un problème
    infoWindow.setPosition(pos);                                              //est survenu
    infoWindow.setContent(browserHasGeolocation ?
        'Erreur: Le service de géolocalisation a échoué' :
        'Erreur: Le navigateur ne comprend pas de fonctionnalité de géolocalisation');
}