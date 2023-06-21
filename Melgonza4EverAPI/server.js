const express = require('express');
const cors = require('cors');
const swaggerUi = require('swagger-ui-express');
const swaggerDocument = require('./docs/swagger.json');
const log = require('./utils/log.js');

class Server {
    constructor() {
        this.log = log;
        this.app = express();
        this.port = process.env.PORT || 3000;
        this._initMiddlewares();
        this._initRoutes();
        this._initSwagger();
    }

    _initMiddlewares() {
        this.app.use(cors());
        this.app.use(express.json());
        this.app.use(express.static('html'));
    }

    _initRoutes() {
        this.app.use('/test', require('./routes/test.js'));
        this.app.use('/api', require('./routes/user.js'));
        this.app.use('/api', require('./routes/products.js'));
        this.app.use('/api', require('./routes/wallets.js'));
        this.app.use('/api', require('./routes/shoppings.js'));
    }

    _initSwagger() {
        this.app.use('/api-docs', swaggerUi.serve, swaggerUi.setup(swaggerDocument));
    }

    start() {
        this.app.listen(this.port, () => {
            this.log.info(`Server listening on port ${this.port}`);
        });
    }
}

module.exports = Server;
