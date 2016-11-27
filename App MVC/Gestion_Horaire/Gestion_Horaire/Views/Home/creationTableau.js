﻿let body;
let events = [];
let HeaderHeight = 30;
let HeaderColumnWidth = 95;
let ScheduleColumnWidth = 115; //!!!!!
let ScheduleColumnHeight = 600 - HeaderHeight;
let b = true;
var app = document.getElementById("app_cvs");

function createDiv(classe) {
    let temp = document.createElement("div")
    temp.className = classe;
    return temp;
}




function creerCanvas() {

    app = document.getElementById("app_cvs");

    app.addEventListener("mousedown", getPosition, false);

    function getPosition(event) {
        let x = event.x;
        let y = event.y;

        let canvas = document.getElementById("app_cvs");

        x -= canvas.offsetLeft;
        y -= canvas.offsetTop;

        console.log("x:" + x + " y:" + y);

        executeEvents(x, y);

    }




}

window.onload = function () {

    loadCanvas(Date.now());



}




function executeEvents(x, y) {

}


function loadCanvas(date) {


    app = document.getElementById("app_cvs");
    let c = app.getContext("2d");



    c.fillStyle = "black";

    c.strokeRect(0, 0, app.width, HeaderHeight);
    c.strokeRect(0, 0, app.width - 1, app.height - 1);

    c.strokeRect(0, 0, HeaderColumnWidth, app.height);



    ScheduleColumnWidth = (app.width - HeaderColumnWidth) / 7;

    c.font = "14px Segoe UI"


    c.strokeStyle = "#DFDFDF";
    c.lineWidth = 1;
    for (var i = 1; i <= 23; i++) {
        c.beginPath();
        c.strokeStyle = "#DFDFDF";
        c.moveTo(1, ((app.height - HeaderHeight) / 23) * i + HeaderHeight)
        c.lineTo(app.width, ((app.height - HeaderHeight) / 23) * i + HeaderHeight)
        c.stroke();
        c.strokeStyle = "black";
        c.textAlign = "center";
        c.fillText(i + ":00", HeaderColumnWidth / 2, ((app.height - HeaderHeight) / 23) * i + HeaderHeight - 7, HeaderColumnWidth - 10);
        c.closePath();
    }

    c.strokeStyle = "black"

    let date_semaine = getLastSunday(date);
    for (var i = 0; i < 7; i++) {


        c.beginPath();

        c.strokeRect(HeaderColumnWidth + (ScheduleColumnWidth * i), 0, ScheduleColumnWidth, app.height);

        c.closePath();

        c.beginPath();

        c.fillText(WeekDays[i] + " " + date_semaine.getDate(), HeaderColumnWidth + (ScheduleColumnWidth * i) + (ScheduleColumnWidth / 2), HeaderHeight - 10, ScheduleColumnWidth);
        c.closePath();
        date_semaine.setDate(date_semaine.getDate() + 1);
    }
    c.save();



    let c1 = app.getContext("2d");
    c1.beginPath();
    c1.strokeStyle = "black"

    c1.moveTo(app.width - 1, 0);
    c1.lineTo(app.width - 1, app.height - 1);
    c1.stroke();
    c1.closePath();

}


function DrawRect(emp, dateDebut, dateFin) {


    let app = document.getElementById("app_cvs");
    let c = app.getContext("2d");
    c.globalCompositeOperation = 'destination-over';


    let posX = HeaderColumnWidth + (dateDebut.getDay() * ScheduleColumnWidth);
    let heureDebut = dateDebut.getHours() + (dateDebut.getMinutes() / 60);
    let heureFin = dateFin.getHours() + (dateFin.getMinutes() / 60);

    let height = app.height * ((heureFin - heureDebut) / 24)
    let posY = (heureDebut / 24) * app.height;


    c.beginPath();
    c.globalCompositeOperation = "color-burn";
    c.fillStyle = "rgba(112,194,228, 0.6)";
    c.strokeStyle = "black";



    c.fillRect(posX + 1, posY, ScheduleColumnWidth - 1, height);
    c.strokeRect(posX + 1, posY, ScheduleColumnWidth - 1, height);
    c.closePath();

    c.beginPath();

    c.globalCompositeOperation = 'source-over';
    c.fillStyle = "black";
    c.font = "13px Segoe UI";
    c.fillText(emp, posX + 5, posY + 12);




    /*
    c.fillRect(posX, 0, posX + ScheduleColumnWidth, 100);
    c.fillRect(100, 100, 100, 100);
    c.strokeRect(100, 100, 100, 100);
    c.strokeRect(100, 150, 100, 100);
    c.strokeRect(100, 170, 100, 100);
    c.fillRect(100, 150, 100, 100);
    c.fillRect(100, 170, 100, 100);
    */

    c.closePath();

}


function refreshApp() {

    let dateFieldContent = document.getElementById("date_sem").value;
    let selected_date = Date.now();
    let next_saturday = Date.now();



    if (!(dateFieldContent == "")) {

        let year, month, day;
        console.log(dateFieldContent);
        year = parseInt(dateFieldContent.split("-")[0]);
        month = parseInt(dateFieldContent.split("-")[1]) - 1;
        day = parseInt(dateFieldContent.split("-")[2]);

        selected_date = new Date(year, month, day);
        selected_date = getLastSunday(selected_date);
        next_saturday = getNextSaturday(selected_date);


        let lbl = document.getElementById("semaine_du");
        lbl.innerHTML = "Semaine du " + selected_date.format() + " au " + next_saturday.format();
    }

    let ct = app.getContext("2d");
    ct.clearRect(0, 0, app.width, app.height);
    //TODO: RETRIEVE DATE FROM DATETIMEPICKER
    let newDate = new Date(document.getElementById("date_sem").value);
    loadCanvas(newDate);

}



function getLastSunday(d) {
    var t = new Date(d);
    t.setDate(t.getDate() - t.getDay());
    console.log("dernier dimanche: " + t);
    return t;
}

function getNextSaturday(d) {
    var t = new Date(d);
    t.setDate(t.getDate() + 6);
    console.log("Prochain samedi: " + t);
    return t;
}



Date.prototype.addDays = function (days) {
    var dat = new Date(this.valueOf());
    dat.setDate(dat.getDate() + days);
    return dat;
}

Date.prototype.format = function () {
    return this.getDate() +
    " " + (monthNames[this.getMonth()]) +
    " " + this.getFullYear();
}

function afficherShifts(shifts) {
    for (var i = shifts.length - 1; i >= 0; i--) {
        DrawRect(shifts[i].Employe, shifts[i].debut, shifts[i].fin);
    }
}