/*jshint unused:false */

var require = {
	'deps': ['/Scripts/App/main.js'],

	'paths': {
        //'jquery':					'Scripts/Vendor/jquery.min',
	    'jquery':                   'Scripts/Vendor/jquery-1.11.1',
	    //'jqueryui':				'Scripts/Vendor/jquery-ui.min',
	    'jqueryui':                 'Scripts/Vendor/jquery-ui-1.10.3',

	    'jqueryui-touch':           'Scripts/Vendor/jquery-ui-touch.min',
	    'underscore':               'Scripts/Vendor/lodash.underscore.min',
	    'backbone':                 'Scripts/Vendor/backbone',
	    'stickit':                  'Scripts/Vendor/backbone.stickit-0.6.3',
	    'handlebars':               'Scripts/Vendor/handlebars-v1.1.2',
	    'd3':                       'Scripts/Vendor/d3.v3.min',
	    'd3tip':                    'Scripts/Vendor/d3.tip',
	    'bootstrap':                'Scripts/Vendor/bootstrap.min',
	    'bootstrapdatepicker':      'Scripts/Vendor/bootstrap-datepicker',
	    'datatables':               'Scripts/Vendor/jquery.datatables.min',
	    'datatablesbootstrap':      'Scripts/Vendor/datatables-bootstrap',
	    'datatables-colreorder':    'Scripts/Vendor/datatables-colreorder.min',
	    'kendo':                    'Scripts/Vendor/kendo/kendo.all.min',
	    'kendobbds':                'Scripts/Vendor/kendo.backbone.datasource',
	    'text':                     'Scripts/Vendor/text',

		// Keel
	    'BaseView':                 'Scripts/App/Framework/Keel/BaseView',
	    'ExceptionUtil':            'Scripts/App/Framework/Keel/ExceptionUtil',
	    'Message':                  'Scripts/App/Framework/Keel/Message',
	    'MessageBus':               'Scripts/App/Framework/Keel/MessageBus',
	    'Router':                   'Scripts/App/Framework/Keel/Router'
	},

	'shim': {
		'jqueryui': {
			'deps': ['jquery']
		},

		'jqueryui-touch': {
			'deps': ['jqueryui']
		},

		'backbone': {
			'deps': ['underscore'],
			'exports': 'Backbone'
		},

		'underscore': {
			'exports': '_'
		},

		'stickit': {
		    'deps': ['backbone']
		},

		'handlebars': {
			'exports': 'Handlebars'
		},

		'd3': {
			'exports': 'd3'
		},

		'd3tip': {
			'deps': ['d3'],
			'exports': 'd3.tip'
		},

		'bootstrapdatepicker': {
			'deps': ['bootstrap']
		},

		'datatables': {
			'deps': ['jquery']
		},

		'datatablesbootstrap': {
			'deps': ['jquery', 'bootstrap', 'datatables']
		},

		'datatables-colreorder': {
			'deps': ['jquery', 'datatables']
		},

		'kendo': {
            'deps': ['jquery']
		},

		'kendobbds': {
            'deps': ['jquery', 'kendo', 'underscore']
		}
	}
};