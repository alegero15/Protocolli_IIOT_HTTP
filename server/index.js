const express = require('express')
const bodyParser = require('body-parser')

const server = express()
server.use(bodyParser.urlencoded({ extended: true }))
server.use(express.text()) //mi serve per prendere i dati che mi manda ale 

server.get('', (req,res,next) =>{
    return res.send('stutututu!!!');
})

server.get('/cars', function (req, res, next) {
    res.send('List of cars: [TODO]');
    return next();
});

server.get('/cars/:id', function (req, res, next) {
    res.send('Current values for car ' + req.params['id'] + ': [TODO]');
    return next();
});

server.post('/cars/:id/metrics', function (req, res, next) {
    res.send('Data received from car [TODO]');

    console.log(req.body);

    return next();
});

server.listen(8011, function () {
    console.log('server listening at http://192.168.101.124:8011');
});
