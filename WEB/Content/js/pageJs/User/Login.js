require.config({
    urlArgs: "v=" + (new Date()).getTime(),
    baseUrl: "/content/js/",
    paths: {
        domReady: "require/domReady",
        jquery: "jquery/jquery-1.9.1.min",
        avalon: "avalon/avalon.shim",
        layer: "layer/layer",
        layerM: "modules/layerM"
    },
    shim: {
        "layerM": {
            deps: ["jquery"]
        }
    }
})
require(["domReady!", "jquery", "layerM", "avalon"], function (domReady, $, m, avalon) {
    avalon.define("data", function (vm) {
        vm.returnUrl = $("#returnUrl").val();
        vm.login = function () {
            var userName = $("#userName").val(),
                passWord = $("#passWord").val();
            m.loading();
            $.ajax({
                url: "/User/Login",
                type: "post",
                dataType: "json",
                data: {
                    userName: userName,
                    passWord: passWord,
                    returnUrl: vm.returnUrl
                },
                success: function (json) {
                    m.loaded();
                    if (!json.Result)
                        m.alert("登录失败：" + json.Message)
                    else {
                        window.location.href = json.Message;
                    }
                },
                error: function (xhr) {
                    m.loaded();
                    m.alert("操作失败：" + xhr.statusText);
                }
            });
        };
        vm.forget = function () {
            m.alert("forget");
        };
    })
    avalon.scan();
})