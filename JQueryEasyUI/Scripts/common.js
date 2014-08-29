/**************************
*名称：js公用类库 所有页面都需要引用
*描述：这个文件作为基础类库，所有页面都必须引用，且放在页面js之前
***************************/

//#region 去首尾空格;

String.prototype.trim = function () {
    ///<summary>去除首尾空格</summary>
    return this.replace(/(^\s*)|(\s*$)/g, "");
}

//#endregion

//#region 自定义一个StringBuilder类
function StringBuilder() {
    this._strings = new Array();
    this.length = function () { return this._strings.length; };
}
StringBuilder.prototype.append = function (str) { this._strings.push(str); };
StringBuilder.prototype.toString = function (join) {
    /// <summary>转为字符串</summary>
    /// <param name="name?" type="String">合并的字符串</param>
    var _js = join || "";
    return this._strings.join(_js);
};
StringBuilder.prototype.colear = function () { this._strings = []; }
//#endregion

//#region 增加时间格式化函数
Date.prototype.format = function (format) {
    /// <summary>日期格式化函数</summary>
    /// <param name="format" type="String">例如 yyyy-MM-dd hh:mm;ss</param>
    /// <returns type="String" />
    var o = {
        "M+": this.getMonth() + 1, //month 
        "d+": this.getDate(), //day 
        "h+": this.getHours(), //hour
        "H+": this.getHours(), //hour  
        "m+": this.getMinutes(), //minute 
        "s+": this.getSeconds(), //second 
        "q+": Math.floor((this.getMonth() + 3) / 3), //quarter 
        "S": this.getMilliseconds() //millisecond 
    }


    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }

    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
}
Date.prototype.dateDiff = function (date, flag) {
    /// <summary>计算两个日期之间的差值</summary>
    /// <param name="date" type="Date">日期对象</param>
    /// <param name="flag" type="string">ms-毫秒，s-秒，m-分，h-小时，d-天，M-月，y-年</param>
    /// <returns type="String" />返回：当前日期和date两个日期相差的毫秒/秒/分/小时/天
    var msCount;
    if (!date) {
        return "必须是日期对象";
    }
    var diff = this.getTime() - date.getTime();
    if (!flag || typeof flag != "string") {
        flag = "ms";
    }
    switch (flag) {
        case "ms":
            msCount = 1;
            break;
        case "s":
            msCount = 1000;
            break;
        case "m":
            msCount = 60 * 1000;
            break;
        case "h":
            msCount = 60 * 60 * 1000;
            break;
        case "d":
            msCount = 24 * 60 * 60 * 1000;
            break;
    }
    return Math.floor(diff / msCount);
};
Date.prototype.DateAdd = function (strInterval, Number) {
    var dtTmp = this;
    switch (strInterval) {
        case 's': return new Date(Date.parse(dtTmp) + (1000 * Number)); //秒
        case 'm': return new Date(Date.parse(dtTmp) + (60000 * Number)); //分
        case 'h': return new Date(Date.parse(dtTmp) + (3600000 * Number)); //时
        case 'd': return new Date(Date.parse(dtTmp) + (86400000 * Number)); //日
        case 'w': return new Date(Date.parse(dtTmp) + ((86400000 * 7) * Number)); //周
        case 'q': return new Date(dtTmp.getFullYear(), (dtTmp.getMonth()) + Number * 3, dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds()); //季度
        case 'M': return new Date(dtTmp.getFullYear(), (dtTmp.getMonth()) + Number, dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds()); //月
        case 'y': return new Date((dtTmp.getFullYear() + Number), dtTmp.getMonth(), dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds()); //年
    }
}
Date.prototype.Init = function (strTimne) {
    /// <summary>时间初始化</summary>
    /// <param name="strTimne" type="String">必须是 yyyy-MM-dd HH:mm:ss格式的字符串</param>
    var dateObg = this;
    return new Date(strTimne.replace(/-/g, "/"));
}



Date.StrToDate = function (strTime) {
    /// <summary>时间初始化</summary>
    /// <param name="strTimne" type="String">必须是 yyyy-MM-dd HH:mm:ss格式的字符串</param>
    return new Date(strTime.replace(/-/g, "/"));
}
function StrToDate(strTime) {
    /// <summary>时间初始化 作废 请使用Date.StrToDate modify by chenk 20121015 </summary>
    /// <param name="strTimne" type="String">必须是 yyyy-MM-dd HH:mm:ss格式的字符串</param>
    return new Date(strTime.replace(/-/g, "/"));
}
//#endregion

//#region 文本框初始化 只能输入数字且具有最大值最小值限制

function InputForNumAndMinOrMax(id, val, maxlength, oldval, min, max) {//mim:最小值 max:最大值
    if (oldval != "") {
        $("#" + id).val(oldval);
    } else {
        $("#" + id).val(val);
    }

    $("#" + id).attr("maxlength", maxlength)//文本框最大长度
    $("#" + id).focus(function () {
        if ($(this).val() == val) { $(this).val(''); }
    })
    $("#" + id).blur(function () {
        if ($(this).val() == '' || parseInt($(this).val()) < min || parseInt($(this).val()) > max) { $(this).val(val); }
    })
    $("#" + id).keyup(function () {
        $(this).val($(this).val().replace(/\D/g, ''));
    })
    $("#" + id).attr('class', 'input');
}
//#endregion

//#region url中传递+等特殊字符处理
function URLSpEncode(sStr) {
    return escape(sStr).replace(/\+/g, '%2B').replace(/\"/g, '%22').replace(/\'/g, '%27').replace(/\//g, '%2F');
}
//#endregion