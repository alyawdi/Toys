$(document).ready(function () {
    loadDataTable();

});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
        { data: 'title' , "width":"15%" },
            { data: 'price', "width": "15%"},
            { data: 'manufacturer', "width": "15%" },
            { data: 'sku', "width": "15%" }
             { data: 'category.name', "width": "15%" }
    ]
    });
}