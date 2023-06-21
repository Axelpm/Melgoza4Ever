const { shopping } = require('../models');
const log = require('../utils/log.js');

const createShopping = async (state, idPerson, idProduct) => {
    try {
        let newShopping = await shopping.create({ state, idPerson, idProduct });
        shopping.sync();
        return newShopping;
    } catch(err) {
        log.debug(`Failed to create shopping: ${err.message}`);
        throw new Error(err.message);
    }
}


const getShoppingsByPerson = async (idPerson) => {
    try {
      const shoppings = await shopping.findAll({
        where: {
          idPerson: idPerson,
        },
      });
      return shoppings;
    } catch (err) {
      log.debug(`Failed to get shoppings: ${err.message}`);
      throw new Error(err.message);
    }
  };
  

  const deleteShoppingById = async (idShopping) => {
    try {
      const deletedShopping = await shopping.destroy({ where: { idShopping } });
      return deletedShopping;
    } catch (err) {
      log.debug(`Failed to delete shopping: ${err.message}`);
      throw new Error(err.message);
    }
  };

  const deleteAllByPersonId = async (idPerson) => {
    try {
      await shopping.destroy({
        where: {
          idPerson: idPerson,
        },
      });
    } catch (err) {
      throw new Error(`Failed to delete shoppings: ${err.message}`);
    }
  };

  module.exports = {
    createShopping,
    getShoppingsByPerson,
    deleteShoppingById,
    deleteAllByPersonId
  };
  
