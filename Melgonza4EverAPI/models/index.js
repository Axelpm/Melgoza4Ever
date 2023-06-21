const { Sequelize } = require('sequelize');
const SQLite = require('sqlite3');

let sequelize = new Sequelize('melgoza4ever', process.env.DB_USER, process.env.DB_PASS, {
    dialect: 'sqlite',
    storage: 'data/db.sqlite',
    dialectOptions: {
        mode: SQLite.OPEN_READWRITE | SQLite.OPEN_CREATE
    },
    logging: false
});

const person = require('./person.js')(sequelize);
const product = require('./product.js')(sequelize);
const wallet = require('./wallet.js')(sequelize);
const shopping = require('./shopping.js')(sequelize);

wallet.belongsTo(person,{foreignKey : "idPerson"});
person.hasMany(wallet,{foreignKey : "idPerson"});

shopping.belongsTo(person,{foreignKey : "idPerson"});
person.hasOne(shopping,{foreignKey : "idPerson"})

shopping.belongsTo(product,{foreignKey : "idProduct"});
product.hasMany(shopping,{foreignKey: "idProduct"})
 
module.exports = { 
    sequelize,
    person,
    product,
    wallet,
    shopping

};
