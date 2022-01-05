
	const net = require('net');
	
	const connectedClients = [];
	const server = net.createServer((s) => {
	
			s.on('data', (data) => {
			  console.log(data.toString());
			  s.write(data);
			});
	});
	
	server.listen({
	//	host: '192.168.24.103', //'127.0.0.1',
		port: 8080,
	});
	server.on('connection', (client) => {
		console.log('client connected, IP' + client.remoteAddress);
		client.write('Welcome to the server. You IP\n' + client.remoteAddress + '\n');
		connectedClients.push(client);
	});
// Обработка ошибок
	process.on('uncaughtException', (err) => {
	    console.error('Какая-то ошибка. Работаем дальше...', err);
	  //  process.exit(1); //mandatory (as per the Node docs)
	})

	//------------------
/*	setInterval(() => {
		const now = new Date().toISOString();
		connectedClients.forEach(client => {
			client.write(now + '\n');
		});
	}, 2000);
	*/