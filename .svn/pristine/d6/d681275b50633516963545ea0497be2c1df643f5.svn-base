!(function (win, undefined) {
    var _default = {
        container: null,
        width: '100%',              // 容器宽度
        height: '100%',             // 容器高度
        nodes: [],                  // 节点数组
        max_level: 3,               // 最大层级数
        max_children: 5             // 每层最多节点数
    };
    var style = document.createElement('style');
    style.type = 'text/css';
    var css = [];
    css.push('.tree-box,.tree-edit-box{display:inline-block;vertical-align:top;height:100%;padding:5px;}');
    css.push('.tree-box{width:35%;min-width:300px;border:1px solid #ddd;}');
    css.push('.tree-edit-box{width:50%;min-width:400px;margin-left:5px;}');
    css.push('.tree-box .button{padding:3px 5px;margin-left:5px;}');
    css.push('.tree-box .button[class*="icon-"]:before{margin-right:0;}');
    css.push('.tree-title span{font-size:18px;line-height:40px;}');
    css.push('.tree-list{margin:10px 0;}');
    css.push('.tree-item>.tree-list{padding-left:20px;}');
    css.push('.tree-item-title{width:100%;line-height:25px;}');
    css.push('.tree-bg{background-color:#dedede;}');
    style.innerHTML = css.join('');
    $('head').append(style);

    var yTree = function () { }

    yTree.prototype = {
        _bindEvents: function () {
            var that = this,
                conf = that.conf,
                container = that.container;

            $('.tree-box', container).on('click', '.tree-title .icon-plus', function () {
                $('.tree-bg', container).removeClass('tree-bg');
                that.curLevel = "";
                that.curIndex = "0";
                that.action = 'add';

                $('.menu-name', container).focus();
            }).on('click', '.tree-item-title .icon-plus', function () {
                var el = $(this);

                $('.tree-bg', container).removeClass('tree-bg');
                that.curLevel = el.closest('.tree-item-title').addClass('tree-bg').attr('data-level');
                that.curIndex = el.closest('.tree-item').index();
                that.action = 'add';

                that._clearInput();
                $('.menu-name', container).focus();
            }).on('click', '.icon-edit', function () {
                var el = $(this);

                $('.tree-bg', container).removeClass('tree-bg');
                that.curLevel = el.closest('.tree-item-title').addClass('tree-bg').attr('data-level');
                that.curIndex = el.closest('.tree-item').index();
                that.action = 'mod';

                var nodes = that.conf.nodes;
                var levels = that.curLevel.split('-');
                var obj = $.extend([], nodes);

                $.each(levels, function (i, item) {
                    obj = obj[item];
                    i + 1 < levels.length && (obj = obj.sub_button);
                });
                $(".divmsgorurl").show();
                $(".divminiprogram").hide();

                $('.menu-name', container).val(obj.name);
                $('.menu-type', container).val(obj.type);
                if (obj.type == "click" || obj.type == "scancode_push") {
                    $('.menu-link', container).val(obj.key);
                }
                else if (obj.type == "miniprogram") {
                    $(".divmsgorurl").hide();
                    $(".divminiprogram").show();
                    $('.pageurlpath', container).val(obj.url);
                    $('.appid', container).val(obj.appid);
                    $('.pagepath', container).val(obj.pagepath);
                }
                else {
                    $('.menu-link', container).val(obj.url);
                }

            }).on('click', '.icon-trash-o', function () {
                var el = $(this);

                $('.tree-bg', container).removeClass('tree-bg');
                that.curLevel = el.closest('.tree-item-title').addClass('tree-bg').attr('data-level');
                that.curIndex = el.closest('.tree-item').index();
                that.action = 'del';

                DIALOG.CONFIRM('是否确认删除此节点？<br/>(同时删除所有子节点)', '确认', function () {
                    var nodes = that.conf.nodes;
                    var levels = that.curLevel.split('-');
                    var obj = $.extend([], nodes);

                    for (var i = 0, len = levels.length; i < len; i++) {
                        if (i == len - 1) {
                            len == 1 ? nodes.splice(levels[i], 1) : obj.sub_button.splice(levels[i], 1);
                        } else {
                            obj = obj[levels[i]];
                        }
                    }

                    that.node_box.empty();
                    $.each(nodes, function (i, item) {
                        that._render('' + i, item);
                    });
                });
            }).on('click', '.icon-minus-square-o,.icon-plus-square-o', function () {
                var el = $(this);
                el.toggleClass('icon-minus-square-o').toggleClass('icon-plus-square-o');
                el.closest('.tree-item-title').siblings('.tree-list').toggle();
            });

            $('.tree-edit-box', container).on('click', '.button-sure', function () {
                if (!that.action) {
                    DIALOG.ALERT('请选择目标节点');
                    return;
                }
                var menu_name = $('.menu-name', container).val();
                var menu_link = $('.menu-link', container).val();
                    menu_link = menu_link.replace(/\s+/g, "");   //去除空格  
                var menu_type = $('.menu-type', container).val();
                if (!menu_name) {
                    DIALOG.ALERT('请输入菜单名称');
                    return;
                }
                if ((menu_type == "view" || menu_type == "click") && !menu_link) {
                    DIALOG.ALERT('请输入菜单内容');
                    return;
                }

                var nodes = that.conf.nodes;
                var levels = that.curLevel.split('-');
                var obj = $.extend([], nodes);
                if (that.curLevel) {
                    for (var i = 0, len = levels.length; i < len; i++) {
                        obj = obj[levels[i]];
                        i + 1 < levels.length && (obj = obj.sub_button);
                    }
                }

                if (that.action == 'add') {
                    var node = {
                        name: menu_name,
                        type: menu_type,
                        sub_button: []
                    };
                    if (menu_type == "click" || menu_type == "scancode_push") {
                        node.key = menu_link;
                    }
                    else if (menu_type == "miniprogram") {
                        menu_link = $('.pageurlpath', container).val();
                        var appid = $('.appid', container).val();
                        var pagepath = $('.pagepath', container).val();
                        if (!menu_link) {
                            layer.msg("【跳转不成功的网页地址】必须填写!")
                            return;
                        }
                        if (!pagepath) {
                            layer.msg("【小程序页面路径】必须填写!")
                            return;
                        }
                        if (!appid) {
                            layer.msg("【小程序的appid】必须填写!")
                            return;
                        }
                        node.url = menu_link;
                        node.appid = appid;
                        node.pagepath = pagepath;
                    }
                    else {
                        node.url = menu_link;
                    }
                    if (that.curLevel == "") {
                        nodes.push(node);
                    } else {
                        obj.sub_button || (obj.sub_button = []);
                        obj.sub_button.push(node);
                    }
                } else if (that.action == 'mod') {
                    obj.type = menu_type;
                    obj.name = menu_name;
                    if (menu_type == "click" || menu_type == "scancode_push") {
                        obj.key = menu_link
                    }
                    else if (menu_type == "miniprogram") {
                        menu_link = $('.pageurlpath', container).val();
                        var appid = $('.appid', container).val();
                        var pagepath = $('.pagepath', container).val();
                        if (!menu_link) {
                            layer.msg("【跳转不成功的网页地址】必须填写!")
                            return;
                        }
                        if (!pagepath) {
                            layer.msg("【小程序页面路径】必须填写!")
                            return;
                        }
                        if (!appid) {
                            layer.msg("【小程序的appid】必须填写!")
                            return;
                        }
                        obj.url = menu_link;
                        obj.appid = appid;
                        obj.pagepath = pagepath;
                    }
                    else {
                        obj.url = menu_link
                    }
                } else {
                    return;
                }

                that.node_box.empty();
                $.each(nodes, function (i, item) {
                    that._render('' + i, item);
                });

                that._clearInput();
            }).on('click', '.button-cancel', function () {
                that._clearInput();
            });
        },
        build: function (options) {
            var that = this;
            that.conf = $.extend(true, {}, _default, options);
            that.container = that.conf.container;
            typeof that.container == 'string' && (that.container = $(that.container));

            if (!that.container || that.container.length == 0) {
                console.error('容器未设置');
                return;
            }

            that._render_box();
            this._bindEvents();
        },
        getNodes: function () {
            var that = this;

            return $.extend(true, [], that.conf.nodes);
        },
        _render_box: function () {
            var that = this,
                conf = that.conf,
                container = that.container;
            var arr = [];
            arr.push('<div style="min-width:750px;margin:5px;width:' + conf.width + ';height:' + conf.height + ';">');
            arr.push('<div class="tree-box">');
            arr.push('<div class="tree-title">');
            arr.push('<span>编辑微信菜单</span>');
            arr.push('<button type="button" class="button button-small border-green icon-plus" title="添加一级菜单"></button>');
            arr.push('</div>');
            arr.push('<div class="tree-list">');
            arr.push('</div>');
            arr.push('</div>');
            arr.push('<div class="tree-edit-box">');
            arr.push('<h3>节点信息编辑</h3>');
            arr.push('<hr />');
            arr.push('<div class="form">');
            arr.push('<div class="form-group">');
            arr.push('<div class="label"><label>菜单名称：</label></div>');
            arr.push('<div class="field">');
            arr.push('<input type="text" class="input menu-name" maxlength="50" />');
            arr.push('<div class="text-red">字数不超过4个汉字或8个字母</div>');
            arr.push('</div>');
            arr.push('</div>');
            arr.push('<div class="form-group">');
            arr.push('<div class="label"><label>菜单类型：</label></div>');
            arr.push('<div class="field">');
            arr.push('<select class="menu-type" onchange="changeMenuType(this)"><option value="">按钮组</option><option value="view">跳转网页</option><option value="miniprogram">小程序</option><option value="click">发送消息</option><option value="scancode_push">扫一扫</option></select>');
            arr.push('<div class="text-red">创建按钮组菜单，如果不创建子菜单，在生成公众号菜单的时候将会报错</div>');
            arr.push('</div>');
            arr.push('</div>');
            arr.push('<div class="divminiprogram">');
            arr.push('<div class="form-group">');
            arr.push('<div class="label"><label>跳转不成功的网页地址：</label></div>');
            arr.push('<div class="field">');
            arr.push('<input type="text" class="input pageurlpath" ></input>');
            arr.push('</div>');
            arr.push('</div>');
            arr.push('<div class="form-group">');
            arr.push('<div class="label"><label>小程序页面路径：</label></div>');
            arr.push('<div class="field">');
            arr.push('<input type="text" class="input pagepath" ></input>');
            arr.push('</div>');  
            arr.push('</div>');


            arr.push('<div class="form-group">');
            arr.push('<div class="label"><label>小程序appid：</label></div>');
            arr.push('<div class="field">');
            arr.push('<input type="text" class="input appid" ></input>');
            arr.push('</div>');
            arr.push('</div>');
            arr.push('</div>');
            arr.push('<div class="form-group divmsgorurl">');
            arr.push('<div class="label"><label>菜单内容：</label></div>');
            arr.push('<div class="field">');
            arr.push('<textarea class="input menu-link" cols="20" rows="5"></textarea>');
            arr.push('<div class="text-red">网页地址请输入完整的路径<br/>发送消息为消息命令(联系美顾问)</div>');
            arr.push('</div>');
            arr.push('</div>');
            arr.push('</div>');
            arr.push('<div class="margin-top text-center">');
            arr.push('<button type="button" class="button button-small border-blue icon-check button-sure">确认编辑</button> ');
            arr.push('<button type="button" class="button button-small border-gray icon-times button-cancel">取消编辑</button>');
            arr.push('</div>');
            arr.push('</div>');
            arr.push('</div>');

            container.html(arr.join(''));
            $(".divminiprogram").hide();
            that.node_box = $('.tree-box>.tree-list');

            $.each(that.conf.nodes, function (i, item) {
                that._render('' + i, item);
            });
        },
  
        _render: function (level, node, parent) {
            that = this;
            parent || (parent = that.node_box);
            var sub_button = node.sub_button;

            var arr = [];
            arr.push('<div class="tree-item">');
            arr.push('<div class="tree-item-title" data-level="' + level + '">');
            sub_button && sub_button.length > 0 && arr.push('<span class="icon-expand icon-minus-square-o"></span>');
            arr.push('<span class="text">' + node.name + '</span>');
            level.split('-').length < that.conf.max_level && arr.push('<span class="button button-small border-sub icon-plus" title="添加子菜单"></span>');
            arr.push('<span class="button button-small border-yellow icon-edit" title="编辑菜单"></span>');
            arr.push('<span class="button button-small border-red icon-trash-o" title="删除菜单"></span>');
            arr.push('</div>');
            sub_button && sub_button.length > 0 && arr.push('<div class="tree-list"></div>');
            arr.push('</div>');
            var _el = $(arr.join(''));
            _el.appendTo(parent);

            if (sub_button && sub_button.length > 0) {
                $.each(sub_button, function (i, item) {
                    that._render(level + '-' + i, item, $('.tree-list', _el)[0]);
                });
            }
        },
        _clearInput: function () {
            var that = this,
                container = that.container;
            $(".divmsgorurl").show();
            $(".divminiprogram").hide();
            $('.menu-name,.menu-link,.menu-type', container).val('');
        }
    };

    win.yTree = new yTree();
})(window);
function changeMenuType(pObj) {
    if ($(pObj).val() == "miniprogram") {
        $(".divmsgorurl").hide();
        $(".divminiprogram").show();
    }
    else {
        $(".divmsgorurl").show();
        $(".divminiprogram").hide();
    }
}