
function simpsonResult() {

    var Parameter = {
        fx: $('#fxi').val(),
        a: $('#a').val(),
        b: $('#b').val(),
        n: $('#n').val()
    }
    console.log(Parameter);
    alert("");
    $.ajax({
        type: "POST",
        datatype: "JSON",
        contentType: 'application/json; charset=utg-8',
        url: "/Home/Integration",
        data: JSON.stringify({
            '_in': Parameter
        }),
    });
    $("#partialSimpson").load("/Home/getTableSimpson");
}