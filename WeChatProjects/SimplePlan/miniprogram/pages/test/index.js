var dateUtil = require("../../util/dateUtil.js");
// pages/test/index.js
const app = getApp();
var TodayAndWeekDays = dateUtil.GetTodayAndWeekDays();
var today = TodayAndWeekDays["today"];
var dayArr = TodayAndWeekDays["dayArr"];

Page({
    /**
     * 页面的初始数据
     */
    data: {
        plan: '',
        startDate: '开始日期',
        endDate: '结束日期',
        dayArr,
        today,
        openid: '',
        queryResult: ''
    },
    textclick: function (e) {
        console.log(e);
        var _data = e.currentTarget.dataset.content;
        console.log(_data);
        this.setData({
            today: _data
        });
    },
    bindStartDateChange: function (e) {
        console.log('picker发送选择改变，携带值为', e.detail.value)
        this.setData({
            startDate: e.detail.value
        })
    },
    bindEndDateChange: function (e) {
        console.log('picker发送选择改变，携带值为', e.detail.value)
        this.setData({
            endDate: e.detail.value
        })
    },
    
    /**
     * 生命周期函数--监听页面加载
     */
    onLoad: function (options) {
        if (!this.data.openid) {
            // 调用云函数
            wx.cloud.callFunction({
                name: 'login',
                data: {},
                success: res => {
                    console.log('[云函数] [login] user openid: ', res.result.openid)
                    app.globalData.openid = res.result.openid
                    this.setData({
                        openid: app.globalData.openid
                    })
                },
                fail: err => {
                    wx.showToast({
                        icon: 'none',
                        title: '获取 openid 失败，请检查是否有部署 login 云函数',
                    })
                    console.log('[云函数] [login] 获取 openid 失败，请检查是否有部署云函数，错误信息：', err)
                }
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