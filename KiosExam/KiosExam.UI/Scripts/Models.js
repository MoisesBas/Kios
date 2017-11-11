//detect if browser used is mobile
var models_isMobile = false;
var ajaxqueues = [];
if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
    models_isMobile = true;
}

String.prototype.trunc = function (n) {
    return this.substr(0, n - 1) + (this.length > n ? '...' : '');
};

function models_debug_notify(title, msg) {
    var mode = 1;
    if (mode == 1) {        
        $.noticeAdd({
            title: title,
            text: msg,
            stay: false
        });
    }

}

function models_notify(title, msg, timeout, guid) {
    var mode = 1;
    timeout = (timeout != null) ? timeout : 3000;
    guid = guid == null ? models_GUID() : guid;

    if (mode == 1) {

        $.noticeAdd({
            title: title,
            text: msg,
            stay: timeout == 0 ? true : false,
            stayTime: timeout,
            guid: guid
        });
    }

    return guid;

}

function models_extractVal(object, settings) {
    var dateformat = (settings) ?
        (settings.dateformat) ?
            settings.dateformat :
            "YYYY-MM-DD" :
        "YYYY-MM-DD";

    if (object != null) {
        if (typeof object == "string") {
            return (object.indexOf('Date') > -1) ? moment(object).format(dateformat) : object;
        } else {
            return object;
        }
    } else {
        return (settings) ?
            (settings.defaultvalue) ?
                settings.defaultvalue :
                '' :
            '';
    }
}

function models_date(str, defaultval, format) {
    defaultval = defaultval ? defaultval : "";
    format = format ? format : "YYYY-MM-DD";
    return str ? moment(str).format(format) : defaultval;
}

function models_countWords(s) {
    s = s.replace(/(^\s*)|(\s*$)/gi, "");
    s = s.replace(/[ ]{2,}/gi, " ");
    s = s.replace(/\n /, "\n");
    return s.split(' ').length;
}

function models_GUID() {
    var guid = "";
    'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        guid += v.toString(16);
    });
    return guid;
}

function models_clone(obj) {
    if (null == obj || "object" != typeof obj) return obj;
    var copy = obj.constructor();
    for (var attr in obj) {
        if (obj.hasOwnProperty(attr)) copy[attr] = obj[attr];
    }
    return copy;
}

function models_cloneClass(obj) {
    return jQuery.extend(true, {}, obj);
}


function models_getURLParameter(name) {
    return decodeURI(
        (RegExp(name + '=' + '(.+?)(&|$)').exec(location.search) || [, null])[1]
    );
}

Number.prototype.formatMoney = function (decPlaces, thouSeparator, decSeparator) {
    var n = this,
        decPlaces = isNaN(decPlaces = Math.abs(decPlaces)) ? 2 : decPlaces,
        decSeparator = decSeparator == undefined ? "." : decSeparator,
        thouSeparator = thouSeparator == undefined ? "," : thouSeparator,
        sign = n < 0 ? "-" : "",
        i = parseInt(n = Math.abs(+n || 0).toFixed(decPlaces)) + "",
        j = (j = i.length) > 3 ? j % 3 : 0;
    return sign + (j ? i.substr(0, j) + thouSeparator : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + thouSeparator) + (decPlaces ? decSeparator + Math.abs(n - i).toFixed(decPlaces).slice(2) : "");
};

String.prototype.toDate = function (str) {
    return models_extractVal(str, { dateformat: "YYYY-MM-DD" });
}

Number.prototype.toTime = function (inputUnit) {
    switch (inputUnit) {
        case "M":
        case "m":
            outm = parseInt(this);
            outh = parseInt(outm / 60);
            outm = outm % 60;

            if (outm == 60) {
                outh++;
                outm = 0;
            }
            return (outh > 0 ? outh + ':' : '0:') + (outm > 0 ? outm.pad(2) : '00');
            break;
        case "H":
        case "h":
            outh = parseInt(this);
            outm = parseInt(Math.ceil((this - parseInt(this)) * 60))
            if (outm == 60) {
                outh++;
                outm = 0;
            }
            return (outh > 0 ? outh + ':' : '0:') + (outm > 0 ? outm.pad(2) : '00');
            break;
        default:
            outh = parseInt(this);
            outm = parseInt(Math.ceil((this - parseInt(this)) * 60))
            if (outm == 60) {
                outh++;
                outm = 0;
            }
            return (outh > 0 ? outh + ':' : '0:') + (outm > 0 ? outm.pad(2) : '00');
            break;

    }

}

