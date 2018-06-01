$(document).ready(function () {
    //table comes from the before view BisectionResult
    var data = []; var label = [];
    for (var i = 0; i < table.length; i++) {
        data.push(table[i].fx);
        label.push(table[i].x);
    }
    getChart(label, data);
});


function getChart(_label, _data) {
    var ctx = document.getElementById("myChart").getContext('2d');
    console.log(ctx);
    var myChart = new Chart(ctx, {
        type: 'line',
        data: {
            //Xs
            labels: _label,
            datasets: [{
                label: 'F(x)',
                //F(x)'s
                data: _data,
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