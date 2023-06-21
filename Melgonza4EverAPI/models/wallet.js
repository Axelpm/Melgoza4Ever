const { DataTypes } = require('sequelize');
const person = require('./wallet');


module.exports = (sequelize) => {
    let fields = {
        idWallet: {
            type: DataTypes.INTEGER,
            primaryKey: true,
            autoIncrement: true
        },

        direction: {
            type: DataTypes.STRING,
            allowNull: false,
            validate: {
                len: [1, 50]
            }
        },

        numberCard: {
            type: DataTypes.STRING(500),
            allowNull: false,
        },
        idPerson: {  //llave foranea de user
            type: DataTypes.INTEGER,
            allowNull: false
        },




    };

    let options = {
        freezeTableName: true,
        timestamps: false,
        createdAt: false,
        updatedAt: false,
    };

    
        
    let model = sequelize.define('wallet', fields, options);

    return model;
};