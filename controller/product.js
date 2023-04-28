const ProductDao = require('../dao/ProductDao');
async function createProduct(req, res) {
 const { name, price,category, description, availability,size } = req.body;
 const product = {name, price,category, description, availability,size };
 try {
 const newProduct = await ProductDao.createProduct(product);
 res.status(201).json(newProduct);
 } catch (error) {
 console.error(error);
 res.status(500).json({ message: 'Error creating product' });
 }
}
async function getProductById(req, res) {
    const { id } = req.params;
    try {
    const product = await ProductDao.findProductById(id);
    res.json(product);
    } catch (error) {
    console.error(error);
    res.status(500).json({ message: 'Error retrieving product' });
    }
   }
   async function updateProductById(req, res) {
    const { id } = req.params;
    const { name, price,category, description, availability,size } = req.body;
    const product = { name, price,category, description, availability,size };
    try {
    const updatedProduct = await ProductDao.updateProductById(id, product);
    res.json(updatedProduct);
    } catch (error) {
    console.error(error);
    res.status(500).json({ message: 'Error updating product' });
    }
   }
   async function deleteProductById(req, res) {
    const { id } = req.params;
    try {
    await ProductDao.deleteProdctById(id);
    res.sendStatus(204);
    } catch (error) {
    console.error(error);
    res.status(500).json({ message: 'Error deleting product' });
    }
   }
   module.exports = {
    createProduct,
    getProductById,
    updateProductById,
    deleteProductById,
   };