define(
    [
        '/Scripts/App/Domain/OrderDetail.js',
        'backbone'
    ],
    function (OrderDetail, Backbone) {
        'use strict';

        return Backbone.Collection.extend({
            model: OrderDetail
        });
    }
);