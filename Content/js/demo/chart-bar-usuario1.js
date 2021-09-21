




$.ajax({
    contentType: "application/json; charset=utf-8",
    datatype: "json",
    url: ruta_actual1 + "/m_usuario",
    success: function (dataa) {
 
        data = [];
        labels = [];
       
        $.each(dataa, function (idx, obj) {
            var dry = obj.Nombrec;
            var ry = dry.substr(0, 10);
            labels.push(ry);
            data.push(obj.cantidadc);
        });



        var barChartData = {
            labels,
            datasets: [{
                fillColor: "#E3A959",
                strokeColor: "#ffffff",
                highlightFill: "#F09923",
                highlightStroke: "#ffffff",
                data,
            }]
        }
       
         options = {
            responsive: true,
            maintainAspectRatio: false,
            showTooltips: false,
            onAnimationComplete: function () {
                var ctx = this.chart.ctx;
                ctx.font = this.scale.font;
                ctx.fillStyle = this.scale.textColor
                ctx.textAlign = "center";
                ctx.textBaseline = "bottom";
                this.datasets.forEach(function (dataset) {
                    dataset.bars.forEach(function (bar) {
                        ctx.fillText("Total: " + bar.value, bar.x, bar.y);
                    });
                    ip++;
                })
            }
        };

        var ctx31 = document.getElementById("chart-rea31").getContext("2d");;
        var myPie1 = new Chart(ctx31).Bar(barChartData, options);




    },
    error: function (xhr, status, error) {
        alert("Error Proveedor !!!");
    }
});