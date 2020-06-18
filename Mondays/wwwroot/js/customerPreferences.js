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
            { "data": "applicationUser.userName", "width": "12.25%" },
            { "data": "product.title", "width": "12.25%" },
            { "data": "sweetness.sweetnessName", "width": "12.25%" },
            { "data": "sweetener.sweetenerName", "width": "12.25%" },
            { "data": "milkTypes.milkTypeName", "width": "12.25%" },
            { "data": "topping.toppingName", "width": "12.25%" },
            { "data": "iceCubes.iceCubeName", "width": "12.25%" },
            { "data": "origins.originName", "width": "12.25%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Customer/CustomerPreferences/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "1%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a onclick=Delete("/Customer/CustomerPreferences/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "1%"
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