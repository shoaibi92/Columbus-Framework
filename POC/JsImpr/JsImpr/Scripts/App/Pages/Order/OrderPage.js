define(
[
	'underscore',
    'jquery',
    'backbone',
    'stickit',
    'handlebars',
    'kendo',

    'BaseView',
    'MessageBus',

	'text!Scripts/App/Pages/Order/OrderPageTemplate.html',

    '/Scripts/App/Domain/Order.js',
    '/Scripts/App/Domain/OrderDetail.js',
    '/Scripts/App/Domain/OrderDetails.js',

    '/Scripts/App/Widgets/Finder/Widget.js',
    '/Scripts/App/Pages/Order/OrderDetailView.js'
],
function (
    _, $, backbone, stickit, Handlebars, kendo,
    BaseView, MessageBus,
    template,
    Order, OrderDetail, OrderDetails,
    FinderWidget, OrderDetailView) {

    'use strict';

    return BaseView.extend({
        tagName: 'div',
        className: 'OrderPage',
        
        template: {
            name: 'OrderPageTemplate',
            source: template
        },

        bindings: {
            '#customerCode': 'customerCode',
            '#orderTotal': 'orderTotal',
            '#isDirtyFlag': 'isDirty'
        },

        elements: [
            'customerCode',
            'shipToCode',
            'orderDetailView'
        ],

        events: {
            'click #btnSave': 'save',
            'click #btnCancel': 'cancel'
        },

        save: function() {
            alert('save clicked!');
        },

        cancel: function(){
            this.model.set('isDirty', false);
        },

        initialize: function () {

            this.model = new Order({ customerCode: '1200', customerName: 'Test customer', shipToCode: 'CAN-BC' });
            this.model.details.add(new OrderDetail({ id: 1, itemCode: 'I-0001', itemDescription: 'Very cool item 0001', price: 10.99, quantity: 2 }));
            this.model.details.add(new OrderDetail({ id: 2, itemCode: 'I-0002', itemDescription: 'Very cool item 0002', price: 78.12, quantity: 21 }));
            this.model.details.add(new OrderDetail({ id: 3, itemCode: 'I-0003', itemDescription: 'Very cool item 0003', price: 8.45, quantity: 3 }));
            this.model.details.add(new OrderDetail({ id: 4, itemCode: 'I-0004', itemDescription: 'Very cool item 0004', price: 1.99, quantity: 8 }));
            this.model.details.add(new OrderDetail({ id: 5, itemCode: 'I-0005', itemDescription: 'Very cool item 0005', price: 9.50, quantity: 14 }));

        },

        postRender: function () {

            this.addChildren([
                {
                    viewClass: FinderWidget,
                    parentElement: this.customerCodeElement,
                    options: {
                        id: 'customerCodeFinder',
                        label: 'Customer Code',
                        model: this.model,
                        modelProperty: 'customerCode'
                    }
                },
                {
                    viewClass: FinderWidget,
                    parentElement: this.shipToCodeElement,
                    options: {
                        id: 'shipToCodeFinder',
                        label: 'Ship To Code',
                        model: this.model,
                        modelProperty: 'shipToCode'
                    }
                },
                {
                    viewClass: OrderDetailView,
                    parentElement: this.orderDetailViewElement,
                    options: {
                        model: this.model
                    }
                }

            ]);

            this.stickit();
        }
    });
});