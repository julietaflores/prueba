
/*var labels11= ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
var labels = new Array();
var data = new Array();

alert(dd +"ola");
*/

/*
$.ajax({
    url: "/RequiereServicios/lista_x_a",
    contentType: "application/json; charset=utf-8",
    datatype: "json",
    async: false,
    success: function (dataa) {
       // alert(data.length);
        $.each(dataa, function (idx, obj) {
            var nom = labels11[obj.mes - 1];
            labels.push(nom);
            data.push(obj.cantidad);
        });
    },
    error: function (xhr, status, error) {
        alert("Error");
    }
});



var barChartData = {
    labels,
    datasets: [{
        fillColor: "#6b9dfa",
        strokeColor: "#ffffff",
        highlightFill: "#1864f2",
        highlightStroke: "#ffffff",
        data,
    }
    ]
}

var options = {
    responsive: true,
    maintainAspectRatio: false,

    showTooltips: false,
    onAnimationComplete: function () {

        var ctx = this.chart.ctx;
        ctx.font = this.scale.font;
        ctx.fillStyle = this.scale.textColor
        ctx.textAlign = "center";
        ctx.textBaseline = "bottom";
        var io = 0;
        this.datasets.forEach(function (dataset) {

            dataset.bars.forEach(function (bar) {
                ctx.fillText("Total: " + bar.value, bar.x, bar.y - 5);
            });
            ip++;
        })
    }
};

var ctx3 = document.getElementById("chart-rea3").getContext("2d");;
var myPie = new Chart(ctx3).Bar(barChartData, options);
*/
