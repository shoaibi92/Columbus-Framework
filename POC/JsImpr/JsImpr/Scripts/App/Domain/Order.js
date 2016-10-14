define(
    [
        'backbone',
        '/Scripts/App/Domain/OrderDetails.js'
    ],
    function (Backbone, OrderDetails) {
        'use strict';

        return Backbone.Model.extend({
            defaults: {
                customerCode: '',
                customerName: '',

                shipToCode: '',
                orderTotal: 0,
                isDirty: false
            },

            initialize: function () {

                this.updateTotals();
                this.on('change:customerCode', this.updateTotals, this);
                this.on('change', this.onPropertyChanged, this);

                _.defaults(this, {
                    details: new OrderDetails
                });

                this.details.on('change', this.onPropertyChanged, this);
            },

            updateTotals: function () {
                this.set({
                    orderTotal: parseInt(this.get('customerCode'), 10)
                });
            },

            onPropertyChanged: function() {
                if (!this.hasChanged('isDirty'))
                    this.set('isDirty', true);
            }
        });
    }
);