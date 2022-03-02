$(document).ready(function () {
    console.log("entre");
    cargarDataTable();
});

var DataTable;

function cargarDataTable() {
    console.log("entre x2");
    DataTable = $('#TablaCuentas').DataTable({
        "ajax": {
            "type": "GET",
            "datatype": "json",
            "url": "/CuentaAhorro/Listar"
        },
        "columns": [
            { "data": "id", "width": "5%" },//1
            { "data": "clientObj.matricula", "width": "25%" },//2
            {//3
                "data": "id",
                "width": "25%",
                "render": function (data, type, row) {
                    return row.clientObj.apellidoP + ' ' + row.clientObj.apellidoM + ' ' + row.clientObj.nombre
                }
            },
            { "data": "saldo", "width": "10%" },//4
            {//5
                "data": "id",
                "width": "45%",
                "render": function (data) {
                    return `<div class= "text-center"><a class="btn btn-danger text-white" style="cursor:pointer;" onclick="Delete('/CuentaAhorro/Eliminar/${data}')">Eliminar<a/> &nbsp;
                   <a class="btn btn-success" href="/CuentaAhorro/Deposito/${data}">Deposito</a> &nbsp; <a class="btn btn-danger text-white" href="/CuentaAhorro/Retiro/${data}">Retiro</a> </div>`
                }
            }
        ],
    });
}

function Delete(urlDestino) {
    swal({
        title: "¿Estas seguro que deseas borrar el curso?",
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
