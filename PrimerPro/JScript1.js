// JScript source code
//Custom Javascript
function getTotal() {

    //DATE
    //deadline date
    var deadlineDate = new Date(2015, 10, 31, 23, 59, 0);

    //current date
    var currentDate = Date.now();

    //Age 0-2
    var numberOne = document.getElementById("number-one").value;
    var intNumberOne = parseInt(numberOne);
    if (isNaN(intNumberOne)) {
        totalNumberOne = 0;
    }
    else {
        totalNumberOne = intNumberOne * 2000;
        //	if (deadlineDate > currentDate) {
        //		totalNumberOne = intNumberOne * 1500;
        //	}
        //	else {
        //		totalNumberOne = intNumberOne * 2000;
        //	}
    }
    document.getElementById("number-one-total").value = totalNumberOne;

    //Age 3-11
    var numberTwo = document.getElementById("number-two").value;
    var intNumberTwo = parseInt(numberTwo);
    if (isNaN(intNumberTwo)) {
        totalNumberTwo = 0;
    }
    else {
        if (deadlineDate > currentDate) {
            totalNumberTwo = intNumberTwo * 11500;
        }
        else {
            totalNumberTwo = intNumberTwo * 12000;
        }
    }
    document.getElementById("number-two-total").value = totalNumberTwo;

    //Age 12-17
    var numberThree = document.getElementById("number-three").value;
    var intNumberThree = parseInt(numberThree);
    if (isNaN(intNumberThree)) {
        totalNumberThree = 0;
    }
    else {
        if (deadlineDate > currentDate) {
            totalNumberThree = intNumberThree * 17500;
        }
        else {
            totalNumberThree = intNumberThree * 18500;
        }
    }
    document.getElementById("number-three-total").value = totalNumberThree;

    //Adult(18+)
    var numberFour = document.getElementById("number-four").value;
    var intNumberFour = parseInt(numberFour);
    if (isNaN(intNumberFour)) {
        totalNumberFour = 0;
    }
    else {
        if (deadlineDate > currentDate) {
            totalNumberFour = intNumberFour * 23000;
        }
        else {
            totalNumberFour = intNumberFour * 24000;
        }
    }
    document.getElementById("number-four-total").value = totalNumberFour;

    //single room
    var numberFive = document.getElementById("number-five").value;
    var intNumberFive = parseInt(numberFive);
    if (isNaN(intNumberFive)) {
        totalNumberFive = 0;
    }
    else {
        if (deadlineDate > currentDate) {
            totalNumberFive = intNumberFive * 27000;
        }
        else {
            totalNumberFive = intNumberFive * 28000;
        }
    }
    document.getElementById("number-five-total").value = totalNumberFive;


    //sum of the above i.e. total
    var amountOne = parseInt(document.getElementById("number-one-total").value);
    var amountTwo = parseInt(document.getElementById("number-two-total").value);
    var amountThree = parseInt(document.getElementById("number-three-total").value);
    var amountFour = parseInt(document.getElementById("number-four-total").value);
    var amountFive = parseInt(document.getElementById("number-five-total").value);

    var totalAmount = amountOne + amountTwo + amountThree + amountFour + amountFive;

    document.getElementById("total-amount").value = totalAmount;
}

/*
function getTotal() {

var amountOne = document.getElementById("number-one-total").value;

var amountTwo = parseInt(document.getElementById("number-two-total").value);

var amountThree = parseInt(document.getElementById("number-three-total").value);

var amountFour = parseInt(document.getElementById("number-four-total").value);

var amountFive = parseInt(document.getElementById("number-five-total").value);
var totalAmount = amountOne + amountTwo + amountThree + amountFour + amountFive;
document.getElementById("total-amount").value = totalAmount;
alert(amountOne);
}*/