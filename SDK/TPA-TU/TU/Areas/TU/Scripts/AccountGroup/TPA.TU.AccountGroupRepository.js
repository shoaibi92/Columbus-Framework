/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */
"use strict";
var accountGroupAjax = {
    call: function (method, data, successMethod) {
        var url = sg.utls.url.buildUrl("TU", "TUAccountGroup", method);
        sg.utls.ajaxPost(url, data, successMethod);
    }
};

var accountGroupRepository = {
    get: function (id) {
        var data = { 'id': id };
        accountGroupAjax.call("Get", data, accountGroupUISuccess.get);
    },
    create: function () {
        var data = {};
        accountGroupAjax.call("Create", data, accountGroupUISuccess.create);
    },

    delete: function (id) {
        var data = { 'id': id };
        accountGroupAjax.call("Delete", data, accountGroupUISuccess.delete);
    },

    add: function (data) {
        accountGroupAjax.call("Add", data, accountGroupUISuccess.update);
    },

    update: function (data) {
        accountGroupAjax.call("Save", data, accountGroupUISuccess.update);
    },

    UpdateStatus: function (data) {
        accountGroupAjax.call("UpdateStatus", data, accountGroupUISuccess.updateStatus);
    },
    getAccountDescriptionData: function (model) {

        var accountType;
        switch (accountGroupUI.type) {
            case AccountType.PayablesControl: accountType = AccountType.PayablesControl;
                break;
            case AccountType.Discounts: accountType = AccountType.Discounts;
                break;
            case AccountType.Prepayment: accountType = AccountType.Prepayment;
                break;
            case AccountType.Retainage: accountType = AccountType.Retainage;
                break;
            case AccountType.UnrealizedExchangeGain: accountType = AccountType.UnrealizedExchangeGain;
                break;
            case AccountType.UnrealizedExchangeLoss: accountType = AccountType.UnrealizedExchangeLoss;
                break;
            case AccountType.ExchangeGain: accountType = AccountType.ExchangeGain;
                break;
            case AccountType.ExchangeLoss: accountType = AccountType.ExchangeLoss;
                break;
            case AccountType.ExchangeRounding: accountType = AccountType.ExchangeRounding;
                break;
            default:
        }
        var data = { 'model': model, 'accountType': accountType };
        window.sg.utls.ajaxPostSync(window.sg.utls.url.buildUrl("TU", "TUAccountGroup", "GetAccountDescription"), data, accountGroupUISuccess.actDescription);
    },
    getCurrencyDescription: function (data) {
        window.sg.utls.ajaxPostSync(window.sg.utls.url.buildUrl("TU", "TUAccountGroup", "GetCurrencyDescription"), data, accountGroupUISuccess.currencyDescription);
    },
};

