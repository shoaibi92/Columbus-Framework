﻿/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

"use strict"

var widgetUI = widgetUI || {};

//screen Id hold value for each menu screen menu Id
var screenId = 0;

//For homepage help screen
var defaultScreenId = 0;

//For Report Screen Help
var reportScreenHelp = 1;

//Report Screen default Id
var reportScreenId = " ";

var isWidgetVisible = false;

var widgetDomain;
var tenantName;
var domain;

// Use to do string format, kind of like String.format in C#
String.prototype.format = function () {
    var str = this;
    for (var i = 0; i < arguments.length; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        str = str.replace(reg, arguments[i]);
    }
    return str;
}

function clearIframes() {
    $('#screenLayout').children().each(function () {
        $(this).hide();
    });
};

function helpSearchForMenuItem(screenId) {
    var data = { screenId: screenId };

    sg.utls.ajaxCachePostHtml(sg.utls.url.buildUrl("Core", "Help", "Index"), data, function (result) {
        $('#searchHelpDiv').html(result);
    }, sg.utls.url.buildUrl("Core", "Help", "Index") + "_" + screenId + "_" + globalResource.Culture);
};

$(document).ready(function () {

    widgetDomain = sg.utls.url.baseUrl();
    var numberOfActiveWindows = $('#hdnNumberOfActiveWindows').val();
    var isIframeClose = false;
    var currentRank;
    var flag;
    var currentDiv;
    var currentIframeId;
    var controls = [];
    var firstControl = {};
    var isReload = true;
    var currentIframe;
    var iFrameUrl;
    var isKPI = false;
    var kpiReportName;

    //to stop spinner
    $('#screenLayout').children().load(function () {
        $(this).removeClass('screenLoading');
    });

    screenId = defaultScreenId;
    $('#searchHelpDiv').show();

    $('#xmlMenuDiv').show();

    var isWidgetEmptyLnkClicked = false;

    var menu = $("#topMenu").kendoMenu({ open: onOpen, close: onClose }).data("kendoMenu");
    function onOpen(e) { if ($(e.item).children(".k-link").text() == '') $(".main-search input").css("opacity", "0.3").attr("disabled", "disabled"); }
    function onClose(e) { if ($(e.item).children(".k-link").text() == '') $(".main-search input").css("opacity", "1").removeAttr("disabled"); }

    /*
    $('#lnkLogo').click(function () {
        $('#dvWindows > div').each(function () {
            $(this).find("span").removeClass('selected');
        });
        ShowHomePage();
    });
    */

    $(document).click(function (e) {
        if (!isWidgetEmptyLnkClicked) {
            $('.container_popUp.Widget.widgetList').hide();
        }
        isWidgetEmptyLnkClicked = false;
    });
    
    $('#spnCloseWidget').click(function () {
        $('#DivWidgetWindow').hide();
    });

    $("#home_nav").kendoMenu({

    });

    $(".home_nav").click(function () {
        ShowHomePage();
    });

    $("ul#home_nav li.main").children().addClass("mainNav");

    $('#lnkAddWidgets, .GoArrow,  #lblSeeIntoYourData').click(function () {
        isWidgetEmptyLnkClicked = true;
        $('#addRemoveWidget').show();
    });

    $(".top-buttons.addWidgets").click(function () {
        $('#addRemoveWidget').show();
    });

    $(".portalIcon.closeIcon").click(function () {
        $("this").closest(".container_popUp.Widget.widgetList").hide("fast");
    });

    $("ul#home_nav").children().children().children().addClass("k-iconNone");

    $(".portalIcon.checkBox span.checkBox").addClass("portalIcon");

    $(".portalIcon.checkBox span.checkBox").removeClass("icon");
  
    initializeMainMenu();

    firstControl["control"] = "widgetLayout";
    firstControl["rank"] = 1;
    controls.push(firstControl);
    $("#draggable").draggable({ axis: "y", containment: "window" });
    clearIframes();
    $('#dvCloseWindowErrorMessage').hide();
    $('.task_added').hide();
    $('#topMenu').mouseenter(function () {
        if (!$("#helpSearchfl").is(':focus')) {
            helpSearchForMenuItem(screenId);
        }
    });
    $(".span_task").hover(function () {
        if ($('#dvWindows').children().length > 0)
            $(".span_task > div").show();

        //reset selection
        $("#dvWindows span").removeClass('selected');

        // Find Active Window and AddClass Selected
        $("#dvWindows span").each(function (index, elem) {
            var $iframe = $('#' + $(elem).attr('frameid'));
            if ($iframe.is(':visible')) {

                $(elem).addClass('selected');
                //Getting screenId from Taskdoc which having class as selected
                screenId = $('#dvWindows div span.selected').attr("data-menuid");

                //Checking whether Taskdoc Item having a generated report from screen or not
                if (screenId === reportScreenId) {
                    screenId = reportScreenHelp;
                }

                return false;
            }
        });

        }, function () {
            $(".span_task > div").hide();
        });

    $('.top_nav_drop_content').click(function () {

        isReload = false;
    });

    $(window).bind('beforeunload', function () {
        var numOfOpenScreens = $('#dvWindows').children().length;
        if (isReload && numOfOpenScreens > 0) {
            return sg.utls.htmlDecode(portalBehaviourResources.PageRefreshError);
        }
    });

    function ShowHomePage()
    {
        $('#screenLayout').hide();
        $('#widgetLayout').show();

        //When footer logo is clicked
        screenId = defaultScreenId;

        $('#breadcrumb').hide();

        if (!$('#screenLayout').is(":visible")) {
            updateLayout();
        }
    }

    function AreWidgetVisible() {
        $(".bodyWidgetContainer > div").each(function () {
            if ($(this).find("iframe").attr('src') != '') {
                isWidgetVisible = true;
            }
        });
    }

    function ShowCorrectLayout() {
        if (isWidgetVisible && controls.length == 1) {
            $('#widgetLayout').show();
            $('#widgetHplayout').hide();
            $('#dvAddWidget').show();
            $('#breadcrumb').hide();

        } else if (controls.length == 1) {
            $('#widgetHplayout').show();
            $('#widgetLayout').hide();
            $('#dvAddWidget').hide();
        }
    }

    function initializeMainMenu()
    {
        var $menu = $(".nav-menu .std-menu");

        $menu.menuAim({
            activate: activateSubmenu,
            deactivate: deactivateSubmenu,
            exitMenu: exitSubmenu
        });

        function activateSubmenu(row) {
            var $row = $(row),
                $submenu = $row.find(".sub-menu-wrap");//,

            // Show the submenu
            $submenu.css({
                display: "block"
            });

            $row.find("span:first").addClass("active");
        }

        function deactivateSubmenu(row) {
            var $row = $(row),
                $submenu = $row.find(".sub-menu-wrap");

            // Hide the submenu and remove the row's highlighted look
            $submenu.css("display", "none");
            $row.find("span:first").removeClass("active");
        }

        function exitSubmenu(row) {
            var $row = $(row);
            $row.find(".sub-menu-wrap").hide().eq(0).show();
        }

        $(".nav-menu .std-menu li").click(function (e) {
            e.stopPropagation();
        });

        $menu.find(".menu-section li:not('.sub-heading')").click(function () {
            $(".std-menu").addClass("deactive").find("> li:not(:first-child) .sub-menu-wrap").css("display", "none");
            $(".nav-menu span.active").removeClass("active");
        });

        $(".nav-menu .top-tier").hover(
            function () {
                $(this).find(".active").removeClass("active");
                $(this).find("li:first span:first").addClass("active");
                $(this).find(".deactive").removeClass("deactive");
            },
            function () {
                $(this).find("li:first span:first").removeClass("active");
            }
          );
    }

    $('#homeNav').click(function () {
        $('#dvWindows > div').each(function () {
            $(this).find("span").removeClass('selected');
        });
    });

    //onload event handling on iframes
    $('#screenLayout').children().each(function () {
        $(this).load(function (e) {
            if (isIframeClose && $(this).attr('id') === currentIframeId) {
                //close the screen
                if (!($('#widgetLayout').is(":visible"))) {
                    $('#' + currentIframeId).hide();
                }
                if (!flag) {

                    //close the maximum number of windows message box
                    $('#dvWindowsExceedLimitErrorMessage').hide();

                    //remove task from the window
                    $("#" + $("#" + currentDiv + "").attr('id') + "").remove();

                    if ($('#dvWindows').children().length > 0) {

                        //keep the task window open
                        $(".span_task > div").show();
                        //display number of open tasks
                        $('#spWindowCount').text("(" + ($('#dvWindows').children().length) + ")");
                    }
                    else {
                        //close the task window
                        $(".span_task > div").hide();
                        $('.span_task').removeClass("zeroTaskCount");
                        //hide the breadcrumb
                        $('#breadcrumb').hide();

                        $('#spWindowCount').text("");
                        screenId = defaultScreenId;

                        $('#spnSessionDate').removeClass('disabled');
                        $('#sessionDatelabel').removeClass('disabled');
                        $('#sessionDateIcon').removeClass('disabled');
                        $('#sessionDateIcon').removeClass('glyphicon-lock');
                        $('#sessionDateIcon').addClass('glyphicon-calendar');
                    }

                    // Breadcrumb - Load breadcrumb on window management item removal  
                    var lastID = $("#dvWindows span[controltoremove]").last().attr("frameId");

                    if (currentIframeId === lastID) {
                        var secondLastParentID = $("#dvWindows span[controltoremove]").eq(-2).data("parentid");
                        loadBreadCrumb(secondLastParentID);
                    }
                    else {
                        var getLastWindowParentID = $("#dvWindows span[controltoremove]").last().data("parentid");
                        loadBreadCrumb(getLastWindowParentID);
                    }

                    $.each(controls, function (index, element) {
                        flag = true;
                        if (!$('#widgetLayout').is(":visible"))
                            $('#' + element["control"]).hide();
                        if (parseInt(element["rank"], 10) === currentRank) {
                            element["rank"] = 0;
                        }
                        if (parseInt(element["rank"], 10) !== 0 && parseInt(element["rank"], 10) > currentRank) {
                            element["rank"]--;
                        }
                        $('#' + element["control"]).attr("rank", element["rank"]);

                        if (parseInt(element["rank"], 10) === 1) {
                            if (element["control"] != 'widgetLayout')
                                $('#' + element["control"]).show();
                        }
                    });

                    $.each(controls, function (index, element) {
                        if (element) {
                            if (parseInt(element["rank"], 10) === 0) {
                                controls.splice(index, 1);
                            }
                        }
                    });

                    //this is to keep active screen selection in the Open Windows popup
                    $('.span_task').mouseenter();
                    isWidgetVisible = false;
                    AreWidgetVisible();
                    ShowCorrectLayout();
                }
                e.preventDefault();
            }
        });
    });

    $("#dvWindows").on("click", "span", function () {
        currentIframeId = $(this).attr("frameId");

        //Adding Class Selected to the Active Window
        $('div#dvWindows span').not($(this)).removeClass('selected');
        $(this).addClass('selected');

        if ($(this).attr('command') === "Remove") {
            isIframeClose = true;
            currentDiv = ($(this).attr('controlToRemove'));
            flag = false;
            $.each(controls, function (index, element) {
                if (element["control"] === currentIframeId) {
                    currentRank = element["rank"];
                }
            });

            $("#" + currentIframeId + "").attr("src", "");
        }
        else if ($(this).attr('command') === "Add") {
            var currentSelectedRank = $(this).attr("rank");
            if ($('#widgetHplayout').is(":visible")) {
                $('#widgetHplayout').hide();
            }
            clearIframes();
            currentDiv = ($(this).attr('frameId'));
            $.each(controls, function (index, element) {
                if (currentDiv === element["control"]) {
                    element["rank"] = 1;
                }
                else if (element["rank"] < currentSelectedRank) {
                    element["rank"]++;
                    $('#' + element["control"]).attr("rank", element["rank"]);
                }
            });


            $('#screenLayout').show();
            $('#widgetLayout').hide();

            $("#" + currentDiv + "").show();
            currentIframe = currentDiv;

            $('#dvWindows').find('span').each(function () {
                if ($(this).attr('command') == 'Add') {
                    if (currentIframe == $(this).attr('frameid')) {
                        $(this).attr("rank", 1);
                    } else if (parseInt($(this).attr('rank'), 10) < currentSelectedRank) {
                        $(this).attr("rank", (parseInt($(this).attr("rank"), 10) + 1));
                    }
                }
            });

            // Breadcrumb - Load breadcrumb on window management item selection
            var parentidVal = $(this).data('parentid');
            loadBreadCrumb(parentidVal);

            // Menu Help - Load Menu Help on window management item selection
            screenId = $(this).attr("data-menuid");

            //Checking the Taskdoc having a generated Report Screen or not
            if (screenId === reportScreenId) {
                screenId = reportScreenHelp;
            }
        }
    });

    widgetUI = { NavigableMenuDetail: {} };

    function taskAdded() {
        $(".task_added").show().css({ "right": "-29px" }).animate({ "right": "77px" }, "1500");
        $(".task_added").delay(1800).css({ "right": "77px" }).animate({ "right": "-29px" }, "3000").fadeOut();
    }

    $(".kpi .btnOpenReport").on("click", function (event) {
        clearIframes();
        iFrameUrl = $(this).closest(".kpi").find("iframe").attr("src");
        if (iFrameUrl.indexOf("AgedPayable") > 0) {
            $('#screenLayout').show();
            $('#widgetLayout').hide();
            sg.utls.ajaxPost(sg.utls.url.buildUrl("KPI", "AgedPayablesReport", "Execute"), {}, loadOptions.executeAgedPayableReport);
        }
        else if (iFrameUrl.indexOf("AgedReceivable") > 0) {
            $('#screenLayout').show();
            $('#widgetLayout').hide();
            sg.utls.ajaxPost(sg.utls.url.buildUrl("KPI", "AgedReceivablesReport", "Execute"), {}, loadOptions.executeAgedReceivableReport);

        }

    });

    var loadOptions = {
        executeAgedPayableReport: function (result) {
            if (result != null && result.UserMessage.IsSuccess) {
                sg.utls.openReport(result.ReportToken);
                isKPI = true;
                kpiReportName = portalBehaviourResources.PayableAging;
            } else {
                sg.utls.showMessage(result);
                $(window).scrollTop(0);
            }
        },
        executeAgedReceivableReport: function (result) {
            if (result != null && result.UserMessage.IsSuccess) {
                sg.utls.openReport(result.ReportToken);
                isKPI = true;
                kpiReportName = portalBehaviourResources.ReceivableAging;
            } else {
                sg.utls.showMessage(result);
                $(window).scrollTop(0);
            }
        },
    };

    function assignUrl(windowText, parentid, menuid) {
        var control = {};
        var isIframeOpen = false;
        var isScreenOpen = false;
        if ($('#widgetHplayout').is(":visible")) {
            $('#widgetHplayout').hide();
        }
        $('#screenLayout').children().each(function () {
            //Compare the full URL including the query string.
            if ($(this).attr("src") === targetUrl) {
                $(this).show();
                isScreenOpen = true;

                //do not display more than one frame.
                return false;
            }
        });

        $('#screenLayout').children().each(function () {
            if (!$(this).is(':visible') && $(this).attr("src") === '' && !isIframeOpen && !isScreenOpen) {
                isIframeOpen = true;
                isIframeClose = false;

                $(this).addClass('screenLoading');
                $(this).contents().find('body').html('');
                $(this).attr("src", targetUrl);
                $(this).show();

                $.each(controls, function (index, element) {
                    element["rank"]++;
                    $('#' + element["control"]).attr("rank", element["rank"]);
                });
                control["control"] = $(this).attr('id');
                currentIframe = $(this).attr('id');
                control["rank"] = 1;
                controls.push(control);
                $('#dvWindows > div').each(function () { $(this).find("span").removeClass('selected'); });

                $('#dvWindows').find('span').each(function () {

                    if ($(this).attr('command') == 'Add') {
                        $(this).attr("rank", (parseInt($(this).attr("rank"), 10) + 1));
                    }
                });

                var $divWindow = $('<div id="dv' + $(this).attr('id') + '" class = "rcbox"> <span class = "selected" data-menuid="' + menuid + '" data-parentid="' + parentid + '" frameId="' + $(this).attr('id') + '" command="Add" rank="1">' + windowText + '</span><span data-parentid="' + parentid + '" frameId="' + $(this).attr('id') + '" command="Remove" controlToRemove="dv' + $(this).attr('id') + '"></span></div>');
                $('#dvWindows').append($divWindow);
                $('#spWindowCount').text("(" + ($('#dvWindows').children().length) + ")");
                taskAdded();

                $('#spnSessionDate').addClass('disabled');
                $('#sessionDatelabel').addClass('disabled');
                $('#sessionDateIcon').addClass('disabled');
                $('#sessionDateIcon').removeClass('glyphicon-calendar');
                $('#sessionDateIcon').addClass('glyphicon-lock');

                //called help according to screenId i.e menuid
                //Checking the Taskdoc having a generated Report Screen or not
                if (screenId !== reportScreenId) {
                    screenId = menuid;
                }
                else {
                    screenId = reportScreenHelp;
                }
            }
        });
    }

    $('#home_nav').kendoMenu();
    var targetUrl = "#";

    // TO DO : Move the below piece of code to Index page where you put your frame
    // Invoked from the main menu
    $(".menu-section a").on("click", function (event) {

        // try close the widget add/remove menu no matter what
        $(".container_popUp.Widget.widgetList").hide();

        //Sage Intelligence
        var intelligence = $(this).attr("data-isIntelligence");
        var fileurl = $(this).attr("data-url");

        if (intelligence == "True") {
            isReload = false;
            event.preventDefault();
            var url = sg.utls.url.buildUrl("Core", "Home", "Download");
            window.open(url + "?file=" + fileurl, "_self");
        }

        else {
            $('#screenLayout').show();
            $('#widgetLayout').hide();
            if ($(event.target).data('url') != " ")
                targetUrl = $(event.target).data('url');


            //Check if maximum number of screens reached
            var isScreenOpen = isScreenAlreadyOpen(targetUrl);
            if (!isScreenOpen && $('#dvWindows').children().length >= numberOfActiveWindows) {
                $('#dvWindowsExceedLimitErrorMessage').show();
                return;
            }

            if ($('#dvWindows').children().length <= numberOfActiveWindows) {
                clearIframes();
            }
            // Load breadcrumb on menu item click and add item to windows dock
            var parentidVal = $(this).data('parentid');

            //Get menu id as screenId for Help Menu Search
            screenId = $(this).attr("data-menuid");

            loadBreadCrumb(parentidVal);

            var windowtext = $(event.target).text();

            $('#dvWindows > div').each(function () { $(this).find("span").removeClass('selected'); });

            if ($(this).attr("data-modulename") !== "" && $.parseHTML($(this).attr("data-modulename")) != null && $(this).attr("data-moduleName") != "null") {
                windowtext = portalBehaviourResources.PagetitleInManager.format($(this).attr("data-modulename"), $(event.target).text());
            }

            if ($(this).attr("data-isreport") === "true" || $(this).attr("data-isreport") === "True") {
                //windowtext = windowtext.indexOf("Report") < 0 ? windowtext + " " + portalBehaviourResources.Report : windowtext;
                windowtext = portalBehaviourResources.ReportNameTemplate.format(windowtext, portalBehaviourResources.Report);
            }

            if (targetUrl != "")
                assignUrl(windowtext, parentidVal, screenId);
        }

        //close menu
        $(".nav-menu .top-tier").each(function() {
            $(this).find(".active").removeClass("active");
        });

    });

    $('.icon.msgCtrl-close').click(function () {
        $('#dvWindowsExceedLimitErrorMessage').hide();
    });

    $('#addWidgetBtnProcess').click(function () {
        $('#widgetMsgDiv').hide();
    });
    $('#btnProcess').click(function () {
        $('#msgDiv').hide();
    });

    function loadBreadCrumb(parentidVal) {
        if (!$('#widgetLayout').is(":visible")) {

            //Variables
            var html = [];
            //Add Parent to array
            jQuery.each(MenuList, function (i, val) {
                if (val.Data.MenuId == parentidVal) {
                    var menuName = val.Data.MenuName;
                    if (menuName.indexOf("'") > -1) {
                        menuName = menuName.replace("'", "&#39;");
                    }
                    html = html + "<ul class=bc><li>" + menuName + "<span class=navigation-pipe>:</span></li>";
                }
            });

            //Add Child items to array
            jQuery.each(MenuList, function (i, val) {
                if (val.Data.ParentMenuId == parentidVal && val.Data.IsGroupHeader == false) {
                    var windowsDockTitle = val.Data.MenuName;
                    //   var title = val.Data.MenuName.length <= 25 ? val.Data.MenuName : val.Data.MenuName.substring(0, 25) + "...";
                    var screenurl = (val.Data.ScreenUrl == "N/A") ? "" : portalBehaviourResources.DomainUrl + val.Data.ScreenUrl;
                    var moduleName = (val.Data.ModuleName == 'null') ? "" : val.Data.ModuleName;
                    var isReport = (val.Data.isReport == 'null') ? "" : val.Data.IsReport;
                    html = html + ('<li><a data-parentid="' + val.Data.ParentMenuId + '" data-menuid="' + val.Data.MenuId + '" class="breadcrumb-page" data-url="' + screenurl + '" data-windocktitle="' + windowsDockTitle + '" data-moduleName="' + moduleName + '" data-isreport ="' + isReport + '">' + val.Data.MenuName + '</a></li>');
                }
            });

            html = html + ('</ul>');
            $('#breadcrumb').show();
            $('#breadcrumb').html(html);
            $("#breadcrumb:contains('Sequence contains no elements')").hide();

            // Breadcrumb more dropdown menu
            var postsArr = new Array();
            $('ul.bc').find('li').each(function () { postsArr.push($(this).html()); });
            var len = postsArr.length;
            var bcContent;

            if (len > 7) {
                for (var i = 0; i < len; i++) {
                    if (i == 0) bcContent = '<ul class="bc"><li>' + postsArr[i] + '</li>';
                    else if (i == 6) bcContent = bcContent + '<li class="innerdd">' + portalBehaviourResources.MoreItems + '<i class="downArrow"></i><ul><li>' + postsArr[i] + '</li>';
                    else if (i == (len - 1)) bcContent = bcContent + '<li>' + postsArr[i] + '</li></ul></li></ul>';
                    else bcContent = bcContent + '<li>' + postsArr[i] + '</li>';
                }
                $("#breadcrumb").html(bcContent);
            }

            $(".innerdd").hover(function () {

                $(this).find("ul").show();
            },

            function () {
                $(this).find("ul").hide();
            });

            //Invoked from breadcrumb menu
            $('.breadcrumb-page').click(function () {
                var parentWidth = $(document).width();
                $('#screenLayout').children().each(function () {
                    $(this).width(parentWidth);
                });

                $('#screenLayout').show();
                $('#widgetLayout').hide();

                if ($.trim($(this).data('url')) != "") {
                    targetUrl = $(this).data('url');

                }

                //Check if maximum number of screens reached
                var isScreenOpen = isScreenAlreadyOpen(targetUrl);
                if (!isScreenOpen && $('#dvWindows').children().length >= numberOfActiveWindows) {
                    $('#dvWindowsExceedLimitErrorMessage').show();
                    return;
                }

                if ($('#dvWindows').children().length <= numberOfActiveWindows) {
                    clearIframes();
                }

                var title = $(this).attr("data-windocktitle");

                if ($(this).attr("data-moduleName") != "" && $(this).attr("data-moduleName") != "null") {
                    //title = $(this).attr("data-moduleName") + " " + $(this).attr("data-windocktitle");
                    title = portalBehaviourResources.PagetitleInManager.format($(this).attr("data-moduleName"), title);
                }

                var parentidVal = $(this).attr("data-parentid");

                //Get menu id as screenId for Help Menu Search
                screenId = $(this).attr("data-menuid");

                $('#dvWindows > div').each(function () { $(this).find("span").removeClass('selected'); });

                if ($(this).attr("data-isreport") === "true" || $(this).attr("data-isreport") === "True") {
                    //title = title.indexOf("Report") < 0 ? title + " " + portalBehaviourResources.Report : title;
                    title = portalBehaviourResources.ReportNameTemplate.format(title, portalBehaviourResources.Report);
                }

                if (targetUrl != "") {
                    assignUrl(title, parentidVal, screenId);
                }
            });
        }
    };

    function isScreenAlreadyOpen(url)
    {
        var result = false;
        //Check if the screen is already open
        $('#screenLayout').children().each(function () {
            if ($(this).attr("src") === url) {
                result = true;
            }
        });

        return result;
    }

    // Function to handle opening of Reports and Screen as a New Task Window.
    function openNewTask(evt) {
        if (evt) {
            if (typeof evt.data === "string") {
                // Display Reports as a New Task Doc Item
                if (evt.data.indexOf("isReport") >= 0) {

                    var postMessageData = evt.data.split(" ");
                    targetUrl = postMessageData[1];
                    var reportName = postMessageData.splice(0, 2);
                    var screenName, parentId, menuid;

                    var urlParser = $('<a>', { href: postMessageData[postMessageData.length - 1] })[0];
                    var a = $("#xmlMenuDiv li > a[data-url='" + urlParser.pathname + "']");
                    var isReport = a.data("isreport");

                    //Check if maximum number of screens reached
                    var isScreenOpen = isScreenAlreadyOpen(targetUrl);
                    if (!isScreenOpen && $('#dvWindows').children().length >= numberOfActiveWindows) {
                        $('#dvWindowsExceedLimitErrorMessage').show();
                        return;
                    }

                    if ($('#dvWindows').children().length <= numberOfActiveWindows) {
                        clearIframes();
                    }

                    //do not show the breadcrumb for printed reports
                    $('#breadcrumb').hide();
                    // Checking isKPI so that reportName is appended to show in windows doc when opened from KPI.
                    if (isKPI == true) {
                        var windowText = kpiReportName;
                        isKPI = false;
                    } else {
                        postMessageData.splice(postMessageData.length - 1, 1);
                        var windowText = postMessageData.join(" ");
                    }

                    if ((isReport === 'True' || isReport === 'true') && windowText.indexOf(portalBehaviourResources.Report) === -1) // only add Report to the window name if it is a report page and it does not have one
                    {
                        windowText = portalBehaviourResources.ReportNameTemplate.format(windowText, portalBehaviourResources.Report);
                    }
                    windowText = windowText + " - " + portalBehaviourResources.Printed;
                    
                    menuid = reportScreenHelp;

                    menuid = reportScreenHelp;

                    //Method To Load Into Task Doc
                    assignUrl(windowText, parentId, menuid);

                    //Update Help Menu after Report Generated from a Screen
                    screenId = reportScreenHelp;
                }
                    // Display Screen as a New Task Doc Item
                else if (evt.data.indexOf("isScreen") >= 0) {
                    var postMessageData = evt.data.split(" ");
                    targetUrl = postMessageData[1];

                    //Check if maximum number of screens reached
                    var isScreenOpen = isScreenAlreadyOpen(targetUrl);
                    if (!isScreenOpen && $('#dvWindows').children().length >= numberOfActiveWindows) {
                        $('#dvWindowsExceedLimitErrorMessage').show();
                        return;
                    }

                    if ($('#dvWindows').children().length <= numberOfActiveWindows) {
                        clearIframes();
                    }

                    /*
                     Sample targetUrl
                     "/Sage300/OnPremise/AP/InvoiceEntry/Index?batchNumber=25&toAction=/Sage300/OnPremise/AP/InvoiceBatchList&actionType=EditBatch"
                    */

                    var screenName;
                    var parentScreenID;
                    var screenID;
                    var menuUrl = targetUrl.split("?")[0];

                    // Get ScreenId, ParentScreenId and Menu Name for Requested Url
                    jQuery.each(MenuList, function (i, val) {
                        if (menuUrl.indexOf(val.Data.ScreenUrl) >= 0) {
                            screenID = val.Data.MenuId;
                            parentScreenID = val.Data.ParentMenuId;
                            screenName = val.Data.ModuleName == null ?
                                val.Data.MenuName :
                                portalBehaviourResources.PagetitleInManager.format(val.Data.ModuleName, val.Data.MenuName);
                        }
                    });

                    loadBreadCrumb(parentScreenID);

                    //Method To Load Into Task Doc
                    assignUrl(screenName, parentScreenID, screenID);
                }
            }

        }
    }

    //Event Listener to handle post message events
    if (window.addEventListener) {
        // For standards-compliant web browsers
        window.addEventListener("message", openNewTask, false);
    } else {
        window.attachEvent("onmessage", openNewTask);
    }

    $(window).resize(function () {
        resizeLayout();
    });

    function resizeLayout()
    {
        //widgets layout container, widgets help layout container
        $('.body_container,#widgetHplayout').each(function () {
            var iframeHeight = $(window).height() - 184;
            $(this, '#widgetHplayout').css('min-height', iframeHeight);
        });

        //first time user layout, screen layout
        $('#firstTimeLogin').each(function () {
            var docHeight = $(document).height();
            $('#firstTimeLogin .overlay').css('min-height', docHeight);
        });
    }

    resizeLayout();

    $("#liSignOut").html('<a id="lnkSignOut" href="javascript:void(0);" class="k-link">' + portalBehaviourResources.SignOut + '</a>');
    $("#liManageUsers").html('<a id="lnkUserManagment" href="javascript:void(0)" class="k-link">' + portalBehaviourResources.ManageUsers + '</a>');

    $("#lnkSignOut").bind('click', function () {
        sg.utls.logOut();
    });

    $("#liManageUsers").bind('click', function () {
        window.open(umURL);
    });
});


