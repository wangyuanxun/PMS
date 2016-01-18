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
        vm.save = function () {
            var model = new Object();
            model.ID = $("#ID").val();
            model.ParentID = $("#ParentID").val();
            model.MenuName = $("#MenuName").val();
            model.LinkUrl = $("#LinkUrl").val();
            model.OrderIndex = $("#OrderIndex").val();
            model.Intro = $("#Intro").val();
            model.MenuImg = "";
            m.loading();
            $.ajax({
                url: "/Menu/Edit",
                type: "post",
                dataType: "json",
                data: {
                    id: model.ID,
                    parentID: model.ParentID,
                    menuName: model.MenuName,
                    linkUrl: model.LinkUrl,
                    orderIndex: model.OrderIndex,
                    intro: model.Intro,
                    menuImg: model.MenuImg
                },
                success: function (json) {
                    m.loaded();
                    if (!json.Result)
                        m.alert("保存失败")
                    else {
                        m.alert("保存成功", function () {
                            parent.location.reload();
                        });
                    }
                },
                error: function (xhr) {
                    m.loaded();
                    m.alert("操作失败：" + xhr.statusText);
                }
            });
        };
        vm.close = function () {
            m.close(window.name);
        };
    })
    avalon.scan();
})