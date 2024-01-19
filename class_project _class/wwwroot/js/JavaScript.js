﻿
var dataTable;
$(document).ready(function () {
    loadDataTable();

})
function loadDataTable() {
    dataTable = $('#tblData').dataTable({
        "ajax": {
            "url": "/Admin/category/GetAll"
        },
        "columns": [
            { "data": "name", "width": "70%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
<a href="/Admin/category/Upsert/${data}" class="btn btn-info"><i class="fas fa-edit"></i></a>
<a class="btn btn-danger" onClick=Delete("/Admin/Category/Delete/${data}")><i class="fas fa-trash-alt"></i></a>
</div>`;
                }
            }
        ]
    })
}
function Delete(url) {
    swal({
        title: "want to  delete?",
        text: "delete Information",
        button: true,
        icon: "warning",
        dangerModel: true
    }).then((WillDelete) => {
        if (WillDelete) {
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