define(
    [
        'backbone'
    ],
    function (Backbone) {
        'use strict';

        return Backbone.Model.extend({
            defaults: {
                id: -1,
                itemCode: '',
                itemDescription: '',
                price: 0,
                quantity: 0
            },

            initialize: function () {

                this.on('change', function () { console.log('Order Daetail changed');}, this);

            },
        });
    }
);