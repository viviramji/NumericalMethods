function simpsonResult() {

    var element = {
        fx : $('#fxi').val(),
        a: $('#a').val(),
        b: $('#b').val(),
        n: $('#n').val()        
    }

    console.log(element);
    alert();
    $.ajax({
        type: "POST",
        datatype: "JSON",
        contentType: 'application/json; charset=utg-8',
        url: "/Home/Integracion",
        data: JSON.stringify({
            '_in': element
        }),        
    });
    $("#tablePartial").load("/Home/getTableSimpson");
}