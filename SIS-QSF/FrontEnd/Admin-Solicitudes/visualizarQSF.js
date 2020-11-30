$(document).ready(function () {

    FrontEnd.ws.WSQSF.getAll(function (result) {
        if (result) {
            let datos = JSON.parse(result);
            llenarTabla(datos);
        } else {
            tpl = '<div class="alert alert-danger hide" role="alert">' + "No se logró obtener los datos de las becas" +
                ' <button type="button" class="close" data-dismiss="alert" aria-label="Close">  <span aria-hidden="true">&times;</span>  </button> </div>';
            $('#alert').html(tpl);
        }
    },
        function (error) {


            tpl = '<div class="alert alert-danger hide" role="alert">' + "Error de tipo" + error +
                ' <button type="button" class="close" data-dismiss="alert" aria-label="Close">  <span aria-hidden="true">&times;</span>  </button> </div>';
            $('#alert').html(tpl);
        }
    );

    $("#alert2").hide();


});






function llenarTabla(datos) {
    let idTabla = '#tableQSF';
    $('#tableQSF').DataTable({
        data: datos,
        columns: [
            
            { title: "ClaveQSF", data: "ClaveQSF" },
            { title: "Prioridad", data: "Prioridad" },
            { title: "Estatus", data: "Estatus" },
            { title: "Departamento", data: "Departamento" },
            { title: "Descripcion", data: "Descripcion" },
            { title: "TipoServicio", data: "TipoServicio" },
            { title: "Observaciones", data: "Observaciones" },
            { title: "Fecha", data: "Fecha" },
            { title: "UsuarioSolicitante", data: "UsuarioSolicitante" },

            {
                title: "", data: null, render: function (data, type, row) {
                    return '<button id="btnVer" type="button" onclick="verSolicitud(`' + data.ClaveQSF + '`,`' + data.Prioridad + '`,`' + data.Estatus + '`,`' + data.Departamento + '`,`' + data.Descripcion + '`,`' + data.TipoServicio + '`,`' + data.Observaciones + '`,`' + data.Fecha + '`,`' + data.UsuarioSolicitante +'`)" class="btn btn-success" ><i class="fas fa-eye"></i></button>' +
                        '<button id="btnEditar" type="button" onclick="editarSolicitud(`' + data.ClaveQSF + '`,`' + data.Prioridad + '`,`' + data.Estatus + '`,`' + data.Departamento + '`,`' + data.Descripcion + '`,`' + data.TipoServicio + '`,`' + data.Observaciones + '`,`' + data.Fecha + '`,`' + data.UsuarioSolicitante +'`)" class="btn btn-primary" ><i class="fas fa-pen-square"></i></button>' +
                        '<button id="btnEliminar"  type="button" onclick="eliminarSolicitud(`' + data.ClaveQSF + '`)" class="btn btn-danger" ><i class="fas fa-trash-alt"></i></button>';
                }
            }    
        ],
        "scrollX": true,
        "fnInitComplete": function (oSettings, json) {
            /Configuración de los filtros individuales/
            var fila = $(this).children("thead").children("tr").clone();
        var pie = $("<tfoot/>").append(fila).css("display", "table-header-group");
        $(this).children("thead").after(pie);//Se hace una copia del encabezado en la siguiente fila
        $(fila).children().each(function () {
            $(this).prop("class", null);
        });

        $(fila).children("th").each(function () {//Dar un formato a la fila de busqueda
            var title = $(this).text().toLowerCase();
            $(this).html('<input type="text" class="filtro form-control input-sm" style="width:90%;" placeholder="Buscar ' + title + '" />');
        });
        //Quitar filtro en la ultima columna (la de operaciones)
        $(fila).children("th:eq(9)").html('');
        let tabla = this;
        //Activa el filtrado
        tabla.api().columns().eq(0).each(function (colIdx) {
            $(idTabla + ' tfoot th:eq(' + colIdx + ') input').on('keyup change', function () {
                tabla.api().column(colIdx).search(this.value).draw();
            });

            $('input', tabla.api().column(colIdx).footer()).on('click', function (e) {
                e.stopPropagation();
            });
        });
    },
        'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [0] }],//Quitar el filtrado a una columna
        'order': [[0, 'asc'], [1, 'asc']],//Filtrado
        'language': {
        "sProcessing": "Procesando...",
        "sZeroRecords": "No se encontraron resultados",
        "sEmptyTable": "Ningún dato disponible en esta tabla",
        "sInfo": "Mostrando registros del START al END de un total de TOTAL registros",
        "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
        "sInfoFiltered": "(filtrado de un total de MAX registros)",
        "sInfoPostFix": "",
        "sSearch": "Buscar:",
        "sUrl": "",
        "sInfoThousands": ",",
        "sLoadingRecords": "Cargando...",
        "oPaginate": {
            "sFirst": "Primero",
            "sLast": "Último",
            "sNext": "Siguiente",
            "sPrevious": "Anterior"
        },
        "oAria": {
            "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
            "sSortDescending": ": Activar para ordenar la columna de manera descendente"
        },
        "buttons": {
            "copy": "Copiar",
            "colvis": "Visibilidad"
        }
    }

        
    });
}

