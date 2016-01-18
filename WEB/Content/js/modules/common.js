define(["jquery"], function ($) {
    /*
    * js string trim
    */
    String.prototype.trim = function () {
        return this.replace(/(^\s*)|(\s*$)/g, "");
    }
    /*
    * js string convert to int
    */
    String.prototype.toInt = function () {
        return parseInt(this.trim()) || 0;
    }
    /*
    * js array first
    */
    Array.prototype.first = function () {
        return this[0];
    }
    /*
    * js array last
    */
    Array.prototype.last = function () {
        return this[this.length - 1];
    }
    /*
    * page loaded and avalon scan
    */
    function _loaded() {
        $(".loading").hide();
    }
    /*
    * get table select id
    */
    function _getId(arr) {
        var id = 0;
        if (typeof arr === "object" && arr) {
            var row = arr.first();
            if (row) {
                id = row.ID.toInt();
            }
        }
        return id;
    }
    /*
    * get table select ids
    */
    function _getIds(arr) {
        var ids = new Array()
        if (typeof arr === "object" && arr) {
            for (var i = 0; i < arr.length; i++) {
                ids.push(arr[i].ID.toInt());
            }
        }
        console.log(ids);
        return ids.join(",");
    }
    return {
        loaded: _loaded,
        getId: _getId,
        getIds: _getIds
    }
})