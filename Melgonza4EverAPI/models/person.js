const { DataTypes } = require('sequelize');

module.exports = (sequelize) => {
    let fields = {
        idPerson: {
            type: DataTypes.INTEGER,
            primaryKey: true,
            autoIncrement: true
        },

        name: {
            type: DataTypes.STRING,
            allowNull: false,
            validate: {
                len: [1, 50]
            }
        },
        
        paternalSurname: {
            type: DataTypes.STRING,
            allowNull: false,
            validate: {
                len: [1, 50]
            }
        },
        
        maternalSurname: {
            type: DataTypes.STRING,
            allowNull: false,
            validate: {
                len: [1, 50]
            }
        },
        
        username: {
            type: DataTypes.STRING,
            allowNull: false,
            unique: true,
            validate: {
                len: [1, 20]
            }
        },
        
        password: {
            type: DataTypes.STRING,
            allowNull: false,
            validate: {
                len: [64, 64]
            }
        },

        role: {
            type: DataTypes.INTEGER,
            allowNull: false,
            validate: {
                min: 1,
                max: 2
            }
        }


    };

    let options = {
        timestamps: false,
        createdAt: false,
        updatedAt: false,
    };
        
    let model = sequelize.define('person', fields, options);

    return model;
};