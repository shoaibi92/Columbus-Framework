define([
    'Message',
    'MessageBus',
    'backbone'
],
function(Message, MessageBus, Backbone) {
	'use strict';

	var Router = Backbone.Router.extend({
		routes: {
			'': 'goToPage',
			':page/:objId': 'goToPage',
			':page': 'goToPage'
		},

		goToPage: function() {
			var page = 'order',
                pageName = 'Order',
                parameters = [];

            /*
			if (!AuthCookie.checkLoginCookie()) {
				this.navigate('login');

				//****************TEMP****************
				page = 'login';
				pageName = 'Login';
				//*************END TEMP***************
			} else {
				if (arguments.length > 0 && arguments[0] !== 'index.html') {
					// Convert to Camelcase
					page = arguments[0];
					parameters = Array.prototype.slice(arguments, 1);
					pageName = page[0].toUpperCase() + page.slice(1).replace(/-\w/g, function(v) { return v[1].toUpperCase(); });
				}
			}
            */

			if (arguments.length > 0 && arguments[0] !== 'index.html') {
                // Convert to Camelcase
                page = arguments[0];
                parameters = Array.prototype.slice(arguments, 1);
                pageName = page[0].toUpperCase() + page.slice(1).replace(/-\w/g, function (v) { return v[1].toUpperCase(); });
			}

			MessageBus.trigger(Message.PageBeforeChange, page);
			require(['Scripts/App/Pages/' + page + '/' + pageName + 'Page'], function(PageConstructor) {
				var pageInstance = new PageConstructor().render().place('#container');

				pageInstance.listenTo(MessageBus, Message.PageBeforeChange, function() {
					pageInstance.destroy();
				});

				MessageBus.trigger(Message.PageChange, page);
			});
		}
	});

	return Router;
});