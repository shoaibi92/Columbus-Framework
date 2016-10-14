/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

"use strict";

var quantity = quantity || {};

var quantityColumnName = {
    Detail:"",
    ExpectedShipArrivalDate: "",
    Location: "",
    Quantity: "",
    DocumentNumber: "",
    Date: "",
    CustVendorNumber: "",
    CustVendorName: "",
};

var gridQuantityColConfig = {

    noEditor: function (container, options) {
        sg.utls.kndoUI.nonEditable($('#' + quantityUIGrid.gridId).data("kendoGrid"), container);
    },

    getColumn: function (fieldName, isHidden, caption, columnClass, templateExp, headerTemplateExp, editor) {
        var column = {
            field: fieldName,
            hidden: isHidden,
            title: caption,
            attributes: isHidden ? { sg_Customizable: false } : { "class": columnClass },
            headerAttributes: { "class": columnClass },
            template: templateExp,
            headerTemplate: headerTemplateExp,
            editor: editor,
        }
        return column;
    },
};

//Item Quantity Grid 
var quantityUIGrid =
{
    init: function (params) {

        quantityUIGrid.gridId = params.gridId,
        quantityUIGrid.modelData = params.modelData,
        quantityUIGrid.currentRowItemNumber = params.currentRowItemNumber(),
        quantityUIGrid.currentLocation = params.allLocation ? null : params.currentLocation(),
        quantityUIGrid.currentDocumentType = params.currentDocumentType,
        quantityUIGrid.btnEditColumnsId = params.btnEditColumnsId,
        quantityUIGrid.btnPOReceipt = params.btnPOReceipt,
        quantityUIGrid.preferencesTypeId = params.preferencesTypeId,
        quantityUIGrid.pageSize = params.pageSize,
        quantityUIGrid.pageNumber = params.pageNumber,
        quantityUIGrid.formattedDecimal = params.formattedDecimal,
        quantityUIGrid.ScreenName = params.ScreenName,
        quantityUIGrid.initButton();

    },
    initButton: function () {

        var grid = $('#' + quantityUIGrid.gridId).data("kendoGrid");
        quantityUIGrid.defaultColumns = $.extend(true, {}, grid.columns);
        quantityUIGrid.defaultColumns.length = grid.columns.length;

        $('#' + quantityUIGrid.btnEditColumnsId).on('click', function () {
            GridPreferences.initialize('#' + quantityUIGrid.gridId, quantityUIGrid.preferencesTypeId, $(this), quantityUIGrid.defaultColumns);
        });

        $('#' + quantityUIGrid.btnPOReceipt).on('click', function () {
            var gridData = sg.utls.kndoUI.getSelectedRowData(grid);

            var guid = sg.utls.guid();
            var url = sg.utls.url.buildUrl("PO", "PendingReceiptsInquiry", "Index") + "?guid=" + guid + "&itemNumber=" + quantityUIGrid.currentRowItemNumber + "&location=" + gridData.DocumentLocation;
            sg.utls.iFrameHelper.openWindow(guid, "", url, 600);            
        });
    },

    getFormattedValue: function (fieldValue) {
        if (fieldValue != null)
            fieldValue = sg.utls.kndoUI.getFormattedDecimalNumber(!isNaN(parseFloat(fieldValue)) ? parseFloat(fieldValue) : 0, quantityUIGrid.formattedDecimal);
        else {
            fieldValue = sg.utls.kndoUI.getFormattedDecimalNumber(0, quantityUIGrid.formattedDecimal);
        }
        return fieldValue;
    },    

    getFormattedDate: function (fieldValue) {
        if (fieldValue != null) {
            return sg.utls.kndoUI.getFormattedDate(fieldValue);
        }
        return fieldValue;
    },
    getSettings: function (container) {
        var div = $(quantityPanelField.drillDown);
        var button = div.find('input[type=button]')[0];
        button.id = button.id + container;
        $(button).attr('tag', container);
        $(button)[0].classList.add("btnDetail");
        return div.html();
    },
    registerSettingsEvent: function (e) {

        $('.btnDrillDown').unbind('click').click(function (e) {
            var rowIndex = parseInt($(this).attr('tag'));
            var itemGrid = $("#" + quantityUIGrid.gridId).data("kendoGrid");
            var selectedData = sg.utls.kndoUI.getRowByKey(itemGrid.dataSource.data(), "DetailLineUniquifier", rowIndex);

            var guid = sg.utls.guid();

            var url = "#"
            if (quantityUIGrid.currentDocumentType === 1 || quantityUIGrid.currentDocumentType === 2) {
                url = sg.utls.url.buildUrl("OE", "OrderEntry", "Index") + "?guid=" + guid + "&id=" + selectedData.DocumentNumber + "&isEditable=false";
            } else {
                url = sg.utls.url.buildUrl("PO", "PurchaseOrderEntry", "Index") + "?guid=" + guid + "&id=" + selectedData.DocumentNumber + "&disableAll=true";
            }

            sg.utls.iFrameHelper.openWindow(guid, "", url, 600);
        });
    },
    gridId: "",
    btnEditColumnsId: "",
    modelData: null,
    currentRowItemNumber: null,
    currentLocation: null,
    currentDocumentType: null,
    preferencesTypeId: null,
    defaultColumns: null,
    allLocation: false,
    pageSize: null,
    pageNumber:null,

    quantityGridConfig: function (area, controller, action, gridId, modelName, columnList) {

        quantityUIGrid.gridId = gridId;

        for (var prop in columnList) {
            quantityColumnName[prop] = columnList[prop];
        }

        return {
            autoBind: false,
            pageSize: sg.utls.gridPageSize,
            scrollable: true,
            reorderable: sg.utls.reorderable,
            navigatable: true, //enable grid cell tabbing for safari browser
            resizable: true,
            selectable: true,
            //reorderable: sg.utls.reorderable,
            isServerPaging: true,
            //Param will be null during Get and will contain the data that needs to be passed to the server on create
            param: null,
            //URL to get the data from the server. 
            pageUrl: sg.utls.url.buildUrl(area, controller, action),
            pageable: {
                input: true,
                numeric: false
            },
            getParam: function () {
                var grid = $('#' + gridId).data("kendoGrid");

                var parameters = {
                    pageNumber: grid.dataSource.page() - 1,
                    pageSize: sg.utls.gridPageSize,
                    model: ko.mapping.toJS(quantityUIGrid.modelData),
                    itemNumber: quantityUIGrid.currentRowItemNumber,
                    location: quantityUIGrid.currentLocation,
                    documentType: quantityUIGrid.currentDocumentType,
                };
                return parameters;
            },
            buildGridData: function (successData) {
                var gridData = null;

                if (successData == null) {
                    return;
                }

                if ((successData.UserMessage && successData.UserMessage.IsSuccess) || successData.Items !== undefined) {
                    gridData = [];

                    var documentNumberData = (successData.Data !== undefined) ? successData.Data[modelName] : successData;
                    ko.mapping.fromJS(documentNumberData, {}, quantityUIGrid.modelData[modelName]);
                    gridData.data = documentNumberData.Items
                    gridData.totalResultsCount = documentNumberData.TotalResultsCount;

                } else {
                    sg.utls.showMessage(successData);
                    if (quantityUIGrid.ScreenName == "OrderEntry") {
                        $("#quantityOnSoGridWindow").data("kendoWindow").close();
                        $("#quantityOnPoGridWindow").data("kendoWindow").close();
                        $("#quantityCommittedGridWindow").data("kendoWindow").close();
                        $("#AllLocQuantitySoGridWindow").data("kendoWindow").close();
                        $("#AllLocQuantityPoGridWindow").data("kendoWindow").close();
                        $("#AllLocQuantityCommittedGridWindow").data("kendoWindow").close();
                    }
                    else if (quantityUIGrid.ScreenName == "CreditDebitNoteEntry") {
                        $("#creditdebitquantityOnSoGridWindow").data("kendoWindow").close();
                        $("#creditdebitquantityOnPoGridWindow").data("kendoWindow").close();
                        $("#creditdebitquantityCommittedGridWindow").data("kendoWindow").close();
                        $("#creditdebitAllLocQuantitySoGridWindow").data("kendoWindow").close();
                        $("#creditdebitAllLocQuantityPoGridWindow").data("kendoWindow").close();
                        $("#creditdebitAllLocQuantityCommittedGridWindow").data("kendoWindow").close();
                    }
                }
               return gridData;
            },
            //Call back function after data is bound to the grid. Is used to set the added line as editable
            //afterDataBind: BomGridUtility.setLineEditable,
            afterDataBind: function (e) { quantityUIGrid.registerSettingsEvent(e); },
            columnReorder: function (e) {
                GridPreferencesHelper.saveColumnOrder(e, '#' + quantityUIGrid.gridId, quantityUIGrid.preferencesTypeId);
            },

            columns: [
                 gridQuantityColConfig.getColumn(quantityColumnName.Detail, false, quantityGridResources.DetailTitle, "w80", '#= quantityUIGrid.getSettings(DetailLineUniquifier) #', null, gridQuantityColConfig.noEditor),
                 gridQuantityColConfig.getColumn(quantityColumnName.ExpectedShipArrivalDate, false, "", "w220", '#= quantityUIGrid.getFormattedDate(ExpectedShippingArrivalDate) #', null, gridQuantityColConfig.noEditor),
                 gridQuantityColConfig.getColumn(quantityColumnName.Location, false, quantityGridResources.Location, "w220", null, null, gridQuantityColConfig.noEditor),
                 gridQuantityColConfig.getColumn(quantityColumnName.Quantity, false, quantityGridResources.Quantity, "w220", '#= quantityUIGrid.getFormattedValue(QtyInStockingUnit) #', null, gridQuantityColConfig.noEditor),
                 gridQuantityColConfig.getColumn(quantityColumnName.DocumentNumber, false, "", "w220", null, null, gridQuantityColConfig.noEditor),
                 gridQuantityColConfig.getColumn(quantityColumnName.Date, false, quantityGridResources.Date, "w220", '#= quantityUIGrid.getFormattedDate(DocumentDate) #', null, gridQuantityColConfig.noEditor),
                 gridQuantityColConfig.getColumn(quantityColumnName.CustVendorNumber, false,"", "w220", null, null, gridQuantityColConfig.noEditor),
                 gridQuantityColConfig.getColumn(quantityColumnName.CustVendorName, false, "", "w220", null, null, gridQuantityColConfig.noEditor),
            ],
        }
    }
};
