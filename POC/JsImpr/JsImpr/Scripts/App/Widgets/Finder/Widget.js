define(
[
	'underscore',
    'jquery',
    'backbone',
    'stickit',
    'BaseView',
    'MessageBus',
    'handlebars',

	'text!Scripts/App/Widgets/Finder/WidgetTemplate.html',
    '/Scripts/App/Widgets/Finder/Popup.js',

    'kendo'
],
function (_, $, backbone, stickit, BaseView, MessageBus, Handlebars, template, FinderPopup, kendo) {

    'use strict';

    return BaseView.extend({
        template: {
            name: 'FinderWidgetTemplate',
            source: template
        },

        elements: [
            'finderPopup'
        ],

        events: {
            'click .js-button-go': 'goButtonClicked',
            'click .js-button-find': 'findButtonClicked'
        },

        goButtonClicked: function() {
            alert(this.options.id + ' go!');
        },

        findButtonClicked: function() {
            this.children['finderPopup'].show(this.getValue());
        },

        findSelected: function (value) {
            this.setValue(value);
        },

        initialize: function (options) {

            this.options = options;
            this.model = { id: options.id, label: options.label };

            _.bindAll(this, 'findSelected');
        },

        getValue: function() {
            return this.options.model.get(
                this.options.modelProperty);
        },

        setValue: function(value) {
            this.options.model.set(
                this.options.modelProperty, value);
        },

        postRender: function () {

            this.addChildren([
                {
                    id: 'finderPopup',
                    viewClass: FinderPopup,
                    parentElement: this.finderPopupElement,
                    options: {
                        itemSelectedCallback: this.findSelected
                    }
                }
            ]);

            //bind to the main model property
            var bindingModel = this.options.model;
            var bindingConfig = {};

            bindingConfig['#' + this.options.id] = this.options.modelProperty;

            this.stickit(bindingModel, bindingConfig);
        }

    });
});