// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

function initialize() {
    try {DisableSitting();}
    catch{DisplayTables();}
}

//----------------------------------------------------------------------------------------------------------------------------------------------------------
//                                                                          Side Navbar
//----------------------------------------------------------------------------------------------------------------------------------------------------------

function openNav() {
    
    document.getElementById("mySidenav").style.display = "Block";

    setTimeout(function () { 
        document.getElementById("mySidenav").style.width = "250px";
    }, 10);
}
function closeNav() {
    document.getElementById("mySidenav").style.width = "0px";

    setTimeout(function () { 
        document.getElementById("mySidenav").style.display = "none";
    }, 500);
}

//----------------------------------------------------------------------------------------------------------------------------------------------------------
//                                                                          breakfastAreas
//----------------------------------------------------------------------------------------------------------------------------------------------------------
//disable radio button
function breakfastAreas(SittingStartTime,SittingEndtime) {
    //Hours
    removeOptionsTime();
    if (SittingStartTime === "") { SittingStartTime = 8; }
    if (SittingEndtime === "") { SittingEndtime = 12; }
    PopulateHoursOPt(SittingStartTime, SittingEndtime);
}
//----------------------------------------------------------------------------------------------------------------------------------------------------------
//                                                                          LunchAreas
//----------------------------------------------------------------------------------------------------------------------------------------------------------

function lunchAreas(SittingStartTime, SittingEndtime) {
    //Hours
    removeOptionsTime();
    if (SittingStartTime === "") { SittingStartTime = 12; }
    if (SittingEndtime === "") { SittingEndtime = 17; }
    PopulateHoursOPt(SittingStartTime, SittingEndtime);
}
//----------------------------------------------------------------------------------------------------------------------------------------------------------
//                                                                          dinnerAreas
//----------------------------------------------------------------------------------------------------------------------------------------------------------
function dinnerAreas(SittingStartTime, SittingEndtime) {
    //Hours
    removeOptionsTime();
    if (SittingStartTime === "") { SittingStartTime = 18; }
    if (SittingEndtime === "") { SittingEndtime = 23; }
    PopulateHoursOPt(SittingStartTime, SittingEndtime);
}


//----------------------------------------------------------------------------------------------------------------------------------------------------------
//                                                                          "Semi functions"
//----------------------------------------------------------------------------------------------------------------------------------------------------------

//--------------------------------------------------------------------------checkTime
function checkTime() {
    var now = new Date();
    var HH = now.getHours();
    if (HH <= 11 && HH >= 0) { return 1; } //ALL OPEN
    else if (HH <= 16) { return 2; } //Lunch
    else if (HH <= 22) { return 3; } //Dinner
    else { return 4; } //ALL close
}
//--------------------------------------------------------------------------checkDate
function checkDate() {
    var now = new Date();
    var myDate = document.getElementById("datetimepicker").value;
    var tt = myDate.split("-");
    var today = now.getDate();
    var MM = now.getMonth() + 1;

    if (today < 10) { today = "0" + today; }
    if (MM < 10) { MM = "0" + MM; }
    if (tt[2] === today.toString() && tt[1] === MM.toString()) {
        return true;
    }
    else { return false; }
}
//--------------------------------------------------------------------------Remove past hours (if it is in the same day)
function DisableHours(startTime, Endingtime, optNumb) {
    var isToday = checkDate();
    if (isToday) {
        //get how much time still left
        var now = new Date();
        var h = now.getHours(); //get normal hour
        var m = 60 - now.getMinutes(); //get the mm left
        var list = document.getElementById("StartHours");
        if (h >= Endingtime) {
            for (var b = 0; b < optNumb; b++) {
                list.removeChild(list.childNodes[0]);
            }
            list.removeChild(list.childNodes[0]);
        }
        else if (h >= startTime) {
            h = Endingtime - h - 1;
            var tLeft = h * 60 + m;
            optNumb = optNumb - Math.floor(tLeft / 15);
            //delete unavilable hours  
            for (var c = 0; c < optNumb; c++) {
                list.removeChild(list.childNodes[0]);
            }
        }

    }
}
//--------------------------------------------------------------------------Populate Options with Hours
function PopulateHoursOPt(startTime, Endingtime) {
    removeOptionsTime();
    //display all hours options
    var Finput;
    var period;
    var optNumb = ((Endingtime - startTime) * 60) / 15; //the number of options (Usually is 12) 3 hours / 15 minutes.

    if (startTime < 12) { Finput = startTime; period = " AM"; }
    else if (startTime === 12) { Finput = startTime; period = " PM"; }
    else { Finput = startTime - 12; period = " PM"; }
    if (Finput < 10) { Finput = "0" + Finput; }

    var opt = document.createElement("option");
    opt.innerHTML = Finput + ":00" + period;
    document.getElementById("StartHours").appendChild(opt);
    for (var i = 0; i < optNumb; i++) {
        opt = document.createElement("option");
        var options = document.getElementById("StartHours").children;
        var numb = options[i].innerHTML.split(" ");
        var time = numb[0].split(":");
        var hh = time[0] - 0;
        var mm = time[1] - 0;

        if (mm < 45) { mm += 15; }
        else { hh += 1; mm = 0; }
        if (hh === 13) { hh = 1; }
        if (hh < 10) { hh = "0" + hh; }
        if (mm < 10) { mm = "0" + mm; }

        var hour = hh + ":" + mm + period;
        opt.innerHTML = hour;
        document.getElementById("StartHours").appendChild(opt);
    }
    DisableHours(startTime, Endingtime, optNumb);
}