Number.prototype.pad = function (size) {
    var s = "000000000000" + this;
    var orig = this;
    if (s.substr(s.length - size).length < orig.toString().length) {
        return orig;
    } else {
        return s.substr(s.length - size);
    }
}


function models_maximizeModal(id) {
    $("#" + id)
        .width($(document).width() - 10)
        .css("margin-left", "-" + (($(document).width() - 10) / 2) + "px");
}

function models_maximizedown() {
    models_maximizedown_refresh();

    $('.tabs').each(function (index, tabelement) {
        //Look for maximizedown class on tabelement if it is not seen, code is not executed
        if ($(tabelement).find(".maximizedown").length > 0) {
            $(tabelement).find('.nav-tabs').find("a").bind('click', function (e) {

                $(tabelement).find(".maximizedown").each(function (index, el) {
                    $(el).css('overflow', 'hidden');
                    $(el).height(150);
                });

                var t = setTimeout(function () {
                    models_maximizedown_refresh();
                    clearTimeout(t);
                }, 20);

            });
        }
    });

    $(window).resize(function () {
        models_maximizedown_refresh();
    });
}

function models_maximizedown_refresh() {

    if (window.innerWidth < 768) {
        if (models_isMobile) {
            $(document).find(".maximizedown").each(function (index, el) {
                $(el).css('overflow-y', 'none').css('height', 'auto');
            });

            return;
        }


    }

    $.each($(".maximizedown"), function (index, el) {
        var pagecontrolheight = 0;
        if ($(el).attr('class').indexOf('paged3') != -1)
            pagecontrolheight = 98;

        if ($(el).attr('class').indexOf('paged2') != -1)
            pagecontrolheight = 60;

        if ($(el).attr('class').indexOf('paged') != -1)
            pagecontrolheight = 40;

        if ($(el).attr('class').indexOf('paged4') != -1)
            pagecontrolheight = 61;

        if ($(el).attr('class').indexOf('paged5') != -1)
            pagecontrolheight = 30;


        $(el).css('overflow', 'auto');

        var totalpadding = parseInt($(el).css('padding-top').replace('px', ''));
        totalpadding += parseInt($(el).css('padding-bottom').replace('px', ''));
        $(el).height($(window).height() - el.offsetTop - totalpadding - 20 - pagecontrolheight);

    });

    $(".maximizedowninner").each(function (index, el) {
        var pagecontrolheight = $(el).attr('class').indexOf('paged') != -1 ? 50 : 0;
        var totalpadding = parseInt($(el).css('padding-top').replace('px', ''));
        totalpadding += parseInt($(el).css('padding-bottom').replace('px', ''));
        $(el).height($(window).height() - 40 - $(el).offset().top - pagecontrolheight);
    });

}

function models_dropdown(parentElement, dropdownbox, height, width) {

    var offset = parentElement.offset();

    dropdownbox
        .css('position', 'absolute')
        .css('overflow', 'auto')
        .css('width', width)
        .css('height', height)
        .css('top', offset.top + parentElement.height() + 8)
        .css('left', offset.left)
        .css('box-shadow', '7px 7px 5px rgba(50, 50, 50, 0.75)')
        .css('-webkit-box-shadow', '7px 7px 5px rgba(50, 50, 50, 0.75)')
        .css('-moz-box-shadow', '7px 7px 5px rgba(50, 50, 50, 0.75)')
        .css('z-index', 100);


    $(document).mouseup(function (e) {
        if (dropdownbox.has(e.target).length === 0) {
            dropdownbox.fadeOut();
        }
    });


    $(window).resize(function () {
        dropdownbox
            .css('position', 'absolute')
            .css('overflow', 'auto')
            .css('width', width)
            .css('height', height)
            .css('top', offset.top + parentElement.height() + 8)
            .css('left', offset.left);
    });
    dropdownbox.hide();


    parentElement.click(function () {
        var offset1 = parentElement.offset();
        dropdownbox
            .css('top', offset1.top + parentElement.height() + 8)
            .css('left', offset1.left)
            .css('z-index', 100);


        dropdownbox.slideDown();
    });

}



