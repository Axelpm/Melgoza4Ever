const { Router } = require('express')
const productController = require('../controllers/products.js');

const router = Router();
router.post('/product', productController.createProduct);
router.get('/getProduct/:idProduct', productController.getProduct);
router.get('/getAllProducts', productController.getAllProducts);
router.delete('/deleteProduct/:idProduct', productController.deleteProduct);
router.put('/updateProduct/:idProduct', productController.updateProduct);
router.patch('/updatePhotoProduct/:name', productController.productUpdatePhotoPatch);



module.exports = router;
