function ConsultarNombre() {
    let identificacion = $("#Identificacion").val();
    if (identificacion.trim().length >= 8) {
        $.ajax({
            type: "GET",
            url: "https://apis.gometa.org/cedulas/" + identificacion,
            dataType: "json",
            success: function (respuesta) {
                $("#Nombre").val(respuesta.firstname);
                $("#Apellido").val(respuesta.lastname1);
            }
        })
    } else {
        $("#Nombre").val("");
        $("#Apellido").val("");
    }
}

function ValidarCorreo() {
    $("#btnRegistrarme").prop("disabled", true);
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
                if (respuesta == "") {
                    $("#btnRegistrarme").prop("disabled", false);
                }
                else {
                    alert(respuesta);
                }
            }
        }
    });
}

function ValidarConfirmacionContraseña() {
    let password = $("#Contraseña").val();
    let passwordConfirm = $("#ConfirmarContraseña").val();

    if (password.trim() != "" && passwordConfirm.trim()) {
        if (password.trim() != passwordConfirm.trim()) {
            alert('[ERROR] La contraseña ingresada y su confirmación no coinciden, intente de nuevo');
            $("#ConfirmarContraseña").val("");
        }
    }
}

function CheckPhone(phone) {
    let expresionRegular = /^\d{4}-\d{4}$/;
    return expresionRegular.test(phone);
}

function ValidarTelefono() {
    let telefono = $("#Telefono").val();
    if (!CheckPhone(telefono)) {
        alert('[ERROR] El teléfono ingresado no es válido, por favor intente de nuevo');
        $("#Telefono").val("");
    }
}

function ValidarEdad() {
    let edad = $("#Edad").val();
    if (edad != "" && edad < 18) {
        alert('[ERROR] Solamente personas mayores de edad pueden crear una cuenta');
        $("#Edad").val("");
    }
}