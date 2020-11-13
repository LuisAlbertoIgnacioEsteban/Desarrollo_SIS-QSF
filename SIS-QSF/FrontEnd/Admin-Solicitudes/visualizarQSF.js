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
                    return '<button id="btnSeleccion" type="button" aria-pressed="false" onclick="" "' +
                        ' data-toggle="button" class="btn btn-outline-success"><i class="fas fa-edit"></i></button>'
                        + '<button id="btnSeleccion" type="button" aria-pressed="false" onclick="" "' +
                        ' data-toggle="button" class="btn btn-outline-success"><i class="fas fa-trash-alt"></i></i></button>' +
                         '<button id="btnSeleccion" type="button" aria-pressed="false" onclick="" "' +
                         ' data-toggle="button" class="btn btn-outline-success"><i class="fas fa-search"></i></button>';;
                }
            }    
        ],
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
        $(fila).children("th:eq(8)").html('');
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
        "sLengthMenu": "Mostrar MENU registros",
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


