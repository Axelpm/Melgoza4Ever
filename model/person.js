'use strict';
const { Model } = require('sequelize');
module.exports = (sequelize, DataTypes) => {
 class Person extends Model {
 static associate(models) {
 // define association here
 }
 };
 Person.init({
 name: DataTypes.STRING,
 lastname: DataTypes.STRING,
 email: DataTypes.STRING,
 username: DataTypes.STRING,
 role: DataTypes.STRING,
 password: DataTypes.STRING
 }, {
 sequelize,
 modelName: 'Person',
 });
 return Person;
};