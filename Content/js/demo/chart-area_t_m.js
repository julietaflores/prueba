// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#858796';

function number_format(number, decimals, dec_point, thousands_sep) {
  // *     example: number_format(1234.56, 2, ',', ' ');
  // *     return: '1 234,56'
  number = (number + '').replace(',', '').replace(' ', '');
  var n = !isFinite(+number) ? 0 : +number,
    prec = !isFinite(+decimals) ? 0 : Math.abs(decimals),
    sep = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep,
    dec = (typeof dec_point === 'undefined') ? '.' : dec_point,
    s = '',
    toFixedFix = function(n, prec) {
      var k = Math.pow(10, prec);
      return '' + Math.round(n * k) / k;
    };
  // Fix for IE parseFloat(0.55).toFixed(0) = 0;
  s = (prec ? toFixedFix(n, prec) : '' + Math.round(n)).split('.');
  if (s[0].length > 0) {
    s[0] = s[0].replace(/\B(?=(?:\d{3})+(?!\d))/g, sep);
  }
  if ((s[1] || '').length < prec) {
    s[1] = s[1] || '';
    s[1] += new Array(prec - s[1].length + 1).join('0');
  }
  return s.join(dec);
}

var labels11= ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
var labels = new Array();
var data = new Array();
$.ajax({
    url: "/RequiereServicios/lista_x_a",
    contentType: "application/json; charset=utf-8",
    datatype: "json",
    async: false,
    success: function (dataa) {
       // alert(data.length);
        $.each(dataa, function (idx, obj) {
 
            var nom = labels11[obj.mes - 1];

            labels.push(nom );
            data.push(obj.cantidad);
        });


    },
    error: function (xhr, status, error) {
        alert("Error menu julietaaaaaaaaa");
    }
});


// Area Chart Example
var ctx = document.getElementById("requi_terminados_mes");
var myLineChart = new Chart(ctx, {
  type: 'line',
  data: {
      labels,
    datasets: [{
      label: "Earnings",
      lineTension: 0.3,
      backgroundColor: "rgba(78, 115, 223, 0.05)",
        borderColor: "#04B404",
      pointRadius: 3,
        pointBackgroundColor: "#04B404",
        pointBorderColor: "#04B404",
      pointHoverRadius: 3,
        pointHoverBackgroundColor: "#04B404",
        pointHoverBorderColor: "#04B404",
      pointHitRadius: 10,
        pointBorderWidth: 2,
      //  data: [2000, 2000, 2000, 2000, 2000, 2000, 4000, 4000, 4000, 10000],
      //data: [0, 10000, 5000, 15000, 10000, 20000, 15000, 25000, 20000, 30000, 25000, 40000],
       data,
    }],
  },
  options: {
    maintainAspectRatio: false,
    layout: {
      padding: {
        left: 10,
        right: 25,
        top: 25,
        bottom: 0
      }
    },
    scales: {
      xAxes: [{
        time: {
          unit: 'date'
        },
        gridLines: {
          display: false,
          drawBorder: false
        },
        ticks: {
          maxTicksLimit: 7
        }
      }],
      yAxes: [{
        ticks: {
          maxTicksLimit: 5,
          padding: 10,
          // Include a dollar sign in the ticks
          callback: function(value, index, values) {
            return number_format(value);
          }
        },
        gridLines: {
            color: "#04B404",
            zeroLineColor: "#04B404",
          drawBorder: false,
          borderDash: [2],
          zeroLineBorderDash: [2]
        }
      }],
    },
    legend: {
      display: false
    },
    tooltips: {
      backgroundColor: "rgb(255,255,255)",
        bodyFontColor: "#04B404",
      titleMarginBottom: 10,
        titleFontColor: '#04B404',
      titleFontSize: 14,
      borderColor: '#dddfeb',
      borderWidth: 1,
      xPadding: 15,
      yPadding: 15,
      displayColors: false,
      intersect: false,
      mode: 'index',
      caretPadding: 10,
      callbacks: {
        label: function(tooltipItem, chart) {
              var datasetLabel = chart.datasets[tooltipItem.datasetIndex].label || '';
              return "total: " + number_format(tooltipItem.yLabel) +" Servicios Terminados";
        }
      }
    }
  }
});
