require.config({
    urlArgs: "v=" + (new Date()).getTime(),
    baseUrl: "/content/js/",
    paths: {
        domReady: "require/domReady",
        jquery: "jquery/jquery-1.9.1.min",
        table: "require/bootstrap-table",
        scroll: "require/jquery.mCustomScrollbar.concat.min",
        avalon: "avalon/avalon.shim",
        layer: "layer/layer",
        common: "modules/common",
        layerM: "modules/layerM",
        menu: "modules/menu"
    },
    shim: {
        "common": {
            deps: ["jquery"]
        },
        "table": {
            deps: ["jquery"]
        },
        "scroll": {
            deps: ["jquery"]
        },
        "layerM": {
            deps: ["jquery"]
        }
    }
})
require(["domReady!", "jquery", "common", "table", "menu", "layerM", "avalon"], function (domReady, $, common, table, _, m, avalon) {
    common.loaded();
    _.init();
    avalon.define("data", function (vm) {
        vm.add = function () {
            m.open("/Menu/Edit", "新增菜单", "800px", "500px");
        };
        vm.edit = function () {
            var rows = $("#datagrid1").bootstrapTable("getSelections");
            var id = common.getId(rows);
            if (id > 0) {
                m.open("/Menu/Edit/" + id, "新增菜单", "800px", "500px");
            } else {
                m.alert("请先选择一条记录");
            }
        };
        vm.del = function () {
            var rows = $("#datagrid1").bootstrapTable("getSelections");
            var ids = common.getIds(rows);
            if (ids) {
                m.alert(ids);
            } else {
                m.alert("请先选择一条记录");
            }
        }
    })
    avalon.scan();
})