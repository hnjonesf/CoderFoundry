////site javascript

//if (window.jQuery) {
//    // jQuery is loaded 
//    alert("loaded");
//} else {
//    // jQuery is not loaded
//    alert("not so fast");
//}

var constant = 32;

function celsiusToFarenheit(temperature)
{
    var farenheitTemp = temperature * 9 / 5 + constant;
    return farenheitTemp;
}
input = 33;
output1.innerHTML = " degrees F";

function hypo(a,b)
{
    function square(x)
    {
        return x * x;
    }

    return Math.sqrt(square(a) + square(b));
}

output2.innerHTML = hypo(9,9);
