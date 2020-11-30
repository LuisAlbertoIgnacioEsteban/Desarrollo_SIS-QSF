$(document).ready(function () {
    $('#frmLlenadoSolicitud').bootstrapValidator({
        fields: {
            txtnombre: {
                validators: {
                    notEmpty: {
                        message: 'El nombre del usuario es requerido'
                    }
                }
            },
            txttelefono: {
                validators: {
                    stringLength: {
                        message: 'El telefono debe de contener 10 digitos',
                        min: 10,
                        max: 10,
                        trim: true
                    }
                }
            },
            txtcorreo: {
                validators: {
                    regexp: {
                        regexp: '^[^@\\s]+@([^@\\s]+\\.)+[^@\\s]+$',
                        message: 'El correo no es valido'
                    },
                    notEmpty: {
                        message: 'El correo del usuario es requerido'
                    }
                }
            },
            txtnocontrol: {
                validators: {
                    stringLength: {
                        message: 'La matricula debe de contener 9 caracteres',
                        min: 9,
                        max: 9,
                        trim: true
                    }
                }
            },
            txtdescripcion: {
                validators: {
                    notEmpty: {
                        message: 'La descripcion de la solicitud es requerida'
                    }
                }
            }

        }
    });
});