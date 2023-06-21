const { DataTypes } = require('sequelize');


module.exports = (sequelize) => {
    let fields = {
        idProduct: {
            type: DataTypes.INTEGER,
            primaryKey: true,
            autoIncrement: true
        },

        name: {
            type: DataTypes.STRING,
            allowNull: false,
            validate: {
                len: [1, 20]
            }
        },
        
        category: {
            type: DataTypes.STRING,
            allowNull: false,
            validate: {
                len: [1, 25]
            }
        },
        
        price: {
            type: DataTypes.INTEGER,
            allowNull: false,
        },
        
        description: {
            type: DataTypes.STRING,
            allowNull: false,
            validate: {
                len: [1, 80]
            }
        },
        
        available: {
            type: DataTypes.INTEGER,
            allowNull: false,
        },

        size: {
            type: DataTypes.INTEGER,
            allowNull: false,
        },
        
        productPhoto:  {
            type: DataTypes.STRING(500),
            allowNull: true,
          }


    };

    let options = {
        freezeTableName: true,
        timestamps: false,
        createdAt: false,
        updatedAt: false,
    };

    
        
    let model = sequelize.define('product', fields, options);

    return model;
};