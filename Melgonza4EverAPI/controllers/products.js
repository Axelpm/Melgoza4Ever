const { response } = require('express');
const productDao = require('../dataaccess/product-dao.js');
const product = require('../models/product.js');
const log = require('../utils/log.js');
const validations = require('../utils/validations.js');

const createProduct = async (req, res) => {
    const { name, category, price, description, available, size, productPhoto} = req.body;

    if(!validations.validateTextAlpha(name, 30)) {
        res.status(400).json({ message: 'Invalid name: must be between 1 and 20 characters' });
        return;
    }
    else if(!validations.validateTextAlpha(category, 25)) {
        res.status(400).json({ message: 'Invalid category:' });
        return;
    }
    else if(!validations.validateTextNumeric(price, 40)) {
        res.status(400).json({ message: 'Invalid price:' });
        return;
    }
    else if(!validations.validateTextWithSpace(description, 80, false)) {
        res.status(400).json({ message: 'Invalid Description:' });
        return;
    }
    else if(!validations.validateTextNumeric(available, 30)) {
        res.status(400).json({ message: 'Invalid available:' });
        return;
    }
    else if(!validations.validateTextNumeric(size, 30)) {
        res.status(400).json({ message: 'Invalid Size: ' });
        return;
    }

    try {
        if(!await productDao.productExistsByName(name)) {
            await productDao.createProduct(name, category,price,description,available, size, productPhoto);
            res.status(201).json({ message: 'Product created' });
        }
        else {
            res.status(400).json({ message: 'Product already exists' });
        }
    }
    catch(err) {
        log.debug(`Failed to create product: ${err.message}`);
        res.status(500).json({ message: err.message });
    }
};

const getProduct = async (req, res) => {
  const { idProduct } = req.params;
  try {
    const product = await productDao.getProductById(idProduct);
    res.status(200).json(product);
  } catch (err) {
    log.debug(`Failed to get product: ${err.message}`);
    res.status(500).json({ message: err.message });
  }
};

const getAllProducts = async (req, res = response ) =>{
  try{
      const products= await productDao.findAllProducts();
      res.status(200).json(products);
  }catch (error){
      console.error(error);
      res.status(500).json({message:error});
  }
};

const deleteProduct = async (req, res = response) => {
    const { idProduct} = req.params;
    try {
      const product = await productDao.getProductById(idProduct);
  
      if (!product) {
        return res.status(404).json({ error: 'Producto no encontrado' });
      }

       await productDao.deleteProduct(idProduct);
  
      return res.status(200).json({ message: `Se ha eliminado ${idProduct}` });
    } catch (error) {
      console.error(error);
      return res.status(500).json({ message: `Error al eliminar ${idProduct}`, error });
    }
  };




  const updateProduct = async (req, res = response) => {
    const { idProduct } = req.params;
    const { name, category, price, description, available, size, productPhoto } = req.body; // Datos a actualizar
  
    try {
      // Buscar el producto por ID
      const productFind = await productDao.getProductById(idProduct);
  
      if (!productFind) {
        return res.status(404).json({ error: 'Producto no encontrado' });
      }
      const products = { name, category, price, description, available, size, productPhoto }
      // Actualizar el producto con los datos proporcionados
      const updateProductPut = await productDao.updateProduct(idProduct, products);
  
      res.status(200).json({message: 'Producto Actualizado con exito'});
    } catch (error) {
      console.error(error);
      return res.status(500).json({ error: 'Error al actualizar el producto' });
    }
  };

  const productUpdatePhotoPatch = async (req, res = response) => {
    const {name} = req.params;
    const { profilePhotoLink } = req.body;
    try {
      const updatedPhoto = await productDao.updateProductPhoto(name, profilePhotoLink);
      res.status(200).json(updatedPhoto);
    } catch (error) {
      console.error(error);
      res.status(500).json({ message: "Error al actualizar la imagen.", error });
    }
}


module.exports = {
    createProduct,
    getProduct,
    deleteProduct,
    updateProduct,
    productUpdatePhotoPatch,
    getAllProducts

}
