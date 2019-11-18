$(document).ready(function () {
    const info = {
        select: $('#userSelect'),
        dataTable: $('#dataRow')
    };
    console.log(info);
    $.ajax({
        //url: '@Url.Action("UsersList", "User")',
        url: 'https://localhost:44368/User/UsersList',
        type: "GET",
        success: function (result) {
            

            $.each(result, function (index, object) {
                console.log(object);
                info.select.append('<option value=' + object.Id + '>' + object.FirstName + ' ' + object.LastName + '</option >');
            });   
        }
    });
    function PrintTable(id) {
        $.ajax({
            //url: '@Url.Action("UsersList", "User")',
            url: 'https://localhost:44368/Project/ProjectListByUser/' + id,
            type: "GET",
            success: function (result) {


                $.each(result, function (index, object) {
                    console.log(object);
                    let tr = document.createElement('tr');
                    var isActive;
                    var Start;
                    if (object.TimeToStart==-1) {
                        Start = 'Started';
                    } else {
                        Start = 'Waiting';
                    }
                    if (object.IsActive) {
                        isActive = 'Active';
                    } else {
                        isActive = 'Inactive';
                    }
                    info.dataTable.append(
                        `<tr>
                            <th>${object.Id}</th>
                            <td>${object.StartDate}</td>
                            <td>${Start}</td>
                            <td>${object.EndDate}</td>
                            <td>${object.Credits}</td>
                            <td>${isActive}</td>
                        </tr>`
                    );
                });
            }
        });
    }

    info.select.on('change',function () {
        console.log(this.value);
        info.dataTable.empty();;
        PrintTable(this.value);
    });
    
});