function models_ajax(url, success, data, progress) {
    var t = new Date();
    $.ajax({
        type: "POST",
        url: url,
        data: data,
        dataType: "json",
        timeout: 3600000,
        success: success,
        error: function (err) {
            models_notify("Error", "Error upon executing action, please see console for error details", 6000)
            console.log(err.responseText);
            if (err.status === 401) {
                alert("You have been logged off due to inactivity");
                var curhref = window.location.href;
                var arr = curhref.split("/");
                if (arr[2].toLowerCase().indexOf('localhost') != -1)
                    window.location.replace(arr[0] + "//" + arr[2] + "/webapps/");
                else
                    window.location.replace(arr[0] + "//" + arr[2]);
            }
        },
        progress: progress
    }).done(function () {
        var curhref = window.location.href;
        if (curhref.indexOf('/localhost/') != -1) return false;
        if (ajaxqueues.length != 0) return false;
        var f = new Date();
        var tots = (f.getTime() - t.getTime()) / 1000;

        if (tots < 5) return false;
        var j = '$' + t.getTime() + '$' + f.getTime() + '$' + url + '$' + curhref;
        var arr = curhref.split("/");
        var curuser = $('a:contains("Welcome")').find('b').text();
        var dd = $('div:contains("Welcome")').find('b')[4];
        var loginuser = typeof (dd) == 'undefined' ? '' : dd.textContent;

        if (curuser)
            j += '$' + curuser;
        else
            j += '$' + loginuser;

        var xd = JSON.stringify(data);
        xd = xd ? xd : '';
        xd = xd.length <= 999 ? xd : '';

        if (arr[2].toLowerCase().indexOf('webapps') != -1)
            uri = arr[0] + "//" + arr[2] + "/iscweb/home/ajaXperfmonpro";
        else
            uri = arr[0] + "//" + arr[2] + "/webapps/home/ajaXperfmonpro";

        ajaxqueues.push(url);

        $.ajax({ method: "POST", url: uri, data: { name: j, xdata: xd } }).done(function () { ajaxqueues = []; });

    });

}


function models_rowcheckbox() {
    $(".table").each(function (index, tbl) {
        $(this).find('.rowchkbox').each(function (index, chk) {
            $(this).unbind('onchange');
            $(this).change(function (e) {
                if ($(this).is(":checked")) {
                    $(this).closest('tr').addClass("selecteditem");

                }
                else {
                    $(this).closest('tr').removeClass("selecteditem");
                }
            });

        });


    });

}

function models_getfileext(filename) {

    return filename.split('.').pop();
}

function models_scrollTo(em) {
    $($(em).parent(".scrollable")[0]).animate({
        scrollTop: $(em).offset().top - 30
    }, 500);
}

function models_tree() {
    $(".css-tree").each(function (index, elm) {
        $(elm).find("a").removeClass('active');

        $(elm).find("a").bind('click', function (el) {
            $(elm).find("a").removeClass("active");
            $(this).addClass('active');

        });

        $(elm).find('i').each(function (index, icon) {
            if ($(icon).siblings('ul').length > 0) {
                $(icon).css('visibility', 'shown');
            } else {
                $(icon).css('visibility', 'hidden');
            }

        });

    });
}

function models_netTimespantoTime(timespan) {
    if (timespan) {
        var hours = 0;
        var mins = 0;
        var meredian = 'AM';

        if (timespan.Hours > 12) {
            hours = timespan.Hours - 12;
            meredian = 'PM';
        } else if (timespan.Hours == 12) {
            hours = timespan.Hours;
            meredian = 'PM';
        } else
            hours = timespan.Hours;


        mins = timespan.Minutes;

        return hours + ":" + mins.pad(2) + " " + meredian;
    } else {
        return '';
    }

}

