var dbUtil = require("../../util/dbUtil.js");
// pages/test/dbUnit.js
const app = getApp();
const db = wx.cloud.database();

Page({

    /**
     * 页面的初始数据
     */
    data: {
        openid: '',
        queryResult: ''
    },

    btnAddData: function () {
        var newData = {
            "PlanName": "001",
            "StartDate": "2020-12-7",
            "EndDate": "2020-12-13",
            "IsFinish": 0,
            "FinishStatus": "完成", 
            "Reward": "外出就餐",
            "Goals": [
                {
                    "GoalName": "英语学习",
                    "GoalClockNumber": 3,	
                    "ClockWeek": "1,3,5",	
                    "RealClockNumber": 5,
                    "IsFinish": 0,
                    "FinishStatus": "完美"
                },
                {
                    "GoalName": "力量训练",
                    "GoalClockNumber": 3,
                    "ClockWeek": "1,3,5",
                    "RealClockNumber": 5,
                    "IsFinish": 0,
                    "FinishStatus": "完美"
                },
                {
                    "GoalName": "走路目标",
                    "GoalClockNumber": 3,
                    "ClockWeek": "1,3,5",
                    "RealClockNumber": 5,
                    "IsFinish": 0,
                    "FinishStatus": "完美"
                },
                {
                    "GoalName": "冥想训练",
                    "GoalClockNumber": 3,
                    "ClockWeek": "1,3,5",
                    "RealClockNumber": 5,
                    "IsFinish": 0,
                    "FinishStatus": "完美"
                }
            ]
        };
        // 判断当前有没有正在进行的计划
        var _db = db.collection('todos');
        _db.where({
            IsFinish: 0
        }).count({
            success: res => {
                console.log(res.total)
                if (res.total == 0) {
                    dbUtil.AddData(_db, newData, re => {
                        wx.showToast({
                            title: '新增记录成功',
                        })
                        console.log('[数据库] [新增记录] 成功，记录 _id: ', re._id)
                    });
                } else {
                    wx.showToast({
                        icon: 'none',
                        title: '当前有正在进行的计划，不能添加新计划'
                    })
                }
            },
            fail: err => {
                console.error('[数据库] [判断当前有没有正在进行的计划] 失败：', err)
            }
        });
    },
    btnGetData: function (e) {
        console.log("openid: " + this.data.openid);
        if (!this.data.openid) return;
        
        // 查询当前用户所有的 counters
        var _db = db.collection('todos');
        dbUtil.QueryCollection(_db, { _openid: this.data.openid }, res => {
            this.setData({
                queryResult: JSON.stringify(res.data, null, 2)
            })
            console.log("queryResult: " + this.data.queryResult)
            console.log('[数据库] [查询记录] 成功: ', res)
        })
    },
    btnUpdateData: function (e) {
        console.log("openid: " + this.data.openid);
        if (!this.data.openid) {
            wx.showToast({
                icon: 'none',
                title: '获取 openid 失败'
            })
            return;
        }

        var _db = db.collection('todos');
        var recordId = "846bf2595fd71cbc00162e80163ab338";
        var updateDate = {
            "IsFinish": 1
        };
        dbUtil.UpdateData(_db, recordId, updateDate, res => {
            console.log(res);
        })
    },
    btnRemoveData: function (e) {
        console.log("openid: " + this.data.openid);
        if (!this.data.openid) return;

        var _db = db.collection('todos');
        var recordId = "846bf2595fd71cbc00162e80163ab338";
        dbUtil.DeleteData(_db, recordId, res => {
            console.log(res);
        })
    },

    /**
     * 生命周期函数--监听页面加载
     */
    onLoad: function (options) {
        if (app.globalData.openid) {
            this.setData({
                openid: app.globalData.openid
            })
        }
    },

    /**
     * 生命周期函数--监听页面初次渲染完成
     */
    onReady: function () {

    },

    /**
     * 生命周期函数--监听页面显示
     */
    onShow: function () {

    },

    /**
     * 生命周期函数--监听页面隐藏
     */
    onHide: function () {

    },

    /**
     * 生命周期函数--监听页面卸载
     */
    onUnload: function () {

    },

    /**
     * 页面相关事件处理函数--监听用户下拉动作
     */
    onPullDownRefresh: function () {

    },

    /**
     * 页面上拉触底事件的处理函数
     */
    onReachBottom: function () {

    },

    /**
     * 用户点击右上角分享
     */
    onShareAppMessage: function () {

    }
})