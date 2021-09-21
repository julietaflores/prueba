var i = 0; var drt = ""; var canti = 0; var color = ""; 
var dataPTD = new Array();
$.ajax({
    contentType: 'application/json; charset=utf-8',
    dataType: "json",
    url: ruta_actual1 + "/m_servicio",
    success: function (dataa) {
        $.each(dataa, function (idx, obj) {

            drt = obj.Nombrec;
            canti = obj.cantidadc;
     
           
            var objeto = {
                label: drt,
                color: obj.color,
                highlight: drt,
                value: canti
            }
            dataPTD.push(objeto);
            i++;
        });



        var options = {
            responsive: true,
            scaleBeginAtZero: true,
            legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<segments.length; i++){%><li><span style=\"background-color:<%=segments[i].fillColor%>\"></span><%if(segments[i].label){%><%=segments[i].value%> - <%=segments[i].label%><%}%></li><%}%></ul>",
            onAnimationProgress: valorCentral
        }
        Chart.defaults.global.showTooltips = false;


        var ctxPTD = $("#property_types").get(0).getContext("2d");

        var propertyTypes = new Chart(ctxPTD).Pie(dataPTD, options);

        $("#pie_legend").html(propertyTypes.generateLegend());

        function valorCentral() {
            var tooltipEl = $('#chartjs-tooltip');
            tooltipEl.removeClass('above below');
            tooltipEl.addClass(tooltipEl.yAlign);
        }

       // alert(dataPTD);
    },
    error: function (xhr, status, error) {
        alert("Error menu j");
    }
});