function models_TimetoNetTimespan(time) {
    try {
        if (time == "")
            return "";

        var timeparts = time.split(' ');
        var Hours = parseInt(timeparts[0].split(':')[0]);
        var Minutes = parseInt(timeparts[0].split(':')[1]);

        if (timeparts[1] == "PM" && Hours < 12)
            Hours += 12;


        if (Hours == "NaN" || Minutes == "NaN") {
            return "";
        } else
            return Hours + ":" + Minutes.pad(2) + ":0.00";


    } catch (ex) {


    }

}

function models_slidedivs() {
    var currentpage = 1;
    var currentdiv = "";
    var slidedive = $(".slidediv")
    $(slidedive).each(function (index, el) {

        $(el).height($(el).parent().height() - 15);

        var totalwidth = 0;
        var slidepanes = $(el).find(".slidepane");
        $(slidepanes).each(function (index, el2) {
            totalwidth += $(el).parent().width();
            $(el2).css('width', $(el).parent().width() + 'px');
            $(el2).css('height', ($(el).parent().height()) + 'px');
            $(window).resize(function () {
                $(el2).css('width', $(el).parent().width() + 'px');
                $(el2).css('height', $(el).parent().height() + 'px');
                $(el).parent().css('overflow', 'hidden');
                $(el).parent().scrollLeft($($(el).find(".slidepane")[0]).width() * (currentpage - 1));
            });
        });
        $(el).width(totalwidth + 500);
        models_maximizedown_refresh();
        $(el).parent().css('overflow', 'hidden');

        $(window).resize(function () {
            $(el).height($(el).parent().height());
            models_maximizedown_refresh();

            $(el).parent().css('overflow', 'hidden');

            $(el).parent().scrollLeft($($(el).find(".slidepane")[0]).width() * (currentpage - 1));
        });


        $(el).parent().on('scroll', function () {
            $(el).parent().scrollLeft($($(el).find(".slidepane")[0]).width() * (currentpage - 1));
        });

    });



    return {
        move: function (divID, page) {
            currentdiv = divID;
            currentpage = page;
            $(currentdiv).parent().off('scroll');

            $(currentdiv).parent().animate({
                scrollLeft: $($(currentdiv).find(".slidepane")[0]).width() * (page - 1)
            }, 200, "swing",
                function () {
                    $(currentdiv).parent().on('scroll', function () {
                        $(currentdiv).parent().scrollLeft($($(currentdiv).find(".slidepane")[0]).width() * (currentpage - 1));
                    });
                }
            );


        },
        setpage: function (divID, page) {
            currentdiv = divID;
            currentpage = page;
            $(divID).parent().off('scroll');
            $(divID).parent().scrollLeft($($(divID).find(".slidepane")[0]).width() * (page - 1));
            this.activatescroll();

        },
        activatescroll: function () {
            $(currentdiv).parent().on('scroll', function () {
                $(currentdiv).parent().scrollLeft($($(currentdiv).find(".slidepane")[0]).width() * (currentpage - 1));
            });
        }

    }
}

function dynamicSort(property) {
    var sortOrder = 1;
    if (property[0] === "-") {
        sortOrder = -1;
        property = property.substr(1);
    }
    return function (a, b) {
        var result = (a[property] < b[property]) ? -1 : (a[property] > b[property]) ? 1 : 0;
        return result * sortOrder;
    }
}

