function BisectionResult() {
    var Parameter = {
        fx: $('#fxi').val(),
        a: $('#a').val(),
        b: $('#b').val(),
        n: $('#n').val(),
        t: $('#t').val()
    };
    console.log(Parameter);
    alert("");
    $.ajax({
        type: "POST",
        datatype: "JSON",
        contentType: 'application/json; charset=utg-8',
        url: "/Home/Bisection",
        data: JSON.stringify({
            '_in': Parameter
        }),
        success: function (data) {
            alert("good");
            window.location.href = data.url;
        },
        error: function (data) {
            alert("error");
        }
    });
}

//console.log("conected")