/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */
"use strict";
var modelData;
var AccountType = { PayablesControl: 1, Discounts: 2, Prepayment: 3, Retainage: 4, UnrealizedExchangeGain: 5, UnrealizedExchangeLoss: 6, ExchangeGain: 7, ExchangeLoss: 8, ExchangeRounding: 9 };
var GainOrLossAccounting = { RealizedandUnrealizedGainOrLoss: 1, RecognizedGainOrLoss: 2 };
var accountGroupUI = accountGroupUI || {};
accountGroupUI = {
    accountGroupModel: {},
    status: { InActive: 0, Active: 1 },
    type: null,
    ignoreIsDirtyProperties: ["AccountGroupCode"],
    computedProperties: ["UIMode", "Inactive", "ComputedInactiveDate", "ComputedFunctionalCurrency"],
    hasKoBindingApplied: false,
    isKendoControlNotInitialised: false,
    accountGroupCode: null,
    checkStatus: true,
    functionalCurrency: null,
    funCurrencyDescription: null,
    isValidCurrency: true,
    init: function () {
        accountGroupUI.initButtons();
        accountGroupUI.initOnBlur();
        accountGroupUI.initFinders();
        accountGroupUISuccess.initialLoad(AccountGroupViewModel);
        accountGroupUISuccess.setkey();
    },
    saveAccountGroup: function () {
        if ($("#frmAccountGroup").valid()) {
            var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
            if (modelData.UIMode() === sg.utls.OperationMode.SAVE) {
                accountGroupRepository.update(data);
            } else {
                accountGroupRepository.add(data);
            }
        }
    },
    initButtons: function () {
        sg.exportHelper.setExportEvent("btnOptionExport", "tuaccountgroup", false, $.noop);
        sg.importHelper.setImportEvent("btnOptionImport", "tuaccountgroup", false, $.noop);

        $("#btnNew").bind('click', function () {
            accountGroupUI.checkIsDirty(accountGroupUI.create, accountGroupUI.accountGroupCode);
        });

        $("#btnSave").bind('click', function () {
            sg.utls.SyncExecute(accountGroupUI.saveAccountGroup);
        });

        $("#btnDelete").bind('click', function () {
            if ($("#frmAccountGroup").valid()) {
                var message = jQuery.validator.format(accountGroupResources.DeleteConfirmMessage, accountGroupResources.AccountGroupCodeTitle, modelData.AccountGroupCode());
                sg.utls.showKendoConfirmationDialog(function () {
                    sg.utls.clearValidations("frmAccountGroup");
                    accountGroupRepository.delete(modelData.AccountGroupCode());
                }, null, message, accountGroupResources.DeleteTitle);
            }
        });
    },
    initOnBlur: function () {

        $("#Data_AccountGroupCode").bind('blur', function (e) {
            //The below line of code is not correct as KO should only do this.
            //KO is not firing because Masking is there. This doesn't happens in the new version of mask plugin.
            //We can remove this once new version is applied.
            modelData.AccountGroupCode($("#Data_AccountGroupCode").val());
            sg.delayOnBlur("btnFinderAccountGroupCode", function () {
                if (sg.controls.GetString(modelData.AccountGroupCode())) {
                    if (sg.controls.GetString(accountGroupUI.accountGroupCode) !== sg.controls.GetString(modelData.AccountGroupCode())) {
                        accountGroupUI.checkIsDirty(accountGroupUI.get, accountGroupUI.accountGroupCode);
                    }
                }
            });
        });

        $("#Data_PayablesControlAccount").bind('change', function (e) {
            sg.delayOnBlur("btnFinderPayControlAccount", function () {
                accountGroupUI.type = AccountType.PayablesControl;
                var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
                accountGroupRepository.getAccountDescriptionData(data);
            });
        });
        $("#Data_DiscountsAccount").bind('change', function (e) {
            sg.delayOnBlur("btnFinderDiscountsAccount", function () {
                accountGroupUI.type = AccountType.Discounts;
                var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
                accountGroupRepository.getAccountDescriptionData(data);
            });
        });
        $("#Data_PrepaymentAccount").bind('change', function (e) {
            sg.delayOnBlur("btnFinderPrepaymentAccount", function () {
                accountGroupUI.type = AccountType.Prepayment;
                var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
                accountGroupRepository.getAccountDescriptionData(data);
            });
        });
        $("#Data_RetainageAccount").bind('change', function (e) {
            sg.delayOnBlur("btnFinderRetainageAccount", function () {
                accountGroupUI.type = AccountType.Retainage;
                var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
                accountGroupRepository.getAccountDescriptionData(data);
            });
        });
        $("#Data_UnrealizedExchangeGainAccount").bind('change', function (e) {
            sg.delayOnBlur("btnFinderUnExchangeGainAccount", function () {
                accountGroupUI.type = AccountType.UnrealizedExchangeGain;
                var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
                accountGroupRepository.getAccountDescriptionData(data);
            });
        });
        $("#Data_UnrealizedExchangeLossAccount").bind('change', function (e) {
            sg.delayOnBlur("btnFinderUnExchangeLossAccount", function () {
                accountGroupUI.type = AccountType.UnrealizedExchangeLoss;
                var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
                accountGroupRepository.getAccountDescriptionData(data);
            });
        });
        $("#Data_ExchangeGainAccount").bind('change', function (e) {
            sg.delayOnBlur("btnFinderExchangeGainAccount", function () {
                accountGroupUI.type = AccountType.ExchangeGain;
                var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
                accountGroupRepository.getAccountDescriptionData(data);
            });
        });
        $("#Data_ExchangeLossAccount").bind('change', function (e) {
            sg.delayOnBlur("btnFinderExchangeLossAccount", function () {
                accountGroupUI.type = AccountType.ExchangeLoss;
                var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
                accountGroupRepository.getAccountDescriptionData(data);
            });
        });
        $("#Data_ExchangeRoundingAccount").bind('change', function (e) {
            sg.delayOnBlur("btnFinderExchangeRoundingAccount", function () {
                accountGroupUI.type = AccountType.ExchangeRounding;
                var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
                accountGroupRepository.getAccountDescriptionData(data);
            });
        });

        $("#Data_CurrencyCodeforAccount").bind('change', function (e) {
            sg.delayOnBlur("btnFinderCurrency", function () {
                var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
                accountGroupRepository.getCurrencyDescription(data);
            });
        });

    },
    initFinders: function () {
        var title = jQuery.validator.format(accountGroupResources.FinderTitle, accountGroupResources.AccountGroupFinderTitle);
        sg.finderHelper.setFinder("btnFinderAccountGroupCode", "tuaccountgroup", onFinderSuccess.finderSuccess, $.noop, title, accountGroupFilter.getFilter);
        sg.finderHelper.setFinder("btnFinderCurrency", "currencyCode", onFinderSuccess.currencyCode, $.noop, title, accountGroupFilter.getCurrencyCode, null, true);

        var accountTitle = jQuery.validator.format(accountGroupResources.FinderTitle, accountGroupResources.AccountTitle);
        sg.finderHelper.setFinder("btnFinderPayControlAccount", "accountdistribution", onFinderSuccess.payControlAcct, $.noop, accountTitle, accountGroupFilter.getPayControlAcct, null, true);
        sg.finderHelper.setFinder("btnFinderDiscountsAccount", "accountdistribution", onFinderSuccess.discountAcct, $.noop, accountTitle, accountGroupFilter.getdiscountAcct, null, true);
        sg.finderHelper.setFinder("btnFinderPrepaymentAccount", "accountdistribution", onFinderSuccess.prepaymentAcct, $.noop, accountTitle, accountGroupFilter.getPrepaymentAcct, null, true);
        sg.finderHelper.setFinder("btnFinderRetainageAccount", "accountdistribution", onFinderSuccess.retainageAcct, $.noop, accountTitle, accountGroupFilter.getRetainageAcct, null, true);
        sg.finderHelper.setFinder("btnFinderUnExchangeGainAccount", "accountdistribution", onFinderSuccess.unExchangeGainAcct, $.noop, accountTitle, accountGroupFilter.getUnExchangeGainAcct, null, true);
        sg.finderHelper.setFinder("btnFinderUnExchangeLossAccount", "accountdistribution", onFinderSuccess.unExchangeLossAcct, $.noop, accountTitle, accountGroupFilter.getUnExchangeLossAcct, null, true);
        sg.finderHelper.setFinder("btnFinderExchangeGainAccount", "accountdistribution", onFinderSuccess.exchangeGainAcct, $.noop, accountTitle, accountGroupFilter.getExchangeGainAcct, null, true);
        sg.finderHelper.setFinder("btnFinderExchangeLossAccount", "accountdistribution", onFinderSuccess.exchangeLossAcct, $.noop, accountTitle, accountGroupFilter.getExchangeLossAcct, null, true);
        sg.finderHelper.setFinder("btnFinderExchangeRoundingAccount", "accountdistribution", onFinderSuccess.exchangeRoundingAcct, $.noop, accountTitle, accountGroupFilter.getExchangeRoundingAcct, null, true);
    },
    get: function () {
        accountGroupRepository.get(modelData.AccountGroupCode());
    },
    create: function () {
        sg.utls.clearValidations("frmAccountGroup");
        accountGroupRepository.create();
    },
    statusChange: function (value) {
        if (value && sg.controls.GetString(modelData.AccountGroupCode() !== "")) {
            if ($("#frmAccountGroup").valid()
                && modelData.UIMode() === sg.utls.OperationMode.SAVE) {
                if (accountGroupUI.checkStatus) {
                    var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
                    accountGroupRepository.UpdateStatus(data);
                }
                accountGroupUI.checkStatus = true;
            }
        }
    },
    checkIsDirty: function (funcionToCall, accountGroup) {
        if (accountGroupUI.accountGroupModel.isModelDirty.isDirty() && accountGroup !== null && accountGroup !== "") {
            sg.utls.showKendoConfirmationDialog(
                function () { // Yes
                    sg.utls.clearValidations("frmAccountGroup");
                    sg.controls.enable('#Data_CurrencyCodeforAccount');
                    sg.controls.enable('#btnFinderCurrency');
                    funcionToCall.call();
                },
                function () { // No
                    if (sg.controls.GetString(accountGroup) !== sg.controls.GetString(modelData.AccountGroupCode())) {
                        modelData.AccountGroupCode(accountGroup);
                    }
                    return;
                },
                jQuery.validator.format(globalResource.SaveConfirm, accountGroupResources.AccountGroupCodeTitle, accountGroup));
        } else {
            sg.controls.enable('#Data_CurrencyCodeforAccount');
            sg.controls.enable('#btnFinderCurrency');
            funcionToCall.call();
        }
    },
    clearCurrencyAccount: function () {
        modelData.UnrealizedExchangeGainAccount(null);
        accountGroupUI.accountGroupModel.UnrealizedExchangeGainDesc(null);
        modelData.UnrealizedExchangeLossAccount(null);
        accountGroupUI.accountGroupModel.UnrealizedExchangeLossDesc(null);
        modelData.ExchangeGainAccount(null);
        accountGroupUI.accountGroupModel.ExchangeGainDesc(null);
        modelData.ExchangeLossAccount(null);
        accountGroupUI.accountGroupModel.ExchangeLossDesc(null);
        modelData.ExchangeRoundingAccount(null);
        accountGroupUI.accountGroupModel.ExchangeRoundingDesc(null);
    },
};
var onFinderSuccess = {

    finderSuccess: function (result) {
        sg.utls.clearValidations("frmAccountGroup");
        accountGroupUI.finderData = result;
        accountGroupUI.checkIsDirty(accountGroupUISuccess.setFinderData, accountGroupUI.accountGroupCode);

    },
    currencyCode: function (result) {
        if (result !== null) {
            var currencyCode = result.CurrencyCodeId;
            modelData.CurrencyCodeforAccount(currencyCode);
            var result = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
            accountGroupRepository.getCurrencyDescription(result);
        }
    },
    payControlAcct: function (result) {
        if (result !== null) {
            modelData.PayablesControlAccount(result.AccountNumber);
            accountGroupUI.type = AccountType.PayablesControl;
            var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
            accountGroupRepository.getAccountDescriptionData(data);
        }
    },
    discountAcct: function (result) {
        if (result !== null) {
            modelData.DiscountsAccount(result.AccountNumber);
            accountGroupUI.type = AccountType.Discounts;
            var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
            accountGroupRepository.getAccountDescriptionData(data);
        }
    },
    prepaymentAcct: function (result) {
        if (result !== null) {
            modelData.PrepaymentAccount(result.AccountNumber);
            accountGroupUI.type = AccountType.Prepayment;
            var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
            accountGroupRepository.getAccountDescriptionData(data);
        }
    },
    retainageAcct: function (result) {
        if (result !== null) {
            modelData.RetainageAccount(result.AccountNumber);
            accountGroupUI.type = AccountType.Retainage;
            var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
            accountGroupRepository.getAccountDescriptionData(data);
        }
    },
    unExchangeGainAcct: function (result) {
        if (result !== null) {
            modelData.UnrealizedExchangeGainAccount(result.AccountNumber);
            accountGroupUI.type = AccountType.UnrealizedExchangeGain;
            var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
            accountGroupRepository.getAccountDescriptionData(data);
        }
    },
    unExchangeLossAcct: function (result) {
        if (result !== null) {
            modelData.UnrealizedExchangeLossAccount(result.AccountNumber);
            accountGroupUI.type = AccountType.UnrealizedExchangeLoss;
            var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
            accountGroupRepository.getAccountDescriptionData(data);
        }
    },
    exchangeGainAcct: function (result) {
        if (result !== null) {
            modelData.ExchangeGainAccount(result.AccountNumber);
            accountGroupUI.type = AccountType.ExchangeGain;
            var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
            accountGroupRepository.getAccountDescriptionData(data);
        }
    },
    exchangeLossAcct: function (result) {
        if (result !== null) {
            modelData.ExchangeLossAccount(result.AccountNumber);
            accountGroupUI.type = AccountType.ExchangeLoss;
            var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
            accountGroupRepository.getAccountDescriptionData(data);
        }
    },
    exchangeRoundingAcct: function (result) {
        if (result !== null) {
            modelData.ExchangeRoundingAccount(result.AccountNumber);
            accountGroupUI.type = AccountType.ExchangeRounding;
            var data = sg.utls.ko.toJS(modelData, accountGroupUI.computedProperties);
            accountGroupRepository.getAccountDescriptionData(data);
        }
    },


}
var accountGroupUISuccess = {

    setkey: function () {
        accountGroupUI.accountGroupCode = modelData.AccountGroupCode();
    },
    get: function (jsonResult) {
        if (jsonResult.UserMessage && jsonResult.UserMessage.IsSuccess) {
            if (jsonResult.Data !== null) {
                accountGroupUI.checkStatus = (jsonResult.Data.Status === accountGroupUI.status.Active);
                accountGroupUISuccess.displayResult(jsonResult, sg.utls.OperationMode.SAVE);
            } else {
                modelData.UIMode(sg.utls.OperationMode.NEW);
            }
        }
        else {
            modelData.UIMode(sg.utls.OperationMode.NEW)
        }
        accountGroupUISuccess.setkey();
        sg.controls.Select($("#txtDescription"));
    },
    update: function (jsonResult) {
        if (jsonResult.UserMessage.IsSuccess) {
            accountGroupUISuccess.displayResult(jsonResult, sg.utls.OperationMode.SAVE);
            accountGroupUISuccess.setkey();
        }
        sg.utls.showMessage(jsonResult);
    },
    updateStatus: function (jsonResult) {
        if (!jsonResult.UserMessage.IsSuccess) {
            modelData.Status(accountGroupUI.status.Active);
            window.sg.utls.showMessage(jsonResult)
        }
    },
    create: function (jsonResult) {
        accountGroupUISuccess.displayResult(jsonResult, sg.utls.OperationMode.NEW);
        accountGroupUI.accountGroupModel.isModelDirty.reset();
        accountGroupUISuccess.setkey();
        sg.controls.Focus($("#Data_AccountGroupCode"));
        modelData.CurrencyCodeforAccount(accountGroupUI.functionalCurrency);
        accountGroupUI.accountGroupModel.CurrencyDesc(accountGroupUI.funCurrencyDescription);
    },
    delete: function (jsonResult) {
        if (jsonResult.UserMessage.IsSuccess) {
            accountGroupUISuccess.displayResult(jsonResult, sg.utls.OperationMode.NEW);
            accountGroupUI.accountGroupModel.isModelDirty.reset();
            accountGroupUISuccess.setkey();
        }
        sg.utls.showMessage(jsonResult);
    },
    displayResult: function (jsonResult, uiMode) {
        if (jsonResult !== null) {
            if (!accountGroupUI.hasKoBindingApplied) {
                accountGroupUI.accountGroupModel = ko.mapping.fromJS(jsonResult);
                accountGroupUI.hasKoBindingApplied = true;
                modelData = accountGroupUI.accountGroupModel.Data;
                accountGroupUI.functionalCurrency = modelData.CurrencyCodeforAccount();
                accountGroupUI.funCurrencyDescription = accountGroupUI.accountGroupModel.CurrencyDesc();
                accountGroupObservableExtension(accountGroupUI.accountGroupModel, uiMode);
                modelData.Inactive.subscribe(accountGroupUI.statusChange);
                // modelData.ComputedFunctionalCurrency.subscribe(accountGroupUI.currencyDescription);
                accountGroupUI.accountGroupModel.isModelDirty = new ko.dirtyFlag(modelData, accountGroupUI.ignoreIsDirtyProperties);
                ko.applyBindings(accountGroupUI.accountGroupModel);
            } else {
                ko.mapping.fromJS(jsonResult, accountGroupUI.accountGroupModel);
                modelData.UIMode(uiMode);
                if (uiMode !== sg.utls.OperationMode.NEW) {
                    accountGroupUI.accountGroupModel.isModelDirty.reset();
                    sg.controls.disable('#Data_CurrencyCodeforAccount');
                    sg.controls.disable('#btnFinderCurrency');
                }
                if (uiMode === sg.utls.OperationMode.NEW) {
                    sg.controls.enable('#Data_CurrencyCodeforAccount');
                    sg.controls.enable('#btnFinderCurrency');

                }
            }
        }
    },
    initialLoad: function (result) {
        if (result) {
            accountGroupUISuccess.displayResult(result, sg.utls.OperationMode.NEW);
        }
        else {
            sg.utls.showMessageInfo(sg.utls.msgType.ERROR, sourceCodeResources.ProcessFailedMessage);
        }
        sg.controls.Focus($("#Data_AccountGroupCode"));
    },
    setFinderData: function () {
        accountGroupRepository.get(accountGroupUI.finderData.AccountGroupCode);
        accountGroupUISuccess.setkey();
        $("#message").empty();
    },
    isNew: function (model) {
        if (model.accountGroupCode() === null) {
            return true;
        }
        return false;
    },
    actDescription: function (result) {
        if (result !== null) {
            switch (accountGroupUI.type) {
                case AccountType.PayablesControl:
                    modelData.PayablesControlAccount(result.Data.PayablesControlAccount);
                    accountGroupUI.accountGroupModel.PayablesControlDesc(result.PayablesControlDesc);
                    break;
                case AccountType.Discounts:
                    modelData.DiscountsAccount(result.Data.DiscountsAccount);
                    accountGroupUI.accountGroupModel.DiscountsDesc(result.DiscountsDesc);
                    break;
                case AccountType.Prepayment:
                    modelData.PrepaymentAccount(result.Data.PrepaymentAccount);
                    accountGroupUI.accountGroupModel.PrepaymentDesc(result.PrepaymentDesc);
                    break;
                case AccountType.Retainage:
                    modelData.RetainageAccount(result.Data.RetainageAccount);
                    accountGroupUI.accountGroupModel.RetainageDesc(result.RetainageDesc);
                    break;
                case AccountType.UnrealizedExchangeGain:
                    modelData.UnrealizedExchangeGainAccount(result.Data.UnrealizedExchangeGainAccount);
                    accountGroupUI.accountGroupModel.UnrealizedExchangeGainDesc(result.UnrealizedExchangeGainDesc);
                    break;
                case AccountType.UnrealizedExchangeLoss:
                    modelData.UnrealizedExchangeLossAccount(result.Data.UnrealizedExchangeLossAccount);
                    accountGroupUI.accountGroupModel.UnrealizedExchangeLossDesc(result.UnrealizedExchangeLossDesc);
                    break;
                case AccountType.ExchangeGain:
                    modelData.ExchangeGainAccount(result.Data.ExchangeGainAccount);
                    accountGroupUI.accountGroupModel.ExchangeGainDesc(result.ExchangeGainDesc);
                    break;
                case AccountType.ExchangeLoss:
                    modelData.ExchangeLossAccount(result.Data.ExchangeLossAccount);
                    accountGroupUI.accountGroupModel.ExchangeLossDesc(result.ExchangeLossDesc);
                    break;
                case AccountType.ExchangeRounding:
                    modelData.ExchangeRoundingAccount(result.Data.ExchangeRoundingAccount);
                    accountGroupUI.accountGroupModel.ExchangeRoundingDesc(result.ExchangeRoundingDesc);
                    break;
                default:
            }

            if (result.UserMessage.Warnings !== null || result.UserMessage.Errors !== null) {
                switch (accountGroupUI.type) {
                    case AccountType.PayablesControl:
                        sg.controls.Focus($("#Data_PayablesControlAccount"));
                        break;
                    case AccountType.Discounts:
                        sg.controls.Focus($("#Data_DiscountsAccount"));
                        break;
                    case AccountType.Prepayment:
                        sg.controls.Focus($("#Data_PrepaymentAccount"));
                        break;
                    case AccountType.Retainage:
                        sg.controls.Focus($("#Data_RetainageAccount"));
                        break;
                    case AccountType.UnrealizedExchangeGain:
                        sg.controls.Focus($("#Data_UnrealizedExchangeGainAccount"));
                        break;
                    case AccountType.UnrealizedExchangeLoss:
                        sg.controls.Focus($("#Data_UnrealizedExchangeLossAccount"));
                        break;
                    case AccountType.ExchangeGain:
                        sg.controls.Focus($("#Data_ExchangeGainAccount"));
                        break;
                    case AccountType.ExchangeLoss:
                        sg.controls.Focus($("#Data_ExchangeLossAccount"));
                        break;
                    case AccountType.ExchangeRounding:
                        sg.controls.Focus($("#Data_ExchangeRoundingAccount"));
                    default:
                }
                accountGroupUI.type = null;

            }
            sg.utls.showMessage(result);
        }
    },
    currencyDescription: function (result) {
        if (result !== null) {
            accountGroupUI.accountGroupModel.CurrencyDesc(result.CurrencyDesc);
            if (modelData.CurrencyCodeforAccount() === accountGroupUI.functionalCurrency)
                accountGroupUI.clearCurrencyAccount();
            if (!result.UserMessage.IsSuccess) {
                sg.controls.Focus($("#Data_CurrencyCodeforAccount"));
            }
            accountGroupUI.accountGroupModel.IsValidCurrency(result.IsValidCurrency);
            modelData.CurrencyCodeforAccount(result.Data.CurrencyCodeforAccount);
        }

        window.sg.utls.showMessage(result);
    }
};

