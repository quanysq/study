/** 
 * 获取今天的完整日期（Year-M-D），日期（D），星期
 * 获取当前这一周的日期的完整日期（Year-M-D），日期（D），星期
 * 周以星期一为第一天
*/
function GetTodayAndWeekDays() {
    var date = new Date();
    var year = date.getFullYear();
    var month = date.getMonth();
    var todayMonth = month + 1;
    var day = date.getDate();
    var dayOfWeek = date.getDay();
    var today = {fullDay: '', day: '', week: ''};
    today.fullDay = year + '-' + todayMonth + '-' + day;
    today.day = day;
    today.week = dayOfWeek;
    var weekStartDate = new Date(year, month, day - dayOfWeek);
    var dayArr = [{fullDay: '', day: '', week: ''}, {fullDay: '', day: '', week: ''}, {fullDay: '', day: '', week: ''}, {fullDay: '', day: '', week: ''}, {fullDay: '', day: '', week: ''}, {fullDay: '', day: '', week: ''}, {fullDay: '', day: '', week: ''}];
    for(var i=0; i<7; i++){
        var dayNext = weekStartDate.setDate(weekStartDate.getDate() + 1);
        var dayDate = new Date(dayNext);
        var dayItem = dayDate.getDate();
        var loopYear = dayDate.getFullYear();
        var loopMonth = dayDate.getMonth();
        loopMonth = loopMonth + 1;
        var dayWeek = dayDate.getDay();
        dayArr[i].day = dayItem;
        dayArr[i].fullDay = loopYear + '-' + loopMonth + '-' + dayItem;
        dayArr[i].week = dayWeek;
    }
    var returnData = {};
    returnData["today"] = today;
    returnData["dayArr"] = dayArr;
    return returnData;
}

module.exports = {
    GetTodayAndWeekDays: GetTodayAndWeekDays  
}