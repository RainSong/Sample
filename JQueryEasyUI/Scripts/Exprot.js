
(function () {
    exportHelper = {};
    function exportObj() {
        var o = new Object();
        o.style = "";
        o.rClass = "";
        o.lab = "";
        o.items = [];
        o.toString = function () {
            var html = "<" + o.lab;
            if (o.style && o.style.length > 0) {
                html += ' style="' + o.style + '"';
            }
            if (o.rClass && o.style.length > 0) {
                html += ' class="' + o.rClass + '"';
            }
            html += ">";
            if (o.items) {
                for (var i = 0, j = o.items.length; i < j; i++) {
                    if (o.items[i]) {
                        html += o.items[i].toString();
                    }
                }
            }
            html += "</" + o.lab + ">";
            return html;
        };
        return o;
    }
    function table() {
        var t = new exportObj();
        t.lab = "table";
        return t;
    }
    function row() {
        var r = new exportObj();
        r.lab = "tr"
        return r;
    }
    function cell() {
        var c = new exportObj();
        c.lab = "td";
        c.field = "";
        c.value = "";
        c.rowspan = 0;
        c.colspan = 0;
        c.toString = function () {
            var html = "<td";
            if (c.style) {
                html += ' style="' + c.style + '"';
            }
            if (c.rClass) {
                html += ' class="' + c.rClass + '"';
            }
            if (c.rowspan && c.rowspan > 0) {
                html += ' rowspan="' + c.rowspan.toString() + '"';
            }
            if (c.colspan && c.colspan > 0) {
                html += ' colspan="' + c.colspan.toString() + '"';
            }
            html += ">";
            if (c.value) {
                html += c.value.toString();
            }
            html += "</td>";
            return html;
        };
        return c;
    }

    exportHelper.getExportHtml = function (data, fields) {
        var t = new table();
        if (data && fields && fields.length > 0) {
            for (var i = 0, j = data.length; i < j; i++) {
                var r = new row();
                for (var m = 0, n = fields.length; m < n; m++) {
                    var c = new cell();
                    c.value = data[i][fields[m]];
                    r.items.push(c);
                }
                t.items.push(r);
            }
        }
        return t.toString();
    };
}());