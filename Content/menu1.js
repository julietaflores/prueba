
$.ajax({
    contentType: 'application/json; charset=utf-8',
    dataType: "json",
    type: "get",
        url: ws +"/api/DatosWebAdmin?userid="+idu,
    success: function (data) {
        var arrayy = data.valor;
       

        $.each(arrayy, function (idx1, obj1) {
            var nombreadminn = obj1.UserName;
         
            $('#nom_user').text(nombreadminn);

            $.each(obj1.MenuSistemaWebSW, function (idx, obj) {
                if (obj.NameMA == "Inicio") {

                    $("#menudash").append(
                        "<a class='sidebar-brand d-flex align-items-center justify-content-center' " + "href=" + "'" + "/" + obj.Nom_Direccion + "'>" +
                        "<div class='sidebar-brand-text mx-3'>Service Web</div>" +
                        "</a>"
                    );



                    $("#menuD").append(
                        "<li class='nav-item active'>" +
                        "<a class='nav-link' " + "href=" + "'" + "/" + obj.Nom_Direccion + "'>" +
                        "<i class='fas fa-fw fa-tachometer-alt'></i>" +
                        "<span>" + obj.NameMA + "</span>" +
                        "</a>" +
                        "</li>"
                    );
                } else {
                    $("#menu").append("<li class='nav-item '>" +
                        "<a class='nav-link' " + "href=" + "'" + "/" + obj.Nom_Direccion + "'>" +
                        "<i class='fas fa-fw fa-folder'></i>" +
                        "<span>" + obj.NameMA + "</span>" +
                        "</a>" +

                        "</li>");
                }
            });

        });

        


        },
        error: function (xhr, status, error) {
            alert("Error menu julietaaaaaaaaa");
        }
    });


function salir() {
    location.href = "/Detalle/Logout";
}