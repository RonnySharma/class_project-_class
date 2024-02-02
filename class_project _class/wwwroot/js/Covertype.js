﻿
var dataTable;
$(document).ready(function () {
    loadDataTable();

})
function loadDataTable() {
    dataTable = $('#tbldata').dataTable({
        "ajax": {
            "url": "/Admin/Covertype/GetAll"
        },
        "columns": [
            { "data": "name", "width": "70%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
<a href="/Admin/Covertype/Upsert/${data}" class="btn btn-info"><i class="fas fa-edit"></i></a>
<a class="btn btn-danger" onClick=Delete("/Admin/Covertype/Delete/${data}")><i class="fas fa-trash-alt"></i></a>
</div>`;
                }
            }
        ]
    })
}
function Delete(url) {
    swal({
        title: "Want to delete data ?",
        text: "Delete Information",
        buttons: true,
        icon: "warning",
        dangermodel: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}
