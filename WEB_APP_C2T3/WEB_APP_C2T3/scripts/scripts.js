

var infoWindow;
var TrackPosition = false;



function supprimerAppareil(id) {
    console.log(id + " suppression");
    $.ajax({

        method: "POST",
        url: "/Appareil/supprimerAppareil",
        data: { id_appareil: id }

    })
                             .success(function (result) {
                                 location.href = "/Appareil/Appareils";
                             })
                             .error(function (xhr, status) {
                                 alert(status);
                             })

}


function supprimerRangee(id) {
    console.log(id + " suppression");
    $.ajax({

        method: "POST",
        url: "/GPS/SupprimerEntreeGPS",
        data: {
            id_entree: id
        }

    })
        .success(function (result) {
            location.href = "/Home/Accueil";
        })
        .error(function (xhr, status) {
            alert(status);
        })
}

function resetAlertes() {
    $.ajax({

        method: "POST",
        url: "/Alerte/EffacerAlertes",


    })
        .success(function (result) {
            location.href = "/Home/Accueil";
        })
        .error(function (xhr, status) {
            alert(status);
        })
}

function envoyerAlerte() {
    $.ajax({

        method: "POST",
        url: "/Alerte/EnvoyerAlerte",


    })
        .success(function (result) {
            location.href = "/Home/Accueil";
            
        })
        .error(function (xhr, status) {
            alert(status);
        })
}

function startTracking() {

    console.log($("#id_appareil").val())
    var idInterval = setInterval(function () {

        $.ajax({

            method: "POST",
            url: "/GPS/EnregistrerPosition",

            data: { lat: $("#txtLat").val(), long: $("#txtLong").val(), id_appareil: $("#id_appareil").val() }

        })
                .success(function (result) {
                    
                })
                .error(function (xhr, status) {
                    alert(status);
                })

        $("#last_update").html("<br>Dernière mise à jour: " + new Date().toLocaleString());

    }, 5000);

    $("#btnStartStopTracking").css("background-color", "green");
    $("#btnStartStopTracking").html("Arrêter le Tracking")

}

function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        center: {
            lat: -34.397,
            lng: 150.644
        },
        zoom: 10
    });
    infoWindow = new google.maps.InfoWindow({
        map: map
    });

    // Try HTML5 geolocation.
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude

            };
            latitude = position.coords.latitude;
            longitude = position.coords.longitude;

            infoWindow.setPosition(pos);
            infoWindow.setContent('Position trouvée! Lat: ' + latitude + "   Lon: " + longitude);
            map.setCenter(pos);

            document.getElementById("txtLat").value = latitude;
            document.getElementById("txtLong").value = longitude;

        }, function () {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, map.getCenter());
    }
}

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation ?
        'Error: The Geolocation service failed.' :
        'Error: Your browser doesn\'t support geolocation.');
}


function enregistrerPosition() {
    console.log($("#txtLat").val());
    $.ajax({

        method: "POST",
        url: "/GPS/CreerEntreeGPS",
        data: {
            lat: $("#txtLat").val(),
            long: $("#txtLong").val(),
            id_appareil: $("#id_appareil").val()
        }

    })
    .success(function (result) {
        location.href = "/Home/Accueil";
    })
     .error(function (xhr, status) {
         alert(status);
     })
}