var accountGroupFilter = {
    getFilter: function () {
        var filters = [[]];
        filters[0][0] = sg.finderHelper.createFilter("AccountGroupCode", sg.finderOperator.StartsWith, modelData.AccountGroupCode());
        return filters;
    },
    getCurrencyCode: function () {
        var filters = [[]];
        var AccountNumber = $("#Data_CurrencyCodeforAccount").val();
        filters[0][0] = sg.finderHelper.createFilter("CurrencyCodeId", sg.finderOperator.StartsWith, AccountNumber);
        return filters;
    },
    getPayControlAcct: function () {
        var filters = [[]];
        var AccountNumber = $("#Data_PayablesControlAccount").val();
        filters[0][0] = sg.finderHelper.createFilter("AccountNumber", sg.finderOperator.StartsWith, AccountNumber);
        return filters;
    },
    getdiscountAcct: function () {
        var filters = [[]];
        var AccountNumber = $("#Data_DiscountsAccount").val();
        filters[0][0] = sg.finderHelper.createFilter("AccountNumber", sg.finderOperator.StartsWith, AccountNumber);
        return filters;
    },
    getPrepaymentAcct: function () {
        var filters = [[]];
        var AccountNumber = $("#Data_PrepaymentAccount").val();
        filters[0][0] = sg.finderHelper.createFilter("AccountNumber", sg.finderOperator.StartsWith, AccountNumber);
        return filters;
    },
    getRetainageAcct: function () {
        var filters = [[]];
        var AccountNumber = $("#Data_RetainageAccount").val();
        filters[0][0] = sg.finderHelper.createFilter("AccountNumber", sg.finderOperator.StartsWith, AccountNumber);
        return filters;
    },
    getUnExchangeGainAcct: function () {
        var filters = [[]];
        var AccountNumber = $("#Data_UnrealizedExchangeGainAccount").val();
        filters[0][0] = sg.finderHelper.createFilter("AccountNumber", sg.finderOperator.StartsWith, AccountNumber);
        return filters;
    },
    getUnExchangeLossAcct: function () {
        var filters = [[]];
        var AccountNumber = $("#Data_UnrealizedExchangeLossAccount").val();
        filters[0][0] = sg.finderHelper.createFilter("AccountNumber", sg.finderOperator.StartsWith, AccountNumber);
        return filters;
    },
    getExchangeGainAcct: function () {
        var filters = [[]];
        var AccountNumber = $("#Data_ExchangeGainAccount").val();
        filters[0][0] = sg.finderHelper.createFilter("AccountNumber", sg.finderOperator.StartsWith, AccountNumber);
        return filters;
    },
    getExchangeLossAcct: function () {
        var filters = [[]];
        var AccountNumber = $("#Data_ExchangeLossAccount").val();
        filters[0][0] = sg.finderHelper.createFilter("AccountNumber", sg.finderOperator.StartsWith, AccountNumber);
        return filters;
    },
    getExchangeRoundingAcct: function () {
        var filters = [[]];
        var AccountNumber = $("#Data_ExchangeRoundingAccount").val();
        filters[0][0] = sg.finderHelper.createFilter("AccountNumber", sg.finderOperator.StartsWith, AccountNumber);
        return filters;
    },

};

