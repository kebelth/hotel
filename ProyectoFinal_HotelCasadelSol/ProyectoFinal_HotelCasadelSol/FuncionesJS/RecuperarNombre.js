function ConsultarNombre() {
    let identificacion = $("#Identificacion").val();
    if (identificacion.trim().length >= 8) {
        $.ajax({
            type: "GET",
            url: "https://apis.gometa.org/cedulas/" + identificacion,
            dataType: "json",
            success: function (respuesta) {
                if (respuesta.resultcount > 0) {
                    let resultado = respuesta.results[0];
                    $("#Nombre").val(resultado.firstname);
                    $("#Apellido").val(resultado.lastname);
                } else {
                    $("#Nombre").val("");
                    $("#Apellido").val("");
                }
            }
        })
    } else {
        $("#Nombre").val("");
        $("#Apellido").val("");
    }
}