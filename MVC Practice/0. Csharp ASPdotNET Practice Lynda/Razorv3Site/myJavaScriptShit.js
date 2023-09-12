var textaria = document.getElementById("mytext");
var count =0;


document.onclick = function () {
    count++;
    textaria.style.visibility = "visible";
    textaria.innerHTML = "you\nyou clicked me >>>  "+count+" times.";
}

var lable1 = document.getElementById("lable1");
var lable2 = document.getElementById("lable2");
var lable3 = document.getElementById("lable3");


lable1.onclick= function() {
    alert("you clicked " + lable1.innerHTML);
}

lable2.onclick = function () {
    alert("you clicked " + lable2.innerHTML);
}
lable3.onclick = function () {
    alert("you clicked " + lable3.innerHTML);
}