$("#btnMax").click(function (event) {
    var uri = "/api/values/max";
    $.get(uri, { values: $('#max1').val().split(',') }, function (result) {
        $('#results').text(result);
    });
});

$("#btnSum").click(function (event) {
    var uri = "/api/values/sum";
    $.get(uri, { numbers: $('#sum').val().split(',') }, function (result) {
        $('#results').text(result);
    });
});

$("#btnMultiply").click(function (event) {
    var uri = "/api/values/multiply";
    $.get(uri, { numbers: $('#multiply').val().split(',') }, function (result) {
        $('#results').text(result);
    });
});

$("#btnFactorial").click(function (event) {
    var uri = "/api/values/factorial";
    $.get(uri, { numberToFactor: $( '#facNum' ).val() }, function (result) {
        $('#results').text(result);
    });
});

$("#btnisPalindrome").click(function (event) {
    var uri = "/api/values/isPalindrome";
    //$(document.onerror)
    $.get(uri, { value: $('#isPalindrome').val() }, function (result) {
        $('#results').text("True");
    });
});
