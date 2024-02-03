function ValidarCorreo() {
    $("#btnRecuperar").prop("disabled", true);
    let validarCorreo = $("#Correo").val();

    $.ajax({
        type: "POST",
        url: "/Users/ValidarCorreo",
        dataType: "json",
        data: {
            "validarCorreo": validarCorreo
        },
        success: function (respuesta) {
            if (respuesta != "ERROR") {
                if (respuesta != "") {
                    $("#btnRecuperar").prop("disabled", false);
                }
                else {
                    alert('[ERROR] No existe ninguna cuenta asociada al correo proporcionado');
                    $("#Correo").val("");
                }
            }
        }
    });
}