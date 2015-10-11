
﻿$(document).ready(function () {
    $(function () {
        $('button').click(function GetCompanyName() {
            var xhr;
            if (window.XMLHttpRequest)
                xhr = new XMLHttpRequest();
            else if (window.ActiveXObject)
                xhr = new ActiveXObject("Msxml2.XMLHTTP");
            else
                throw new Error("Ajax is not supported by your browser");
            xhr.onreadystatechange = function () {
                if (xhr.readyState < 4)
                    document.getElementById('CompanyName').innerHTML = "Loading...";
                else if (xhr.readyState === 4) {
                    if (xhr.status == 200 && xhr.status < 300)
                        document.getElementById('CompanyName').innerHTML = xhr.responseText;
                    xhr.open('GET', '/Company/Details/5', true);
                    xhr.send(null);
                };
            };
        });
    });
});

