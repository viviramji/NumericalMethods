﻿function BisectionResult() {
    var Parameter = {
        fx: $('#fxi').val(),
        a: $('#a').val(),
        b: $('#b').val(),
        n: $('#n').val(),
        t: $('#t').val()
    };
    console.log(Parameter);
    if (Parameter.fx === "" || Parameter.a === "" || Parameter.b === "" || Parameter.n === "" || Parameter.t === "") {
        alert("Please check all your your inputs");
    } else {
        $.ajax({
            type: "POST",
            datatype: "JSON",
            contentType: 'application/json; charset=utg-8',
            url: "/Home/Bisection",
            data: JSON.stringify({
                '_in': Parameter
            }),
            success: function (data) {
                alert("Working on");
                window.location.href = data.url;
            },
            error: function (data) {
                alert("error");
            }
        });
    }
    
    return;
}

//console.log("conected")