var models_reportRange = {
    ptype: ko.observable(0),
    dtfrom: ko.observable(moment().format("YYYY-MM-DD")),
    dtto: ko.observable(moment().format("YYYY-MM-DD")),
    pre: '',
    load: function (pre, defaultptype) {
        var currentdate = new Date();
        if (pre) this.pre = pre;
        if (defaultptype) this.ptype(defaultptype);

        for (i = currentdate.getFullYear() - 3; i <= currentdate.getFullYear(); i++) {
            $("#txt_year").append("<option>" + i + "</option>");
            $("#txt_year2").append("<option>" + i + "</option>");
            $("#txt_year3").append("<option>" + i + "</option>");
        }
        $("#" + this.pre + "txt_year").val(currentdate.getFullYear());
        $("#" + this.pre + "txt_year2").val(currentdate.getFullYear());
        $("#" + this.pre + "txt_year3").val(currentdate.getFullYear());
        this.getWeeks();
        $("#" + this.pre + "txt_weekno").val(moment().week());

        $("#" + this.pre + "txt_monthno").val(moment().month() + 1);

        var _ = this;
        this.ptype.subscribe(function () {
            _.update();
        });
    },
    getWeeks: function () {
        var year = parseInt($("#" + this.pre + "txt_year").val());
        var firstDayOfYear = new Date(year, 0, 1);
        var days = firstDayOfYear.getDay() + (((year % 4 === 0) && (year % 100 !== 0) || (year % 400 === 0)) ? 366 : 365);

        var weeks = Math.ceil(days / 7);
        $("#" + this.pre + "txt_weekno").html('');
        for (i = 1; i <= weeks; i++) {
            $("#txt_weekno").append("<option>" + i + "</option>");
        }
    },
    update: function () {
        switch (this.ptype()) {
            case "0":
                this.dtto(this.dtfrom());
                break;
            case "1":
                var workingDate = moment(new Date(parseInt($("#" + this.pre + "txt_year").val()), 0, 1));
                workingDate.day(-1);
                workingDate.add('weeks', parseInt($("" + this.pre + "#txt_weekno").val()) - 1);
                this.dtfrom(workingDate.format("YYYY-MM-DD"));
                this.dtto(workingDate.add('days', 6).format("YYYY-MM-DD"));
                break;
            case "2":
                var workingDate = moment(new Date(parseInt($("#" + this.pre + "txt_year").val()), parseInt($("#" + this.pre + "txt_monthno").val()) - 1, 1));
                this.dtfrom(workingDate.format("YYYY-MM-DD"));
                this.dtto(workingDate.add('months', 1).add('seconds', -1).format("YYYY-MM-DD"));
                break;
            case "3":
                var workingDate = moment(new Date(parseInt($("#" + this.pre + "txt_year3").val()), 0, 1));
                this.dtfrom(workingDate.format("YYYY-MM-DD"));
                this.dtto(workingDate.add('years', 1).add('seconds', -1).format("YYYY-MM-DD"));
                break;
        }


    }
};

function models_datetoQuarter(dt) {
    return 'Q' + parseInt((moment(dt).month() / 3) + 1) + ' ' + moment(dt).year();
}
function models_resizeWell(txinputid, dvlistid, plusWidth) {
    var ctw = ($(txinputid).width() + plusWidth);
    $(dvlistid).width(ctw);
}
function models_getmonthabbrv() {
    var m = [
        { id: 1, name: 'January', code: 'Jan' },
        { id: 2, name: 'February', code: 'Feb' },
        { id: 3, name: 'March', code: 'Mar' },
        { id: 4, name: 'April', code: 'Apr' },
        { id: 5, name: 'May', code: 'May' },
        { id: 6, name: 'June', code: 'Jun' },
        { id: 7, name: 'July', code: 'Jul' },
        { id: 8, name: 'August', code: 'Aug' },
        { id: 9, name: 'September', code: 'Sep' },
        { id: 10, name: 'October', code: 'Oct' },
        { id: 11, name: 'November', code: 'Nov' },
        { id: 12, name: 'December', code: 'Dec' }
    ];
    return m;
};

function models_getyears(thisyear, toyear, prevyear) {
    var m = [];
    var nwyr = thisyear;
    if (prevyear)
        nwyr = nwyr - prevyear;
    else
        nwyr = nwyr - 1;

    m.push(nwyr);

    var y1 = thisyear;
    var y2 = toyear;

    for (i = nwyr; i < (y1 + y2); i++) {
        nwyr += 1;
        m.push(nwyr);
    };
    return m;
}



function isvaluevalid(eval) {
    var v = eval.toString().replace(new RegExp(',', 'g'), '').trim();
    var b = true;
    if (isNaN(v))
        b = false;

    return b;
};

