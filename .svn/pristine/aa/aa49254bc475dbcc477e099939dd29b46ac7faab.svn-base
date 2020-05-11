; (function (exports) { 
    // 提示框(黄惊叹)
    function dalert(msg, title) {
        layer.alert(msg, {icon: 0, title: title || '提示'});
    }

    // 确认框
    // callback 为确定按钮回调函数
    function dconfirm(msg, title, callback) {
        if (arguments.length == 2) {
            if ($.isFunction(arguments[1])) {
                title = "";
                callback = arguments[1];
            } else {
                if (typeof arguments[1] !== 'string') {
                    title = "";
                }
            }
        } else {
            if (typeof arguments[1] !== 'string') {
                title = "";
            }
        }

        layer.confirm(msg, {icon: 3, title: title || '提示'}, function(index){
            $.isFunction(callback) && callback();
            layer.close(index);
        });
    }

    // 成功提示(绿勾)
    function dsuccess(msg, title) {
        layer.alert(msg, {icon: 1, title: title || '操作成功'});
    }

    // 失败提示(红叉)
    function dfail(msg, title) {
        layer.alert(msg, {icon: 2, title: title || '操作失败'});
    }

    // 异常提示(哭脸)
    function derror(msg, title) {
        layer.alert(msg, {icon: 5, title: title || '操作异常'});
    }

    // 全局错误，将禁止页面操作
    function sderror(msg) {
        layer.msg(msg, {icon: 5, shade: 0.5, shadeClose: false, time: 0});
    }

    // 页面加载动画，返回加载动画窗口编号
    function dload() {
        return layer.load(0, { shade:0.5,shadeClose:false });
    }

    exports.DIALOG = {
        ALERT: dalert, 
        CONFIRM: dconfirm, 
        SUCCESS: dsuccess, 
        FAIL: dfail, 
        ERROR: derror, 
        SYSTEMERROR: sderror, 
        LOADING: dload
    };
}(window));