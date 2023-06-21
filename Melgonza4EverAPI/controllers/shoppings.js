const shoppingDao = require('../dataaccess/shopping-dao.js');
const productDao = require('../dataaccess/product-dao.js');
const personDao = require('../dataaccess/person-dao.js');
const log = require('../utils/log.js');
const validations = require('../utils/validations.js');

const createShoppingCar = async (req, res) => {
    const { state, idPerson, idProduct } = req.body;
    try {
        const person = await personDao.getPersonById(idPerson);
        const product = await productDao.getProductById(idProduct);

        const newShopping = await shoppingDao.createShopping(state, person.idPerson, product.idProduct);

        res.status(201).json({ message: 'ShoppingCar created' });
    } catch (err) {
        log.debug(`Failed to create Wallet: ${err.message}`);
        res.status(500).json({ message: err.message });
    }
};

const getAllShoppingsByPerson = async (req, res) => {
    const idPerson = req.params.idPerson;
    try {
      const shoppings = await shoppingDao.getShoppingsByPerson(idPerson);
      res.status(200).json(shoppings);
    } catch (err) {
      log.debug(`Failed to get shoppings: ${err.message}`);
      res.status(500).json({ message: err.message });
    }
  };

  const deleteShopping = async (req, res) => {
    const { idShopping } = req.params;
    try {
      const deletedShopping = await shoppingDao.deleteShoppingById(idShopping);
      res.status(200).json({ message: 'Shopping deleted' });
    } catch (err) {
      log.debug(`Failed to delete shopping: ${err.message}`);
      res.status(500).json({ message: err.message });
    }
  };

  const deleteAllShoppingsByPersonId = async (req, res) => {
    const idPerson = req.params.idPerson;
  
    try {
      // Eliminar los registros de shopping por el ID de la persona
      await shoppingDao.deleteAllByPersonId(idPerson);
  
      res.status(200).json({ message: 'All shoppings deleted' });
    } catch (err) {
      log.debug(`Failed to delete shoppings: ${err.message}`);
      res.status(500).json({ message: err.message });
    }
  };

module.exports = {
    createShoppingCar,
    getAllShoppingsByPerson,
    deleteShopping,
    deleteAllShoppingsByPersonId

}
