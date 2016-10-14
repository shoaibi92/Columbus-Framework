define(
[
	'underscore',
    'jquery',
    'BaseView',
    'MessageBus',
    'handlebars',

	'text!Scripts/App/Pages/Order/OrderDetailViewTemplate.html',
    '/Scripts/App/Domain/OrderDetail.js',
    '/Scripts/App/Domain/OrderDetails.js',
    'kendo',
    'kendobbds'
],
function (_, $, BaseView, MessageBus, Handlebars, template, OrderDetail, OrderDetails, kendo, kendobbds) {

    'use strict';

    return BaseView.extend({
        tagName: 'div',
        
        template: {
            name: 'OrderDetailViewTemplate',
            source: template
        },

        elements: {

        },

        events: {
            
        },

        initialize: function (options) {
            this.model = options.model;
         },

        postRender: function () {

            // Build the data source for the items
            var bbds = new kendo.Backbone.DataSource({
                collection: this.model.details,
                schema: {
                    model: {
                        id: "id",
                        fields: {
                            id: { type: "number", editable: false },
                            itemCode: { type: "text", editable: true },
                            itemDescription: { type: "text", editable: true },
                            price: { type: 'number', editable: true },
                            quantity: { type: 'number', editable: true}
                        }
                    }
                },
            });

             this.$el.kendoGrid({
                 dataSource: bbds,
                 editable: true,
                 pageable: {
                     refresh: true,
                     pageSizes: true,
                     buttonCount: 5
                 },
                 columns: [{
                     field: 'id'
                 }, {
                     field: "itemCode",
                     title: "Item Code",
                     width: 240
                 }, {
                     field: "itemDescription",
                     title: "Description"
                 }, {
                     field: "price",
                     title: "itemPrice"
                 }, {
                     field: "quantity",
                     title: 'Quantity',
                     width: 150
                 }]
             });

        }
    });
});