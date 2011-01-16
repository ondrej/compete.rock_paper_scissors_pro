var express = require('express');
var url = require('url');

var app = express.createServer();

app.get('/', function(request, response) {
	var params = url.parse(request.url, true);

	console.log('Processing round %s...', params.query['round']);
	for (var key in params.query) {
		console.log('\t%s\t\t\t: %s', key, params.query[key]);
	}

	response.send(process.argv[2]);
});

app.listen(process.argv[3]);

var addy = app.address();
console.log('Express server started on %s:%s...', addy.address, addy.port);