$(function () {
    accountGroupUI.init();
    $(window).bind('beforeunload', function () {
        if (globalResource.AllowPageUnloadEvent && accountGroupUI.accountGroupModel.isModelDirty.isDirty()) {
            return jQuery('<div />').html(jQuery.validator.format(globalResource.SaveConfirm2, accountGroupResources.AccountGroupTitle)).text();


        }
    });

});


var grid_data = [];

function guid() {
    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000)
          .toString(16)
          .substring(1);
    }
    return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
      s4() + '-' + s4() + s4() + s4();
}

function updateControl(control) {
    var id = '#' + control.id;

    if (control.Show) {
        $(id).css("display", "");
    } else {
        $(id).css("display", "none");
    }

    // set text for label
    if (control.Type === "Label") {
        $(id).text(control.Text);
    }
}

$('#btnCustomizeUI').bind('click', function () {

    $("body").append("<div id='dlgCustomize'> <div id='grid'></div> </div>");

    // initialize grid_data
    grid_data = [];

    // search for all elements having "data-sage300uicontrol" attribute
    $("[data-sage300uicontrol]").each( function () {

       
        var elem = {};
        elem.Show = true;

        var bindingInfo = {};
        $($(this).attr("data-sage300uicontrol").split(",")).each(function(idx, binding) {
                var parts = binding.split(":");
                bindingInfo[parts[0].trim()] = parts[1].trim();
            }
        );

        elem.Type = bindingInfo['type'];
        elem.Name = bindingInfo['name'];
        elem.Text = $(this).text();

        // if id exists, use it, otherwise, use the type+name as the id
        if ($(this).attr("id")) {
            elem.id = $(this).attr("id");
        } else {
            elem.id = guid();
            // add id to the element
            $(this).attr('id', elem.id);
        }

        if ($(this).css("display") === "none") {
            elem.Show = false;
        }

        grid_data.push(elem);

    });

    function grid_save(e) {
        if (e.values.Text != e.model.Text) {
            e.model.Text = e.values.Text;
            updateControl(e.model);
        }
    }

    var grid = $("#grid").kendoGrid({
        dataSource: {
            data: grid_data,
            schema: {
                model: {
                    fields: {
                        Show: { type: "boolean", editable:true },
                        Type: { type: "string", editable: false },
                        Name: { type: "string", editable:false },
                        Text: { type: "string", editable: true },
                        id: {type:"string", editable:false}
                    },
                }
            },
           
            pageSize: 10
        },
        height: 380,
        groupable: false,
        sortable: true,
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
        columns: [{
            field: "Show",
            width: 80,
            sortable:false,
            template: '<div class="icon checkBox #=Show?"selected":""# "><input type="checkbox" #=Show?"checked":""# > </div>'
        }, {
            field: "Type",
            sortable: false,
            width: 100
        }, {
            field: "Text",
            sortable: false,
            width: 250
        },
        {
            hidden: true,
            field: "Name",
            width: 200,
        },
        {
             hidden: true,
             field: "id",
             width: 200,
        }],
        editable:true
    }).data("kendoGrid");
    
    grid.bind("save", grid_save);
    grid.tbody.delegate(":checkbox", "change", function () {
        var checkBox = $(this);
        var model = grid.dataItem(checkBox.closest("tr"));
        model.set("Show", checkBox.is(":checked"));

        // get the data
        updateControl(model);

    });
  
   var accessWindow=$('#dlgCustomize').kendoWindow({
          title: 'Customize',
          height: '420px',
          width: '700px',
          draggable: true,
          show: 'blind',
          hide: 'blind',
          modal: true,
          resizable: false,
          close: function (event, ui) {

              // get the data
              var sageControls = $("#grid").data("kendoGrid").dataSource.data();

              //alert(JSON.stringify($("#grid").data("kendoGrid").dataSource.data()));
              
              for (var i = 0; i < sageControls.length; i++) {

                  updateControl(sageControls[i]) ;

              }

              // delete the div
              $("#dlgCustomize").remove();
              this.destroy();

          }
   }).data("kendoWindow").center().open();  
  });