//Funcion para llenar el modal mdlVisualizar con los datos de la solictud seleccionada en la tabla
function verSolicitud(ClaveQSF, Prioridad, Estatus, Departamento, Descripcion,
    TipoServicio, Observaciones, Fecha, UsuarioSolicitante) {
    $('#txtClaveQSF_V').val(ClaveQSF);
    $('#txtUsuarioSolicitante_V').val(UsuarioSolicitante);
    $('#txtFecha_V').val(Fecha);
    $('#txtPrioridad_V').val(Prioridad);
    $('#txtEstatus_V').val(Estatus);
    $('#txtTipo_Servicio_V').val(TipoServicio);
    $('#txtDepartamento_V').val(Departamento);
    $('#txtDescripcion_V').val(Descripcion);
    $('#txtObservaciones_V').val(Observaciones);
    $('#mdlVisualizar').modal();
}


var clav = "";
var obs = "";
//variables para correo
var tos = "";
var des = "";
function editarSolicitud(ClaveQSF, Prioridad, Estatus, Departamento, Descripcion,
    TipoServicio, Observaciones, Fecha, UsuarioSolicitante) {

    clav = ClaveQSF;
    tos = TipoServicio;
    des = Descripcion;
    var index = 0;
    $('#txtClaveQSF').val(ClaveQSF);
    $('#txtUsuarioSolicitante').val(UsuarioSolicitante);
    $('#txtFecha').val(Fecha);
    //Seleccionar la opcion del Estatus que corresponda a la solicitud
    if (Prioridad == "Alta") {
        index = 0;
    } else if (Prioridad == "Media") {
        index = 1;
    } else {
        index = 2;
    }

    $("#cboPrioridad option[value=" + index + "]").attr("selected", true);
    //Seleccionar la opcion del Estatus que corresponda a la solicitud
    if (Estatus == "No iniciada") {
        index = 0;
    } else if (Estatus == "En proceso") {
        index = 1;
    } else if (Estatus == "Finalizada") {
        index = 2;
    } else {
        index = 3;
    }

    $('#cboEstatus option[value=' + index + ']').attr("selected", true);
    //Seleccionar la opcion del TipoServicio que corresponda a la solicitud
    if (TipoServicio == "Queja") {
        index = 0;
    } else if (TipoServicio == "Sugerencia") {
        index = 1;
    } else {
        index = 2;
    }
    $('#cboTipo_Servicio option[value=' + index + ']').attr("selected", true);
    //Seleccionar la del Departamento opcion que corresponda a la solicitud
    
    if (Departamento == "Calidad") {
        index = 0;
    } else if (Departamento == "Vinculacion") {
        index = 1;
    } else if (Departamento == "Academico") {
        index = 2;
    } else if (Departamento == "Planeacion") {
        index = 3;
    } else {
        index = 4;
    }


    $("#cboDepartamento option[value=" + index + "]").attr("selected", true);
    $('#txtDescripcion').val(Descripcion);
    $('#txtObservaciones').val(Observaciones);
    $('#mdlEditar').modal();


}




