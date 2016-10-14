define(
[
	'/Scripts/App/Framework/AppConfig.js',
	'underscore'
],
function(AppConfig, _) {
	'use strict';

	var authCookieName = 'SagePocAuth';

	return {

		login: function(password) {
			if (password === AppConfig.systemPassword) {
				this.createCookie(authCookieName, 1, 1);
				return true;
			}

			return false;
		},

		checkLoginCookie: function() {
			var cookie = this.readCookie(authCookieName);

            return (cookie === null ? false : true);
		},

		removeLoginCookie: function() {
			this.createCookie(authCookieName, '', -1);
		},

		createCookie: function(name, value, days) {
			var expires;

			if (days) {
				var date = new Date();
				date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
				expires = '; expires=' + date.toGMTString();
			} else {
				expires = '';
			}

			document.cookie = _.escape(name) + '=' + _.escape(value) + expires + '; path=/';
		},

		readCookie: function(name) {
			var nameEQ = _.escape(name) + '=';
			var ca = document.cookie.split(';');
			for (var i = 0; i < ca.length; i++) {
				var c = ca[i];
				while (c.charAt(0) === ' ') {
					c = c.substring(1, c.length);
				}

				if (c.indexOf(nameEQ) === 0) {
					return _.unescape(c.substring(nameEQ.length, c.length));
				}
			}
			return null;
		},
	};
});





