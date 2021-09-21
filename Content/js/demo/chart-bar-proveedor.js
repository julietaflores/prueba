

var labels = new Array();
var data = new Array();

$.ajax({
    contentType: "application/json; charset=utf-8",
    datatype: "json",
    url: ruta_actual + "/m_proveedor",
    async: false,
    success: function (dataa) {
        $.each(dataa, function (idx, obj) {
            var dry = obj.Nombrec;
            var ry = dry.substr(0, 10);
            labels.push(ry);
            data.push(obj.cantidadc);    
        });


        alert(labels);
     

        $.ajax({
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            url: ruta_actual + "/m_usuario",
            success: function (dataa) {

                $.each(dataa, function (idx, obj) {
                    var dry = obj.Nombrec;
                    var ry = dry.substr(0, 10);
                    labels.push(ry);
                    data.push(obj.cantidadc);

                });


                alert(labels);
                alert(data);


               



            },
            error: function (xhr, status, error) {
                alert("Error Proveedor !!!");
            }
        });



    },
    error: function (xhr, status, error) {
        alert("Error Proveedor !!!");
    }
});







