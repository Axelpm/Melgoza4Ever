const { DataTypes } = require('sequelize');

module.exports = (sequelize) => {
    let fields = {
        idShopping: {
            type: DataTypes.INTEGER,
            primaryKey: true,
            autoIncrement: true
        },
        state: {
            type: DataTypes.BOOLEAN,
            allowNull: false,
        },
        idPerson: {
            type: DataTypes.INTEGER,
            allowNull: false
        },
        idProduct: {
            type: DataTypes.INTEGER,
            allowNull: false
        }
    };

    let options = {
        freezeTableName: true,
        timestamps: false,
        createdAt: false,
        updatedAt: false,
    };

    const Shopping = sequelize.define('Shopping', fields, options);

    return Shopping;
};