function models_calchours(t) {
    var d = models_clone(t);
    var h = [];
    var m = [];
    $.each(d, function (index, value) {
        var v = value.toString().replace(new RegExp(',', 'g'), '').trim();
        if (v.indexOf(':') != -1) {
            v = v.replace(':', '.');
        }
        if (!isNaN(v) && isvaluevalid(v)) {
            h.push(v.split('.')[0]);

            if (v.split('.').length == 2)
                m.push(v.split('.')[1]);
        }
    });
    var hh = h.filter(function (e) { return e; }).sum(function (e) { return parseFloat(e); });
    var tmm = m.filter(function (e) { return e; }).sum(function (e) { return parseFloat(e); });
    var hmm = Math.floor(tmm / 60);
    var hhtmm = (hh + hmm);
    var mm = tmm - (hmm * 60);

    if (hhtmm.toString().length == 1)
        hhtmm = hhtmm.pad(2);
    if (mm.toString().length == 1)
        mm = mm.pad(2);

    return (hhtmm + ':' + mm);
};

if (!Array.prototype.filter) {
    Array.prototype.filter = function (fun /*, thisp */) {
        "use strict";

        if (this === void 0 || this === null)
            throw new TypeError();

        var t = Object(this);
        var len = t.length >>> 0;
        if (typeof fun !== "function")
            throw new TypeError();

        var res = [];
        var thisp = arguments[1];
        for (var i = 0; i < len; i++) {
            if (i in t) {
                var val = t[i]; // in case fun mutates this
                if (fun.call(thisp, val, i, t))
                    res.push(val);
            }
        }

        return res;
    };
}

Array.prototype.sum = function (prop) {
    var sum = 0;

    $.each(this, function (index, value) {
        if (typeof (prop) == 'function')
            sum += prop(this);
        else
            sum += parseInt($(value).attr(prop));

    });

    return sum;
}

if (!String.prototype.trim) {
    String.prototype.trim = function () {
        return this.replace(/^\s+|\s+$/g, '');
    }
}





/*!
 * jQuery Browser Plugin v0.0.3
 * https://github.com/gabceb/jquery-browser-plugin
 *
 * Original jquery-browser code Copyright 2005, 2013 jQuery Foundation, Inc. and other contributors
 * http://jquery.org/license
 *
 * Modifications Copyright 2013 Gabriel Cebrian
 * https://github.com/gabceb
 *
 * Released under the MIT license
 *
 * Date: 2013-07-29T17:23:27-07:00
 */

(function (jQuery, window, undefined) {
    "use strict";

    var matched, browser;

    jQuery.uaMatch = function (ua) {
        ua = ua.toLowerCase();

        var match = /(opr)[\/]([\w.]+)/.exec(ua) ||
            /(chrome)[ \/]([\w.]+)/.exec(ua) ||
            /(webkit)[ \/]([\w.]+)/.exec(ua) ||
            /(opera)(?:.*version|)[ \/]([\w.]+)/.exec(ua) ||
            /(msie) ([\w.]+)/.exec(ua) ||
            ua.indexOf("trident") >= 0 && /(rv)(?::| )([\w.]+)/.exec(ua) ||
            ua.indexOf("compatible") < 0 && /(mozilla)(?:.*? rv:([\w.]+)|)/.exec(ua) ||
            [];

        var platform_match = /(ipad)/.exec(ua) ||
            /(iphone)/.exec(ua) ||
            /(android)/.exec(ua) ||
            /(win)/.exec(ua) ||
            /(mac)/.exec(ua) ||
            /(linux)/.exec(ua) ||
            [];

        return {
            browser: match[1] || "",
            version: match[2] || "0",
            platform: platform_match[0] || ""
        };
    };

    matched = jQuery.uaMatch(window.navigator.userAgent);
    browser = {};

    if (matched.browser) {
        browser[matched.browser] = true;
        browser.version = matched.version;
    }

    if (matched.platform) {
        browser[matched.platform] = true
    }

    // Chrome and Opera 15+ are Webkit, but Webkit is also Safari.
    if (browser.chrome || browser.opr) {
        browser.webkit = true;
    } else if (browser.webkit) {
        browser.safari = true;
    }

    // IE11 has a new token so we will assign it msie to avoid breaking changes
    if (browser.rv) {
        browser.msie = true;
    }

    // Opera 15+ are identified as opr
    if (browser.opr) {
        browser.opera = true;
    }

    jQuery.browser = browser;

})(jQuery, window);