
function simpsonResult() {
    
    var Parameter = {
        fx: $('#fxi').val(),
        a: $('#a').val(),
        b: $('#b').val(),
        n: $('#n').val(),
        show: function () {
            return "Results for " + this.fx + " a = " + this.a + " b=" + this.b + " c=" + this.n;
        }
    };
    console.log(Parameter);
    if (Parameter.fx === "" || Parameter.a === "" || Parameter.b === "" || Parameter.n === "") {
        alert("Please check all your your inputs");
    } else {
        $.ajax({
            type: "POST",
            datatype: "JSON",
            contentType: 'application/json; charset=utg-8',
            url: "/Home/Integration",
            data: JSON.stringify({
                '_in': Parameter
            }),
            success: function (data) {
                //document.getElementById("tableInfo").innerHTML = Parameter.show(); 
                window.location.href = data.url;
            },
            error: function (data) {
                alert("Please check your input");
            }
        });
    }
    return;
     
}