//--------------------------------------------------------------------------remove ALL Options Time
function removeOptionsTime() {
    //remove all OLD hours options
    var list = document.getElementById("StartHours");
    var OptLength = list.childNodes.length;
    for (var a = 0; a < OptLength; a++) {
        list.removeChild(list.childNodes[0]);
    }
}


//----------------------------------------------------------------------------------------------------------------------------------------------------------
//                                                                          Sittings
//----------------------------------------------------------------------------------------------------------------------------------------------------------
function DisableSitting() {

    var isToday = checkDate();
    if (isToday) {
        removeOptionsTime();
        var sittingTime = checkTime();
        if (sittingTime === 1) { //Break fast
            document.getElementById("Sitting1").disabled = false;
            document.getElementById("Sitting2").disabled = false;
            document.getElementById("Sitting3").disabled = false;
        }
        if (sittingTime === 2) { //Lunch
            document.getElementById("Sitting1").disabled = true;
            document.getElementById("Sitting2").disabled = false;
            document.getElementById("Sitting3").disabled = false;
            document.getElementById("Sitting1").checked = false;

        }
        if (sittingTime === 3) { //Dinner
            document.getElementById("Sitting1").disabled = true;
            document.getElementById("Sitting2").disabled = true;
            document.getElementById("Sitting3").disabled = false;
            document.getElementById("Sitting1").checked = false;
            document.getElementById("Sitting2").checked = false;
        }
        if (sittingTime === 4) { //Dinner
            document.getElementById("Sitting1").disabled = true;
            document.getElementById("Sitting2").disabled = true;
            document.getElementById("Sitting3").disabled = true;
            document.getElementById("Sitting1").checked = false;
            document.getElementById("Sitting2").checked = false;
            document.getElementById("Sitting3").checked = false;
            document.getElementById("errorMessage").innerHTML = "Sorry, the reservations are already closed for today. <br /> Please, pick another day.";
        }
    }
    else {
        document.getElementById("Sitting1").disabled = false;
        document.getElementById("Sitting2").disabled = false;
        document.getElementById("Sitting3").disabled = false;
        document.getElementById("errorMessage").innerHTML = "";
    }
}

//----------------------------------------------------------------------------------------------------------------------------------------------------------
//                                                                          Edit Reservation
//----------------------------------------------------------------------------------------------------------------------------------------------------------

function DisplayTables() {
    var area = document.getElementById("EditArea").value;

    document.getElementById("tableselection").style.display = "block";
    MainRoom("none"); Balcony("none"); OutSide("none");

    if (area === "Main") { MainRoom("inline"); }
    if (area === "Balcony") { Balcony("inline"); }
    if (area === "Outside") { OutSide("inline"); }
}


function MainRoom(d) {
    var m = document.getElementsByClassName("Main");
    for (var i = 0; i < m.length; i++) {
        m[i].style.display = d;
    }
}
function Balcony(d) {
    var b = document.getElementsByClassName("Balcony");
    for (var i = 0; i < b.length; i++) {
        b[i].style.display = d;
    }
}
function OutSide(d) {
    var o = document.getElementsByClassName("Outside");
    for (var i = 0; i < o.length; i++) {
        o[i].style.display = d;
    }
}


function confirm() {
    var input = $("<input />");
    input.attr("type", "hidden").attr("name", "confirm_value");
    if (confirm("Do you want to delete this reservation?")) {
        input.val("Yes");
    } else {
        input.val("No");
    }
    $("form")[0].appendChild(input[0]);
}
