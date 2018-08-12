(function () {
    $(function () {
        $("#btn_submit").click(function () {
            var title = $("#ModalLabel").text();
            var actionUrl = "Update";
            var id = $("#id").val() == "" ? 0 : $("#id").val();
            var param = {
                "id": id,
                "TenancyName": $("#tenancyName").val(),
                "Name": $("#name").val(),
                "IsActive": document.getElementById('isActive').checked
            };

            abp.ajax({
                url: actionUrl,
                ContentType: "application/json",
                data: JSON.stringify(param)
            }).done(function (data) {
                var actionUrl = "GetTenants";
                $("#tb_departments").bootstrapTable('refresh', { url: actionUrl });
                abp.notify.success('updated new person with id = ' + data.id);
            }).fail(function (data) {
                abp.notify.error('Something is wrong!');
                //abp.notify.error(data.message);
            });
        });
    });
})();