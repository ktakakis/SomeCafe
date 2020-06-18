var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Customer/CustomerPreferences/GetAll"
        },
        "columns": [
            { "data": "applicationUser.userName", "width": "60%" },
            { "data": "product.title", "width": "60%" },
            { "data": "sweetness.sweetnessName", "width": "60%" },
            { "data": "sweetener.sweetenerName", "width": "60%" },
            { "data": "milkType.milkTypeName", "width": "60%" },
            { "data": "topping.toppingName", "width": "60%" },
            { "data": "naiceCube.iceCubeName", "width": "60%" },
            { "data": "origin.originName", "width": "60%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Customer/CustomerPreferences/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Delete("/Customer/CustomerPreferences/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "40%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Είστε βέβαιοι ότι θέλετε να διαγράψετε?",
        text: "Δεν θα μπορείτε να επαναφέρετε τα δεδομένα!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}