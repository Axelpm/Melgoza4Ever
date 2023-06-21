const { Router } = require('express')
const shoppingController = require('../controllers/shoppings.js');

const router = Router();
router.post('/Shopping', shoppingController.createShoppingCar);
router.get('/person/:idPerson/shoppings', shoppingController.getAllShoppingsByPerson);
router.delete('/shopping/:idShopping', shoppingController.deleteShopping);
router.delete('/deleteAllShoppings/:idPerson', shoppingController.deleteAllShoppingsByPersonId);




module.exports = router;
