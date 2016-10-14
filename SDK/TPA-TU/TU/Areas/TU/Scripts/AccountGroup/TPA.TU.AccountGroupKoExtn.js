/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */
"use strict";

function accountGroupObservableExtension(accountGroupModel, uiMode) {
    var model = accountGroupModel.Data;
    model.UIMode = ko.observable(uiMode);

    model.Inactive = ko.computed({
        read: function () {
            return (model.Status() === accountGroupUI.status.InActive);
        },
        write: function (value) {
            if (value) {
                model.Status(accountGroupUI.status.InActive);
            } else {
                model.Status(accountGroupUI.status.Active);
            }
        }
    });

    model.ComputedInactiveDate = ko.computed(function () {
        if (model.Status() === accountGroupUI.status.Active) {
            return null;
        } else {
            return sg.utls.kndoUI.getFormattedDate(model.InactiveDate()) ? sg.utls.kndoUI.getFormattedDate(model.InactiveDate()) : accountGroupModel.FormattedInactiveDate();
        }
    });

    model.ComputedLastMaintainedDate = ko.computed(function () {
        return sg.utls.kndoUI.getFormattedDate(model.DateLastMaintained());
    });


    model.ComputedFunctionalCurrency = ko.computed(function () {
        if (model.CurrencyCodeforAccount() != accountGroupUI.functionalCurrency && accountGroupModel.IsValidCurrency()) {
            return false;
        } else {
            return true;
        }
    });

    model.ComputedGainOrLoss = ko.computed(function () {
        if (model.CurrencyCodeforAccount() != accountGroupUI.functionalCurrency && accountGroupModel.IsValidCurrency()) {
            return (accountGroupModel.GainOrLossAccountingMethod() === GainOrLossAccounting.RecognizedGainOrLoss);
        }
        return true;
    });

};

