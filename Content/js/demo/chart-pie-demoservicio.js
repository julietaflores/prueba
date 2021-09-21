// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#858796';


var labels = new Array();
var data = new Array();
$.ajax({
    url: ruta_actual+ "/m_servicio",
    contentType: "application/json; charset=utf-8",
    datatype: "json",
    success: function (dataa) {
        $.each(dataa, function (idx, obj) {
            var drt = obj.cantidadc;
            labels.push(obj.Nombrec);
            data.push(drt);
        });


    },
    error: function (xhr, status, error) {
        alert("Error");
    }
});

var backgroundColor = new Array();
$.ajax({
    url: ruta_actual+"/m_color",
    contentType: "application/json; charset=utf-8",
    datatype: "json",
    success: function (dataa) {
        $.each(dataa, function (idx, obj) {
            backgroundColor.push(obj.Nombrec);
        });


    },
    error: function (xhr, status, error) {
        alert("Error");
    }
});



// Pie Chart Example
var ctx = document.getElementById("myPieChart");
var myPieChart = new Chart(ctx, {
  type: 'doughnut',
  data: {
    labels,
    datasets: [{
        data,
        backgroundColor,
       // backgroundColor: ['#1cc88a', '#A4502E', '#5276C4', '#070F21', '#BC1BD9', '#64D0EC', '#AD213E', '#0FDF0C', '#DAD51E', '#2A0211'],
        hoverBackgroundColor: ['#0FDF0C', '#0FDF0C', '#0FDF0C', '#0FDF0C', '#0FDF0C', '#0FDF0C', '#0FDF0C', '#0FDF0C', '#0FDF0C', '#0FDF0C'],
      hoverBorderColor: "rgba(234, 236, 244, 1)",
    }],
  },
  options: {
    maintainAspectRatio: false,
    tooltips: {
      backgroundColor: "rgb(255,255,255)",
      bodyFontColor: "#858796",
      borderColor: '#dddfeb',
      borderWidth: 1,
      xPadding: 15,
      yPadding: 15,
      displayColors: false,
      caretPadding: 10,
    },
    legend: {
      display: false
    },
    cutoutPercentage: 80,
  },
});
