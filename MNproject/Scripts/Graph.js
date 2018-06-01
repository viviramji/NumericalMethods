console.log("Im conect to the graph view")

function GraphForm() {
    var Parameter = {
        fx: $('#fxi').val(),
        a: $('#a').val(),
        b: $('#b').val(),
        n: $('#n').val()
    };
    console.log(Parameter);
    if (Parameter.fx === "" || Parameter.a === "" || Parameter.b === "" || Parameter.n === "") {
        alert("Please check all your your inputs");
    } else {
        $.ajax({
            type: "POST",
            datatype: "JSON",
            contentType: 'application/json; charset=utg-8',
            url: "/Home/Graph",
            data: JSON.stringify({
                '_in': Parameter
            }),
            success: function (data) {
                alert("Working on");
                window.location.href = data.url;
            },
            error: function (data) {
                alert("Please check your input");
            }
        });
    }
    return;
}