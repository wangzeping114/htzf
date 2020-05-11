/**
* 日期格式化
* value 将要格式化的值
* format 格式化的格式
**/
function syFormatDate(value, format, isapi) {
    if (!value) {
        return "";
    }
    if (isapi) {
        value = GetDateRemoveT(value);
    }
    var date;
    if (/\/Date\((.*)\+.*\//.test(value)) {
        value = RegExp.$1;

        date = new Date();
        date.setTime(value);
    } else {
        if (typeof value === "string") {
            date = new Date(value);
        } else if (typeof value === "object") {
            date = value;
        } else {
            return "";
        }
    }

    try {
        var o = {
            "M+": date.getMonth() + 1,
            "d+": date.getDate(),
            "h+": date.getHours(),
            "m+": date.getMinutes(),
            "s+": date.getSeconds(),
            "q+": Math.floor((date.getMonth() + 3) / 3),
            "S": date.getMilliseconds()
        }

        if (/(y+)/.test(format)) {
            format = format.replace(RegExp.$1, (date.getFullYear() + "").substr(4 - RegExp.$1.length));
        }

        for (var k in o) {
            if (new RegExp("(" + k + ")").test(format)) {
                format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
            }
        }
    } catch (e) {
        return "";
    }
    return format;
}
function GetDateRemoveT(d) {
    var date = d.replace('T', ' ');
    return date;
}
/**
* 格式化金额，抹掉结尾的.00
**/
function syFormatMoney(value) {
    if (!value) {
        return "0";
    }

    if (typeof value !== "string") {
        value = value.toString();
    }

    return value.replace(/^(\d+)(?:\.0+$|(\.\d+?)0+$)/, "$1$2");
}
//格式化金额3个带逗号分隔
function syFormatIntervalMoney(pMoney) {
    pMoney = parseFloat((pMoney + "").replace(/[^\d\.-]/g, "")) + "";
    var oLeft = pMoney.split(".")[0].split("").reverse(), oRight = pMoney.split(".")[1];
    var oReturn = "";
    for (i = 0; i < oLeft.length; i++) {
        oReturn += oLeft[i] + ((i + 1) % 3 == 0 && (i + 1) != oLeft.length ? "," : "");
    }
    if (oRight) {
        return oReturn.split("").reverse().join("") + "." + oRight;
    }
    else {
        return oReturn.split("").reverse().join("");
    }
}
//是否包含某个字符串，忽略大小写
function syContainsString(subStr, str) {
    return str.toLowerCase().indexOf(subStr.toLowerCase()) >= 0
}
/**
** 乘法函数，用来得到精确的乘法结果
** 说明：javascript的乘法结果会有误差，在两个浮点数相乘的时候会比较明显。这个函数返回较为精确的乘法结果。
** 调用：syAccMul(arg1,arg2)
** 返回值：arg1乘以 arg2的精确结果
**/
function syAccMul(arg1, arg2) {
    var m = 0, s1 = arg1.toString(), s2 = arg2.toString();
    try {
        m += s1.split(".")[1].length;
    }
    catch (e) {
    }
    try {
        m += s2.split(".")[1].length;
    }
    catch (e) {
    }
    return Number(s1.replace(".", "")) * Number(s2.replace(".", "")) / Math.pow(10, m);
}

// 给Number类型增加一个mul方法，调用起来更加方便。
Number.prototype.mul = function (arg) {
    return syAccMul(arg, this);
};

/*
* 页面数据分页
*/
function syInitRecordsPage(container, pages, callback) {
    if (pages) {
        laypage({
            cont: $('#' + container), //容器。值支持id名、原生dom对象，jquery对象,
            pages: pages, //总页数
            skip: false, //是否开启跳页
            curr: function () { //通过url获取当前页，也可以同上（pages）方式获取
                var page = location.search.match(/page=(\d+)/);
                return page ? page[1] : 1;
            }(),
            jump: function (e, first) { //触发分页后的回调
                if (!first) { //一定要加此判断，否则初始时会无限刷新
                    if (!callback) {
                        var page = location.search.match(/page=(\d+)/);

                        if (page) {
                            location.href = location.href.replace("page=" + page[1], "page=" + e.curr);
                        } else {
                            location.href = location.href.indexOf("?") > 0 ? (location.href + "&page=" + e.curr) : "?page=" + e.curr;
                        }
                    } else {
                        callback(e.curr);
                    }
                }
            },
            skin: 'yahei',
            groups: 4 //连续显示分页数
        });
    } else {
        $("#" + container).empty();
    }
}


/**
* 初始化单选框
* name: 单选框name属性值
*/
function syInitRadio(name) {
    $("input[name='" + name + "']").bind("click", function () {
        if (this.checked) {
            $("input[name='" + name + "']").each(function () {
                var that = this;
                $("label[for='" + that.id + "'] .radio").removeClass("icon-dot-circle-o");
                $("label[for='" + that.id + "']").removeClass("icon-dot-circle-o");
            });

            $("label[for='" + this.id + "'] .radio").addClass("icon-dot-circle-o");
            $("label[for='" + this.id + "']").addClass("icon-dot-circle-o");
        }
    });

    $("input[name='" + name + "']").each(function () {
        if (this.checked) {
            $("label[for='" + this.id + "'] .radio").addClass("icon-dot-circle-o");
            $("label[for='" + this.id + "']").addClass("icon-dot-circle-o");
        }
    });
}

/**
* 初始化复选框
* name: 复选框name属性值
*/
function syInitCheckbox(name) {
    $("input[name='" + name + "']").bind("change", function () {
        if (this.checked) {
            $("label[for='" + this.id + "'] .checkbox").removeClass("icon-square-o").addClass("icon-check-square-o");
        } else if (!this.checked || $(this).attr("checked")) {
            $(this).removeAttr("checked")
            $("label[for='" + this.id + "'] .checkbox").removeClass("icon-check-square-o").addClass("icon-square-o");
        }
    });
    initView(name);

    function initView(name) {
        $("input[name='" + name + "']").each(function () {
            if ($(this).prop("checked")) {
                this.checked = true;
                $("label[for='" + this.id + "'] .checkbox").removeClass("icon-square-o").addClass("icon-check-square-o");
            } else {
                $("label[for='" + this.id + "'] .checkbox").removeClass("icon-check-square-o").addClass("icon-square-o");
            }
            if ($(this).attr('disabled') == 'disabled') {
                $('label[for="' + this.id + '"] .checkbox').removeClass('text-sub').addClass('text-gray');
            } else {
                $('label[for="' + this.id + '"] .checkbox').removeClass('text-gray').addClass('text-sub');
            }
        });
    }

    return {
        initView: initView
    };
}
/**
* 删除左右两端的空格
*/
String.prototype.trim=function()
{
    return this.replace(/(^\s*)|(\s*$)/g, '');
}
/**
* 删除左边的空格
*/
String.prototype.ltrim=function()
{
    return this.replace(/(^\s*)/g,'');
}
/**
* 删除右边的空格
*/
String.prototype.rtrim=function()
{
    return this.replace(/(\s*$)/g,'');
}
/**
* 打开上传图片选择窗口
* url: 图片上传操作页面地址
* method: 图片上传回调方法名
* xscale: 当需要裁切图片时，需要的图片横向比例
* yscale: 当需要裁切图片是，需要的图片纵向比例
*/
function syOpenUploadImgDialog(opts) {
    if (!opts.method) {
        layer.open({
            content: '图片上传缺少回调方法名',
            scrollbar: false
        });
        return;
    } else {
        opts.url += "?method=" + opts.method;
    }
    if (opts.totalGraph) {
        opts.url += "&totalGraph=" + opts.totalGraph;
    }
    if (opts.xscale && opts.yscale) {
        opts.url += '&xscale=' + opts.xscale + '&yscale=' + opts.yscale;
        opts.area = ['750px', '540px'];
    } else {
        opts.area = ['350px', '200px'];
    }
    if (opts.Compress) {
        opts.url += "&Compress=" + opts.Compress;
    }
    layer.open({
        title: "图片上传",
        type: 2,
        area: opts.area,
        fix: false,
        maxmin: true,
        content: opts.url
    });
}


function syUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var ss = decodeURIComponent(location.search);
    var r = ss.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
function syShowMsg(pMsg) {
    layer.open({
        content: '<div class="dialog-module"><div class="dialog-module-inner"><p class="popup-text font-size-14">' + pMsg + '</p></div><div class="dialog_close_btn "><a href="javascript:;" onclick="layer.closeAll();"></a></div></div>'
                    , btn: '确定'
    });
}
function syAjaxErrorBack(XMLHttpRequest, textStatus, errorThrown) {
    syIsClicked = false;
    layer.closeAll();
    syShowMsg('网络错误，请稍后尝试！');
}
function syJsonSafe(obj) {
    var oBackStr = JSON.stringify(obj);
    oBackStr = oBackStr.replace(/\+/g, "%2B");
    return escape(oBackStr);
}
function syAjax(pType, pIsAsync, pUrl, pAppKeyId, pParam, pCallback, pErrorBack) {
    setTimeout(function () {
        $.ajax({
            type: pType,
            url: pUrl,
            beforeSend: function (request) {
                request.setRequestHeader("appKeyId", pAppKeyId);
            },
            data: pParam,
            dataType: "JSON",
            async: pIsAsync,
            success: function (json) {
                if (json != null && json.StatusCode == undefined)
                    var json = $.parseJSON(json);
                pCallback && pCallback(json);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                if (pErrorBack) {
                    pErrorBack(XMLHttpRequest, textStatus, errorThrown);
                }
                else {
                    syAjaxErrorBack(XMLHttpRequest, textStatus, errorThrown);
                }
            }
        });
    }, 0);
}

function syPostFile(pType, pIsAsync, pUrl, pAppKeyId, pParam, pCallback, pErrorBack) {
    console.log("pUrl",pUrl);
    $.ajax({
        type: pType,
        url: pUrl,
        beforeSend: function (request) {
            request.setRequestHeader("appKeyId", pAppKeyId);
        },
        data: pParam,
        dataType: "JSON",
        contentType: "application/x-www-form-urlencoded",
        processData: false,
        success: function (json) {
            if (json != null && json.StatusCode == undefined)
                var json = $.parseJSON(json);
            pCallback && pCallback(json);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            if (pErrorBack) {
                pErrorBack(XMLHttpRequest, textStatus, errorThrown);
            }
            else {
                syAjaxErrorBack(XMLHttpRequest, textStatus, errorThrown);
            }
        }
    });
};
/**
   * 动态加载JS
   * @param {string} url 脚本地址
   * @param {function} callback  回调函数
   */
function syDynamicLoadJs(url, callback) {
    var head = document.getElementsByTagName('head')[0];
    var script = document.createElement('script');
    script.type = 'text/javascript';
    script.src = url;
    if (typeof (callback) == 'function') {
        script.onload = script.onreadystatechange = function () {
            if (!this.readyState || this.readyState === "loaded" || this.readyState === "complete") {
                callback();
                script.onload = script.onreadystatechange = null;
            }
        };
    }
    head.appendChild(script);
}
/**
* 动态加载CSS
* @param {string} url 样式地址
*/
function syLoadCss(pUrl) {
    var head = document.getElementsByTagName('head')[0];
    var link = document.createElement('link');
    link.type = 'text/css';
    link.rel = 'stylesheet';
    link.href = pUrl;
    head.appendChild(link);
}
/* 
* url 目标url 
* arg 需要替换的参数名称 
* arg_val 替换后的参数的值 
* return url 参数替换后的url 
*/
function syChangeURLArg(url, arg, arg_val) {
    var pattern = arg + '=([^&]*)';
    var replaceText = arg + '=' + arg_val;
    if (url.match(pattern)) {
        var tmp = '/(' + arg + '=)([^&]*)/gi';
        tmp = url.replace(eval(tmp), replaceText);
        return tmp;
    } else {
        if (url.match('[\?]')) {
            return url + '&' + replaceText;
        } else {
            return url + '?' + replaceText;
        }
    }
    return url + '\n' + arg + '\n' + arg_val;
} 