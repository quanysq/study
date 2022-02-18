/*
 * 插入新数据
 * _db：数据库 collection
 * newData: 数据对象
 * fun: 回调函数
 */
function InsertData(_db, newData, fun) {
    _db.add({
        data: newData,
        success: res => {
            fun(res);
        },
        fail: err => {
            wx.showToast({
                icon: 'none',
                title: '新增记录失败'
            })
            console.error('[数据库] [新增记录] 失败：', err)
        }
    })
}

/*
 * 查询数据，返回一个数据集
 * _db：数据库 collection
 * query: 查询条件对象
 * fun: 回调函数
 */
function QueryCollection (_db, query, fun) {
    _db.where(query).get({
        success: res => {
            fun(res);
        },
        fail: err => {
            wx.showToast({
                icon: 'none',
                title: '查询记录失败'
            })
            console.error('[数据库] [查询记录] 失败：', err)
        }
    })
}

/*
 * 更新一条指定的数据
 * _db：数据库 collection
 * recordId: 记录的ID
 * updateData: 待更新的数据对象
 * fun: 回调函数
 */
function UpdateData (_db, recordId, updateData, fun) {
    _db.doc(recordId).update({
        data: updateData,
        success: res => {
            fun(res);
        },
        fail: err => {
            wx.showToast({
                icon: 'none',
                title: '更新记录失败'
            })
            console.error('[数据库] [更新记录] 失败：', err)
        }
    })
}

function DeleteData (_db, recordId, fun) {
    _db.doc(recordId).remove({
        success: res => {
            fun(res);
        },
        fail: err => {
            wx.showToast({
                icon: 'none',
                title: '删除记录失败'
            })
            console.error('[数据库] [删除记录] 失败：', err)
        }
    })
}

module.exports = {
    AddData: InsertData,
    QueryCollection: QueryCollection,
    UpdateData: UpdateData,
    DeleteData: DeleteData
}