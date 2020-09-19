
$(function() {
    //abp.localization.getResource 获取一个函数,该函数用于使用服务器端定义的相同JSON文件对文本进行本地化. 通过这种方式你可以与客户端共享本地化值.
    var l = abp.localization.getResource('MyBookStore');
    var dataTable = $('#JobInfoTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            //abp.libs.datatables.createAjax是帮助ABP的动态JavaScript API代理跟Datatable的格式相适应的辅助方法.
            ajax: abp.libs.datatables.createAjax(myBookStore.jobSchedule.jobInfo.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                        [
                            {
                                text: l('Edit'),
                                //visible: abp.auth.isGranted('MyBookStore.Books.Edit'), //CHECK for the PERMISSION
                                action: function(data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('MyBookStore.Books.Delete'),
                                //confirmMessage 用来在实际执行 action 之前向用户进行确认.
                                confirmMessage: function(data) {
                                    return l('BookDeletionConfirmationMessage', data.record.name);
                                },
                                action: function(data) {
                                    myBookStore.books.book
                                        .delete(data.record.id)
                                        .then(function() {
                                            //abp.notify.info 用来在执行删除操作后显示一个toastr通知信息.
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                    }
                },
                {
                    title: l('JobSchedule:JobGroup'),
                    data: "jobGroup"
                },
                {
                    title: l('JobSchedule:JobName'),
                    data: "jobName"
                },
                {
                    title: l('JobSchedule:JobDescription'),
                    data: "jobDescription"
                },
                {
                    title: l('JobSchedule:JobStatus'),
                    data: "jobStatus",
                    render: function(data) {
                        return l('Enum:JobStatus:' + data);
                    }
                },
                {
                    title: l('JobSchedule:CronExpress'),
                    data: "cronExpress"
                },
                {
                    title: l('JobSchedule:StarTime'),
                    data: "starTime",
                    render: function(data) {
                        return luxon
                            .DateTime
                            .fromISO(data,
                                {
                                    locale: abp.localization.currentCulture.name
                                }).toLocaleString();
                    }
                },
                {
                    title: l('JobSchedule:EndTime'),
                    data: "endTime",
                    render: function(data) {
                        return luxon
                            .DateTime
                            .fromISO(data,
                                {
                                    locale: abp.localization.currentCulture.name
                                }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                },
                {
                    title: l('JobSchedule:NextTime'),
                    data: "nextTime",
                    render: function(data) {
                        return luxon
                            .DateTime
                            .fromISO(data,
                                {
                                    locale: abp.localization.currentCulture.name
                                }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );

    //abp.ModalManager 是一个在客户端打开和管理modal的辅助类
    var createModal = new abp.ModalManager(abp.appPath + 'JobSchedule/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'JobSchedule/EditModal');

    createModal.onResult(function() {
        dataTable.ajax.reload();
    });

    editModal.onResult(function() {
        dataTable.ajax.reload();
    });


    $('#NewJobInfoButton').click(function(e) {
        e.preventDefault();
        createModal.open();
    });
});