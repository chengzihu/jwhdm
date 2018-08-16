(function() {
    $(function() {
        $(function () {
            //1.初始化Table
            var oTable = new TableInit();
            oTable.Init();

            //2.初始化Button的点击事件
            var oButtonInit = new ButtonInit();
            oButtonInit.Init();
        });

    //var Url = "@Url.Action("GetUsers","Users")";
    var TableInit = function () {
            var oTableInit = new Object();
            //初始化Table
            oTableInit.Init = function () {
                $('#tb_departments').bootstrapTable({
                    // url: '../User/GetUsersList',
                    url: "UserMembers/GetUserMembers",         //请求后台的URL（*）
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
                            radio:true,
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
                            //width: 50,
                            align: 'center',
                            valign: 'middle',
                            visible: false
                        },
                        {
                            field: 'number',
                            title: '会员编号',
                            align: 'center',
                            valign: 'middle',
                            visible: false
                        },
                        {
                            field: 'name',
                            title: '名称',
                            align: 'center',
                            valign: 'middle'
                        },
                        {
                            field: 'gender',
                            title: '姓别',
                            formatter: showGender,
                            align: 'center',
                            valign: 'middle'
                        },
                        {
                            field: 'photo',
                            title: '头像',
                            align: 'center',
                            valign: 'middle',
                            visible: false
                        },
                        {
                            field: 'iDCard',
                            title: '身份证',
                            align: 'center',
                            valign: 'middle',
                            visible: false
                        },
                        {
                            field: 'relationUserId',
                            title: '用户编号',
                            align: 'center',
                            valign: 'middle',
                            visible: false
                        },
                        {
                            field: 'height',
                            title: '身高',
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        },
                        {
                            field: 'weight',
                            title: '体重',
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        },
                        {
                            field: 'armspan',
                            title: '臂展',
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        },
                        {
                            field: 'type',
                            title: '会员类型',
                            formatter: showMemberType,
                            align: 'center',
                            valign: 'middle'
                        },
                        {
                            field: 'maritalStatus',
                            title: '婚姻状况',
                            align: 'center',
                            valign: 'middle',
                            visible: false
                        },
                        {
                            field: 'address',
                            title: '家庭住址',
                            align: 'center',
                            valign: 'middle',
                            visible: false
                        },
                        {
                            field: 'phoneNumber',
                            title: '电话',
                            align: 'center',
                            valign: 'middle',
                            visible: false
                        },
                        {
                            field: 'birthdate',
                            title: '出生日期',
                            align: 'center',
                            valign: 'middle',
                            visible: false
                        },
                        {
                            field: 'joinTime',
                            title: '加入时间',
                            align: 'center',
                            valign: 'middle',
                            visible: false
                        },
                        {
                            field: 'joinAddress',
                            title: '加入地点',
                            align: 'center',
                            valign: 'middle',
                            visible: false
                        },
                        {
                            field: 'fee',
                            title: '会员费',
                            align: 'center',
                            valign: 'middle',
                            visible: false
                        },
                        {
                            field: 'attendanceLesson',
                            title: '出勤课时',
                            align: 'center',
                            valign: 'middle',
                            visible: true
                        },
                        {
                            field: 'totalLesson',
                            title: '全部课时',
                            align: 'center',
                            valign: 'middle',
                            visible: true
                        },
                        {
                            field: 'attendanceAddress',
                            title: '出勤地点',
                            align: 'center',
                            valign: 'middle',
                            visible: false
                        },
                        {
                            field: 'abstract',
                            title: '个人简介',
                            align: 'center',
                            valign: 'middle',
                            visible: true
                        },
                        {
                            field: 'description',
                            title: '教练描述',
                            align: 'center',
                            valign: 'middle',
                            visible: true
                        },
                        {
                            field: 'joinExpiry',
                            title: '截止日期',
                            align: 'center',
                            valign: 'middle',
                            visible: true
                        },
                        {
                            field: 'creationTime',
                            title: '创建时间',
                            align: 'center',
                            valign: 'middle',
                            formatter: showDate,
                            sortable: true,
                            visible: false
                        },
                        {
                            field: 'deletionTime',
                            title: '删除时间',
                            align: 'center',
                            valign: 'middle',
                            formatter: showDate,
                            sortable: true,
                            visible: false
                        },
                        {
                            field: 'isDeleted',
                            title: '删除',
                            align: 'center',
                            valign: 'middle',
                            visible: false
                        },
                        {
                            field: 'lastModificationTime',
                            title: '最近修改时间',
                            align: 'center',
                            valign: 'middle',
                            formatter: showDate,
                            visible: false
                        },
                        {
                            field: 'lastModificationTime',
                            title: '最近修改时间',
                            align: 'center',
                            valign: 'middle',
                            formatter: showDate,
                            visible: false
                        },
                        {
                            field: 'creatorUserId',
                            title: '创建者',
                            align: 'center',
                            valign: 'middle',
                            formatter: showDate,
                            sortable: true,
                            visible: false
                        }
                    ],
                    onLoadSuccess: function () {
                    },
                    onLoadError: function (code) {
                        if (code == 401) {//Unauthorized
                            toastr.warning('此操作未被授权！');
                        }
                        else if (code == 404) {//Not Found
                            toastr.warning('请求路径未找到！');s
                        }
                        else {//Others
                            toastr.warning('数据加载失败！');
                        }
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
                var date = new Date(value);
                var formatDate = date.toLocaleString();
                return formatDate;
        }

        //格式化显示任务状态
        //有待改进-获取任务状态列表
        function showGender(value, row, index) {
            var formatState;
            if (value === true) {
                formatState = '<span class="pull-center label label-success">男</span>';
            }
            if (value === false) {
                formatState = '<span class="pull-center label label-info">女</span>';
            }

            return formatState;
        }

        //格式化显示任务状态
        //有待改进-获取任务状态列表
        function showMemberType(value, row, index) {
            var formatState;
            if (value == 0) {
                formatState = '<span class="pull-center label label-success">大课</span>';
            }
            else if (value == 1) {
                formatState = '<span class="pull-center label label-info">私教</span>';
            }
            else {
                formatState = '<span class="pull-center label label-info">未定义</span>';
            }
            return formatState;
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
                    m_pagerow = 0;
                    $("#tb_departments").bootstrapTable('refresh', { url: "UserMembers/GetUserMembers" });
                });
                //新增按钮单击
                $("#btn_add").click(function () {
                    var param = {};
                    $.ajax({
                        type: "GET",
                        url: "GetRoles",
                        data: param,
                        beforeSend: function () {
                        },
                        success: function (result) {
                            var modeldata = { id: "", name: "", surname: "", userName: "", fullName: "", emailAddress: "", creationTime: "", lastLoginTime: "", roleNames: "", allRoleNames: result, isActive: true };
                            ShowModal(modeldata, "新增用户");
                        },
                        error: function () {

                        },
                        complete: function () {

                        }
                    });
                });

                //新增提交
                $("#btn_submit").click(function () {
                    var title = $("#myModalLabel").text();
                    var actionUrl = "Update";
                    if ("新增用户" == title) {
                        actionUrl = "Create";
                    }

                    var roleNamesData = [];
                    $("#roleGroup").find(":checkbox:checked").each(function () {
                        roleNamesData.push($(this).val());
                    });
                    //if (roleNamesData.length > 0) {
                    //    newPerson.roleNames = [roleNamesData.join(',')];
                    //}
                    var id = $("#txt_Id").val() == "" ? 0 : $("#txt_Id").val();
                    var newPerson = {
                        "id": id,
                        "UserName": $("#txt_UserName").val(),
                        "EmailAddress": $("#txt_EmailAddress").val(),
                        "Name": $("#txt_Name").val(),
                        //"FullName": $("#txt_FullName").val(),
                        "Surname": $("#txt_Surname").val(),
                        "Password": "123456",
                        "CreationTime": $("#txt_CreationTime").val(),
                        "LastLoginTime": $("#txt_LastLoginTime").val(),
                        "isActive": document.getElementById('isActive').checked,
                        roleNames: roleNamesData
                    };

                    abp.ajax({
                        url: actionUrl,
                        data: JSON.stringify(newPerson)
                    }).done(function (data) {
                        var actionUrl = "GetUsers";
                        $("#tb_departments").bootstrapTable('refresh', { url: actionUrl });
                        abp.notify.success('updated new person with id = ' + data.id);
                    }).fail(function (data) {
                        abp.notify.error('Something is wrong!');
                    });
                });

                //编辑按钮单击
                $("#btn_edit").click(function () {
                    //debugger;
                    var arrselections = $("#tb_departments").bootstrapTable('getSelections');
                    if (arrselections.length > 1) {
                        toastr.warning('只能选择一行进行编辑');
                        return;
                    }
                    if (arrselections.length <= 0) {
                        toastr.warning('请选择有效数据');
                        return;
                    }

                    var actionUrl = "GetRoles";
                    var param = { id: arrselections[0].id };
                    var arrselections = $("#tb_departments").bootstrapTable('getSelections');
                    $.ajax({
                        type: "GET",
                        url: actionUrl,
                        data: param,
                        beforeSend: function () {
                        },
                        success: function (result) {
                            //debugger;
                            var modeldata = { id: arrselections[0].id, name: arrselections[0].name, surname: arrselections[0].surname, userName: arrselections[0].userName, fullName: arrselections[0].fullName, emailAddress: arrselections[0].emailAddress, creationTime: arrselections[0].creationTime, lastLoginTime: arrselections[0].lastLoginTime, roleNames: arrselections[0].roleNames, allRoleNames: result, isActive: arrselections[0].isActive };
                            ShowModal(modeldata, "编辑用户");
                        },
                        error: function () {

                        },
                        complete: function () {

                        }
                    });
                });

                //删除角色
                $("#btn_delete").click(function () {
                    var actionUrl = "Delete";
                    var arrselections = $("#tb_departments").bootstrapTable('getSelections');
                    if (arrselections.length > 1) {
                        toastr.warning('只能选择一行进行编辑');
                        return;
                    }
                    if (arrselections.length <= 0) {
                        toastr.warning('请选择有效数据');
                        return;
                    }

                    var newPerson = {
                        "id": arrselections[0].id
                    };
                    //debugger;
                    abp.ajax({
                        url: actionUrl,
                        data: JSON.stringify(newPerson)
                    }).done(function (data) {
                        var actionUrl = "GetUsers";
                        $("#tb_departments").bootstrapTable('refresh', { url: actionUrl });
                        abp.notify.success('updated new person with id = ' + data.id);
                    }).fail(function (data) {
                        abp.notify.error('Something is wrong!');
                    });
                });

                //权限授权
                    //$("#btn_authorize").click(function () {
                    //    var arrselections = $("#tb_departments").bootstrapTable('getSelections');
                    //    if (arrselections.length > 1) {
                    //        toastr.warning('只能选择一个角色进行授权');
                    //        return;
                    //    }
                    //    if (arrselections.length <= 0) {
                    //        toastr.warning('请选择有效数据');
                    //        return;
                    //    }
                    //    var actionUrl = "@Url.Action("AuthorizePermission")";
                    //    var param = { id: arrselections[0].Id };
                    //    ShowModal_Authorize(actionUrl, param, "权限授权");
                    //});
            //模态框中“权限授权”保存
            //var $modal = $("#authorizeModal");
            //    $("#btnSave", $modal).click(function () {
            //        var actionUrl = "@Url.Action("AuthorizePermission")";
            //        SaveModal_Authorize(actionUrl);
            //    });
                ////模态框中“新增编辑角色”保存
                //var $formmodal = $("#modal-form");
                //$("#btnSave", $formmodal).click(function () {
                //    var $tb = $("#tb_departments");
                //    SaveModal($tb);
                //});

                //模态框中“新增编辑角色”保存
                //var $formmodal = $("#myModal");
                //$("#btn_submit",$formmodal).click(function () {
                //    alert("dfddf");
                //    var $tb = $("#tb_departments");
                //    SaveModal($tb);
                //});

                /*******弹出表单*********/
                function ShowModal(param, title) {
                    $("#txt_Id").val(param.id);
                    $("#txt_Surname").val(param.surname);
                    $("#txt_Name").val(param.name);
                    $("#txt_EmailAddress").val(param.emailAddress);
                    $("#txt_UserName").val(param.userName);
                    $("#txt_FullName").val(param.fullName);
                    $("#txt_CreationTime").val(param.creationTime);
                    $("#txt_LastLoginTime").val(param.lastLoginTime);
                    if (param.isActive) {
                        $("#isActive").prop("checked", "checked");
                    }
                    else {
                        $("#isActive").removeProp("checked");
                    }

                    $("#roleGroup").empty();
                    $.each(param.allRoleNames, function (n, value) {
                        var roleGroup = '<div class="col-sm-6">';
                        roleGroup += '<input type="checkbox" name="role" value="';
                        roleGroup += value.name;
                        roleGroup += '" title="';
                        roleGroup += value.displayName;
                        roleGroup += '" class="filled-in" id="';
                        roleGroup += "role" + value.id + '"';
                        if ($.inArray(value.normalizedName, param.roleNames) > -1) {
                            roleGroup += ' checked=""';
                        }
                        roleGroup += '/>';
                        roleGroup += '<label for="';
                        roleGroup += "role" + value.id + '"';
                        roleGroup += ' title="';
                        roleGroup += value.displayName;
                        roleGroup += '">';
                        roleGroup += value.name;
                        roleGroup += '</label>';
                        roleGroup += '</div>';
                        $("#roleGroup").append(roleGroup);
                    });

                    $("#myModalLabel").text(title);
                    $('#myModal').modal();
                }
            };

            return oInit;
        };
        
    });
})();