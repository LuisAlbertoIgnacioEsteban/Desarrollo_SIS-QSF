$(document).ready(function () {

    let tabla = $('#grvQSF');
    //Obtengo la fila de los encabezados en el gridview colocó en el tbody (la primera)
    let fila = $(tabla).find("tbody tr:first").clone();
    //La elimino del tbody
    $(tabla).find("tbody tr:first").remove();
    //Creo un elemento thead y le añado la fila de encabezados
    let encabezado = $("<thead/>").append(fila);
    //Añado el thead a la tabla antes del tbody
    $(tabla).children('tbody').before(encabezado);
    //Activamos el plugin
    $('#grvQSF').DataTable();

    
    FrontEnd.ws.WSQSF.getAll(function (result) {
        if (result) {
            let datos = JSON.parse(result);
            cargarDatos(datos);
        } else {

            //Creacion del Alert que mostrara que el usuario no existe
            tpl = '<div class="alert alert-danger hide" role="alert">' + "No se lograron obtener los datos" +
                ' <button type="button" class="close" data-dismiss="alert" aria-label="Close">  <span aria-hidden="true">&times;</span>  </button> </div>';
            //El mensaje de error se mostrara en un div con el id " alert "
            $('#alert').html(tpl);
        }
    },
        function (error) {

            tpl = '<div class="alert alert-danger hide" role="alert">' + "Error de tipo" + error +
                ' <button type="button" class="close" data-dismiss="alert" aria-label="Close">  <span aria-hidden="true">&times;</span>  </button> </div>';
            //El mensaje de error se mostrara en un div con el id " alert "
            $('#alert').html(tpl);
        }
    );

   
});


function cargarDatos(datos) {

    tablaBecas = $('#tableQSF').dataTable({
        data: datos,
        columnDefs: [
            { width: "15%", targets: [0] },
            { width: "25%", targets: [1] },

            { width: "10%", targets: [2] },
            { width: "20%", targets: [3] }
        ],
        columns: [

            { title: "ClaveQSF", data: "ClaveQSF" },
            { title: "Prioridad", data: "Prioridad" },
            
            {
                title: "", data: null, render:
                    function (data, type, row) {
                        return '<div class="row justify-content-center">' +
                            '<button type="button" onclick="editar(' + data.ClaveQSF +
                            ')" class="btn btn-primary">Editar</button>' +

                            '<button type="button" onclick="eliminar(' + data.ClaveQSF +
                            ')" class="btn btn-danger">Eliminar</button>' +
                            '</div>';
                    }
            }
        ]
    });
}



