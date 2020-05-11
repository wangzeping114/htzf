
function jsAlert(title, text, type, url) {
    var color = "#8CD4F5";//默认颜色
    switch (type) {
        case "warning":
            color = "#DD6B55";
            break;
        case "error":
            color = "#DD6B55";
            break;
        default:
            break;
    }
    swal({
        title: title,
        text: text,
        type: type,
        confirmButtonColor: color,
        confirmButtonText: "确定"
    }, function (isConfirm) {
        location.href = url;
    });
}

function jsConfirm(title, text, type,okCallback,cancelCallback) {
    var color = "#8CD4F5";//默认颜色
    switch (type) {
        case "warning":
            color = "#DD6B55";
            break;
        case "error":
            color = "#DD6B55";
            break;
        default:
            break;
    }
    swal({
        title: title,
        text: text,
        type: type,
        showCancelButton: true,
        confirmButtonColor: color,
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        closeOnConfirm: false,
        closeOnCancel: false
    },
    function (isConfirm) {
        if (isConfirm) {
            okCallback();
        } else {
            cancelCallback();
        }
    });
}

function jsTips(title, text, type) {
    swal({
        title: title,
        text: text,
        type: type,
        timer: 3000,
        showConfirmButton: false
    });
}
