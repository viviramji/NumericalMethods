console.log("conected");

$(document).ready(function () {
    getChart();
});

var data = []; var label = [];
function set(_data, _label) {
    data.push(parseFloat(_in));
    label.push(parseFloat(_label));
}

function GetData() {
    return data;
}

function Getlabel() {
    return label;
}


function getChart() {
    var ctx = document.getElementById("myChart").getContext('2d');
    console.log(ctx);
    var myChart = new Chart(ctx, {
        type: 'line',
        data: {
            //Xs
            labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
            datasets: [{
                label: 'F(x)',
                //F(x)'s
                data: [12, 19, 3, 5, 2, 3],
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)'
                ],
                borderColor: [
                    'rgba(255,99,132,1)'
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