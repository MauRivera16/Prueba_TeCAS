$(document).ready(function () {
    cargarDataTable();
});

var DataTable;

function cargarDataTable() {
    DataTable = $('#TablaCliente').DataTable({
        "ajax": {
            "type": "POST",
            "datatype": "json",
            "url": "/Clientes/Listar"
        },
        "columns": [
            { "data": "id" },
            { "data": "nombre" },
            { "data": "apellidoP" },
            { "data": "apellidoM" },
            { "data": "genero" },
            { "data": "matricula" },

            {
                "data": "id",
                "width": "25%",
                "render": function (data) {
                    return `<div class= "text-center"> <a class="btn btn-primary" href="/Clientes/Edit/${data}">Editar</a> &nbsp; <a class="btn btn-danger text-white" style="cursor:pointer;" onclick="Delete('/Clientes/Eliminar/${data}')">Eliminar<a/> </div>`
                }
            }
        ],
    });
}

function Delete(urlDestino) {
    swal({
        title: "¿Estas seguro que deseas borrar el cliente ?",
        text: "Esta accion no se puede revertir",
        type: "warning",
        showCancelButton: true,
        confirmButton: "Si,borrar",
        closeOnConfirm: true
    },
        function () {
            $.ajax({
                type: "DELETE",
                url: urlDestino,
                success: function (response) {
                    if (response.success = true) {
                        toastr.success(response.message);
                        DataTable.ajax.reload();

                    }
                    else {
                        toastr.error(response.message);
                    }
                }
            });
        }
    );
}