//ABP动态为所有API端点创建 JavaScript代理. 可以像调用Javascript本地方法一样使用任何端点.
//myBookStore.books.book.getList({}).done(function (result) { console.log(result); });
//myBookStore.books是BookAppService的命令空间MyBookStore.Books转换成小驼峰形式.
//book 是 BookAppService 的约定名称(删除AppService后缀并且转换为小驼峰).
//getList 是 CrudAppService 基类定义的 GetListAsync 方法的约定名称(删除Async后缀并且转换为小驼峰)
//{} 参数将空对象发送到 GetListAsync 方法,该方法通常需要一个类型为 PagedAndSortedResultRequestDto 的对象,该对象用于将分页和排序选项发送到服务器(所有属性都是可选的,具有默认值. 因此你可以发送一个空对象).
//getList 函数返回一个 promise. 你可以传递一个回调到 then(或done)函数来获取从服务器返回的结果.
//abp.libs.datatables.createAjax是帮助ABP的动态JavaScript API代理跟Datatable的格式相适应的辅助方法.

$(function() {
    //abp.localization.getResource 获取一个函数,该函数用于使用服务器端定义的相同JSON文件对文本进行本地化. 通过这种方式你可以与客户端共享本地化值.
    var l = abp.localization.getResource('MyBookStore');
    //abp.ModalManager 是一个在客户端打开和管理modal的辅助类
    var createModal = new abp.ModalManager(abp.appPath + 'Books/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Books/EditModal');


    var dataTable = $('#BooksTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            //abp.libs.datatables.createAjax是帮助ABP的动态JavaScript API代理跟Datatable的格式相适应的辅助方法.
            ajax: abp.libs.datatables.createAjax(myBookStore.books.book.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                        [
                            {
                                text: l('Edit'),
                                action: function(data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
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
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Type'),
                    data: "type",
                    render: function(data) {
                        return l('Enum:BookType:' + data);
                    }
                },
                {
                    title: l('PublishDate'),
                    data: "publishDate",
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
                    title: l('Price'),
                    data: "price"
                },
                {
                    title: l('CreationTime'),
                    data: "creationTime",
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


    //创建书籍后刷新数据表格
    createModal.onResult(function() {
        dataTable.ajax.reload();
    });

    editModal.onResult(function() {
        dataTable.ajax.reload();
    });


    $('#NewBookButton').click(function(e) {
        e.preventDefault();
        createModal.open(); //打开模态创建新书籍
    });
});