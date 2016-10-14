define(
[
	'underscore',
    'jquery',
    'backbone',
    'stickit',
    'BaseView',
    'MessageBus',
    'handlebars',

    '/Scripts/App/Domain/FinderItem.js',

	'text!Scripts/App/Widgets/Finder/PopupTemplate.html',
    'kendo'
],
function (_, $, backbone, stickit, BaseView, MessageBus, Handlebars, FinderItem, template, kendo) {

    'use strict';

    return BaseView.extend({
        template: {
            name: 'FinderWidgetPopupTemplate',
            source: template
        },

        events: {
            'click #btnOk': 'okButtonClicked',
            'click #btnCancel': 'cancelButtonClicked'
        },

        okButtonClicked: function () {
            var value = this.model.get('code');            
            this.options.itemSelectedCallback(value);
            this.close();
        },

        cancelButtonClicked: function () {
            this.close();
        },

        show: function (value) {

            this.model.set('code', value);
            this.popup.center().open();
        },

        close: function() {
            this.popup.close();
        },

        bindings: {
            '#code': 'code'
        },

        initialize: function (options) {

            this.options = options;
            this.model = new FinderItem({ code: '', description: '' });

            this.popup = this.$el.kendoWindow({
                modal: true,
                title: 'Finder Popup',
                resizable: false,
                draggable: false,
                scrollable: true,
                visible: false,
                width: 600,
                height: 400,
                activate: function () { },
                close: function (data) { },
                //Open Kendo Window in center of the Viewport
                open: function () { },
            }).data("kendoWindow");
        },

        postRender: function () {
            this.stickit();
        }
    });
});