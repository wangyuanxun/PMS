define(["jquery", "layer"], function ($, layer) {
    layer.config({ path: "/content/js/layer/" });
    /*
    * alert
    */
    function _alert(msg, yes, icon) {
        msg = msg || "";
        icon = icon || 0;
        if (typeof yes !== "function")
            layer.alert(msg, { icon: icon });
        else
            layer.alert(msg, { icon: icon }, yes);
    }
    /*
    * question
    */
    function _confirm(msg, yes, cancel) {
        msg = msg || "";
        yes = yes || function () { };
        cancel = cancel || function () { };
        layer.confirm(msg, { icon: 3, title: "\u7cfb\u7edf\u63d0\u793a" }, yes, cancel);
    }
    /*
    * window open
    */
    function _open(url, title, width, height) {
        title = title || "\u7cfb\u7edf";
        width = width || "50%";
        height = height || "50%";
        layer.open({
            type: 2,
            title: title,
            shadeClose: true,
            shade: 0.8,
            area: [width, height],
            content: url
        });
    }
    /*
    * window close
    */
    function _close(name) {
        var index = parent.layer.getFrameIndex(name);
        parent.layer.close(index)
    }
    /*
    * tip
    */
    function _tip(msg, obj, opt) {
        if (obj) {
            msg = msg || "";
            opt = opt || { tips: 2, tipsMore: true };
            layer.tips(msg, obj, opt);
        }
    }
    /*
    * loading
    */
    function _loading() {
        layer.load();
    }
    /*
    * close loading
    */
    function _loaded() {
        layer.closeAll("loading");
    }
    return {
        alert: _alert,
        confirm: _confirm,
        open: _open,
        close: _close,
        tip: _tip,
        loading: _loading,
        loaded: _loaded
    }
})