function Evaluate() {
    var Parameter = {
        fx: $('#fxi').val(),
        a: $('#x').val(), //el valor ingresado por el usuario entra al atributo a del objeto Parameter
        //no se necesitan los demas atributos
        b: "", 
        n: ""
    };
    console.log(Parameter);
    if (Parameter.fx === "" || Parameter.a == "") {
        alert("Please check all your your inputs");
    } else {
        $.ajax({
            type: "POST",
            datatype: "JSON",
            contentType: 'application/json; charset=utg-8',
            url: "/Home/Evaluate",
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