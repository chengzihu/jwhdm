(function () {
    $(function () {
        //var url = '@Url.Action("GetRoles", "Roles")';
        //var Url = "Roles/GetRoles";
        $(function () {
            //1.初始化Table
            var oTable = new TableInit();
            oTable.Init();

            //2.初始化Button的点击事件
            var oButtonInit = new ButtonInit();
            oButtonInit.Init();
        });

        //var Url = '@Url.Action("GetRoles","Roles")';
        Url = "Roles/GetRoles";
        var TableInit = function () {
            var oTableInit = new Object();
            //初始化Table
            oTableInit.Init = function () {
                $('#tb_departments').bootstrapTable({
                    url: Url,         //请求后台的URL（*）
                    method: 'get',                      //请求方式（*）
                    toolbar: '#toolbar',                //工具按钮用哪个容器
                    classes: 'table',//边框
                    undefinedText: '',//当数据为 undefined 时显示的字符
                    striped: true,                      //是否显示行间隔色
                    cache: false,                       //是否使用缓存，默认为true，所以一般情况下需s要设置一下这个属性（*）
                    pagination: true,                   //是否显示分页（*）
                    sortable: true,                     //是否启用排序
                    sortOrder: "asc",                   //排序方式
                    queryParams: oTableInit.queryParams,//传递参数（*）
                    sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
                    pageNumber: 1,                       //初始化加载第一页，默认第一页
                    pageSize: 10,                       //每页的记录行数（*）
                    pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
                    search: false,                      //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
                    contentType: "application/json",
                    //contentType: "application/x-www-form-urlencoded",
                    strictSearch: false,
                    showColumns: true,                  //是否显示所有的列
                    showRefresh: true,                  //是否显示刷新按钮
                    minimumCountColumns: 2,             //最少允许的列数
                    clickToSelect: true,                //是否启用点击选中行
                    //height: 500,                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
                    idField: 'id',
                    uniqueId: "id",                     //每一行的唯一标识，一般为主键列
                    showToggle: false,                    //是否显示详细视图和列表视图的切换按钮
                    cardView: false,                    //是否显示详细视图
                    detailView: false,                   //是否显示父子表
                    columns: [
                        {
                            //checkbox: true,
                            radio: true,
                            align: 'center',
                            valign: 'middle'
                        },
                        {
                            field: 'number',
                            title: '序号',
                            formatter: function (value, row, index) {
                                var pageSize = $('#tb_departments').bootstrapTable('getOptions').pageSize;
                                var pageNumber = $('#tb_departments').bootstrapTable('getOptions').pageNumber;
                                return pageSize * (pageNumber - 1) + index + 1;
                            },
                            visible: false
                        },
                        {
                            field: 'id',
                            title: '编号',
                            visible: false,
                            align: 'center',
                            valign: 'middle'
                        },
                        {
                            field: 'name',
                            title: '名称',
                            align: 'center',
                            valign: 'middle'
                        },
                        {
                            field: 'displayName',
                            title: '显示名称',
                            align: 'center',
                            valign: 'middle'
                        },
                        {
                            field: 'normalizedName',
                            title: '别名',
                            align: 'center',
                            valign: 'middle'
                        },
                        {
                            field: 'description',
                            title: '描述',
                            align: 'center',
                            valign: 'middle'
                        },
                        {
                            field: 'permissions',
                            title: '权限',
                            align: 'center',
                            valign: 'middle',
                            visible: false
                        },
                        {
                            field: 'isStatic',
                            title: 'isStatic',
                            formatter: showState,
                            align: 'center',
                            valign: 'middle',
                            visible: false
                        }
                    ],
                    onLoadSuccess: function () {
                    },
                    onLoadError: function () {
                        showTips("数据加载失败！");
                    },
                    onDblClickRow: function (row, $element) {
                        var id = row.ID;
                        EditViewById(id, 'view');
                    },
                    rowStyle: function (row, index) {
                        var classesArr = ['success', 'info'];
                        var strclass = "";
                        if (index % 2 === 0) {//偶数行
                            strclass = classesArr[0];
                        } else {//奇数行
                            strclass = classesArr[1];
                        }
                        return { classes: strclass };
                    },//隔行变色
                });
            };

            //得到查询的参数
            oTableInit.queryParams = function (params) {
                var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
                    limit: params.limit,   //页面大小
                    offset: params.offset,  //页码
                    departmentname: $("#txt_search_departmentname").val(),
                    statu: $("#txt_search_statu").val()
                };
                return temp;
            };

            //格式化显示json日期格式
            function showDate(value, row, index) {
                //var birthdayMilliseconds = parseInt(value.replace(/\D/igm, ""));
                //var date = new Date(birthdayMilliseconds);
                var date = new Date(value);
                var formatDate = date.toLocaleString();
                return formatDate;
            }

            //格式化显示任务状态
            //有待改进-获取任务状态列表
            function showState(value, row, index) {
                var formatState;
                if (value === true) {
                    formatState = '<span class="pull-center label label-success">是</span>';
                }
                if (value === false) {
                    formatState = '<span class="pull-center label label-info">否</span>';
                }

                return formatState;
            }

            return oTableInit;
        };

        var ButtonInit = function () {
            var oInit = new Object();
            var postdata = {};
            oInit.Init = function () {
                //初始化页面上面的按钮事件
                //查询角色
                $("#btn_query").click(function () {
                    var actionUrl = "Roles/GetRoles";
                    $("#tb_departments").bootstrapTable('refresh', { url: actionUrl });
                });

                //编辑按钮单击
                $("#btn_edit").click(function () {
                    var arrselections = $("#tb_departments").bootstrapTable('getSelections');
                    if (arrselections.length > 1) {
                        toastr.warning('只能选择一行进行编辑');
                        return;
                    }
                    if (arrselections.length <= 0) {
                        toastr.warning('请选择有效数据');
                        return;
                    }

                    var param = { id: arrselections[0].id };
                    var title = "编辑";
                    $.ajax({
                        url: abp.appPath + 'Roles/EditRoleModal?roleId=' + param.id,
                        type: 'GET',
                        contentType: 'application/html',
                        success: function (content) {
                            $('#EditRoleModal div.modal-content').html(content);
                            $("#EditRoleModalLabel").text(title);
                            $('#EditRoleModal').modal();
                        },
                        error: function (e) {
                            abp.notify.error('Something is wrong!');
                        }
                    });
                });

                //新增按钮单击
                $("#btn_add").click(function () {
                    $("#createid").val(0);
                    $("#createrolename").val("");
                    $("#createdisplayname").val("");
                    $("#createrole-description").val("");
                    var title = "新增";
                    $("#CreateRoleModalLabel").text(title);
                    $('#CreateRoleModal').modal();
                });
              
                $("#btn_save").click(function () {
                    var title = $("#CreateRoleModalLabel").text();
                    var id = $("#createid").val() == "" ? 0 : $("#createid").val();
                    var param = {
                        "id": id,
                        "name": $("#createrolename").val(),
                        "displayName": $("#createdisplayname").val(),
                        "description": $("#createrole-description").val(),
                        "normalizedName": "",
                        //"isStatic": $("#isStatic").val(),
                        permissions: []
                    };

                    var permissionsData = [];
                    $("#createRoleGroup").find(":checkbox:checked").each(function () {
                        permissionsData.push($(this).val());
                    });
                    param.permissions = permissionsData;
                    //if (permissionsData.length > 0) {
                    //    param.permissions = [permissionsData.join(',')];
                    //}
                    //data: JSON.stringify(param)
                    abp.ajax({
                        url: "Roles/Create",
                        ContentType: "application/json",
                        data: JSON.stringify(param)
                    }).done(function (data) {
                        var actionUrl = "Roles/GetRoles";
                        $("#tb_departments").bootstrapTable('refresh', { url: actionUrl });
                        abp.notify.success('updated new person with id = ' + data.id);
                    }).fail(function (data) {
                        abp.notify.error('Something is wrong!');
                        //abp.notify.error(data.message);
                    });
                });

                //删除角色
                $("#btn_delete").click(function () {
                    var arrselections = $("#tb_departments").bootstrapTable('getSelections');
                    if (arrselections.length > 1) {
                        toastr.warning('只能选择一行进行编辑');
                        return;
                    }
                    if (arrselections.length <= 0) {
                        toastr.warning('请选择有效数据');
                        return;
                    }

                    abp.ajax({
                        url: "Roles/Delete?=" + arrselections[0].id,
                        type: 'GET'
                        //data: JSON.stringify({
                        //    "id": arrselections[0].id
                        //})
                    }).done(function (data) {
                        $("#tb_departments").bootstrapTable('refresh',{ url: "Roles/GetRoles" });
                        abp.notify.success('updated new person with id = ' + data.id);
                    }).fail(function (data) {
                        abp.notify.error('Something is wrong!');
                    });
                });
            };
            return oInit;
        };
    });
})();