function QSF(Priority, Status, TS, depa) {
    let obj = {};
    obj.Prioridad = Priority;
    obj.Estatus = Status;
    obj.TipoServicio = TS;
    obj.Departamento = depa;
    obj.Observaciones = $('textarea#txtObservaciones').val();
    obj.ClaveQSF = clav;
    
    return JSON.stringify(obj);
}




var cadena = "";
function eliminarSolicitud(ClaveQSF) {
    $("#parrafo").val(ClaveQSF);
    cadena = ClaveQSF;
    $('#mdlEliminar').modal();
    //Mostrar un alert para notificar si fue correcta la eliminacion
}

$("#btnEnviar").click(function () {

    
    Email.send({
        SecureToken: "e13031bc-5cbd-4713-80bf-f22cad113c3f",
        To: $('#txtCorreo').val(),
        From: "Calidad_ITSUR@gmail.com",
        Subject:  tos  ,
        Body:   des 
    }).then(
        message => alert("Correo Enviado")
    );

});

$("#bntborrarServicio").click(function () {
   

    FrontEnd.ws.WSQSF.delete(cadena, function (result) {
        if (result) {
            $("#alert2").show();
            location.reload();
            

        } else {
            tpl = '<div class="alert alert-danger hide" role="alert">' + "Error de tipo" + error +
                ' <button type="button" class="close" data-dismiss="alert" aria-label="Close">  <span aria-hidden="true">&times;</span>  </button> </div>';
            $('#alert').html(tpl);
        }
    },
        function (error) {

            tpl = '<div class="alert alert-danger hide" role="alert">' + "Error de tipo" + error +
                ' <button type="button" class="close" data-dismiss="alert" aria-label="Close">  <span aria-hidden="true">&times;</span>  </button> </div>';
            $('#alert').html(tpl);
        }
    );

});



$("#btnEditar").click(function () {

    FrontEnd.ws.WSQSF.update(QSF(
        $('#cboPrioridad').find('option:selected').text(),
        $('#cboEstatus').find('option:selected').text(),
        $('#cboTipo_Servicio').find('option:selected').text(),
        $('#cboDepartamento').find('option:selected').text()
        
    ), function (result) {
        if (result) {
            
            location.reload();

            //Creacion del Alert que mostrara que el usuario no existe
            tpl = '<div class="alert alert-danger hide" role="alert">' + "Datos Actualizados" +
                ' <button type="button"class="alert alert-success" aria-label="Close">  <span aria-hidden="true">&times;</span>  </button> </div>';
            //El mensaje de error se mostrara en un div con el id " alert "
            $('#alert').html(tpl);
        } else {
            //Creacion del Alert que mostrara que el usuario no existe
            tpl = '<div class="alert alert-danger hide" role="alert">' + "No se pudieron guardar los cambios" +
                ' <button type="button" class="close" data-dismiss="alert" aria-label="Close">  <span aria-hidden="true">&times;</span>  </button> </div>';
            //El mensaje de error se mostrara en un div con el id " alert "
            $('#alert').html(tpl);
        }
    },
        function (error) {
            //Creacion del Alert que mostrara que el usuario no existe
            tpl = '<div class="alert alert-danger hide" role="alert">' + "Error de tipo " + error +
                ' <button type="button" class="close" data-dismiss="alert" aria-label="Close">  <span aria-hidden="true">&times;</span>  </button> </div>';
            //El mensaje de error se mostrara en un div con el id " alert "
            $('#alert').html(tpl);
        }
    );

    
    
    
   
});
