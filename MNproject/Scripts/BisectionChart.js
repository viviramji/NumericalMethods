console.log("conected");

$(document).ready(function () {
    
    console.log(table.length);
    var data = []; var label = [];
    for (var i = 0; i < table.length; i++) {
        data.push(table[i].fx);
        label.push(table[i].x);
    }
    getChart(label, data);
});


function getChart(_data, _label) {
    var ctx = document.getElementById("myChart").getContext('2d');
    console.log(ctx);
    var myChart = new Chart(ctx, {
        type: 'line',
        data: {
            //Xs
            labels: [-4,-2,0,2,4,5],
            datasets: [{
                label: 'F(x)',
                //F(x)'s
                data: [-4, -2, 0, 2, 4, 5],
                backgroundColor: [
                    'rgba(105,181,120, 0.2)'
                ],
                borderColor: [
                    'rgba(58,125,68, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {

            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}  