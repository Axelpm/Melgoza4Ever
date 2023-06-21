const { product } = require('../models');
const log = require('../utils/log.js');

const createProduct = async (name, category, price, description, available, size, productPhoto) => {
    try {
        let newProduct = await product.create({ name, category, price, description, available, size, productPhoto });
        product.sync();
        return newProduct;
    }
    catch(err) {
        log.debug(`Failed to create product: ${err.message}`);
        throw new Error(err.message);
    }
}

const getProductByName = async (name) => {
    try {
        let products = await product.findOne({
            where: {
                name
            }
        });
        return products;
    }
    catch(err) {
        log.debug(`Failed to get product: ${err.message}`);
        throw new Error(err.message);
    }
};

const getProductById = async (idProduct) => {
    try {
        let products = await product.findOne({
            where: {
                idProduct
            }
        });
        return products;
    }
    catch(err) {
        log.debug(`Failed to get product: ${err.message}`);
        throw new Error(err.message);
    }
};

const  findAllProducts = async () => {
    return await product.findAll();
};

const productExistsByName = async (name) => {
    try {
        let productName = await product.findOne({
            where: {
                name
            }
        });
    
        return productName !== null;
    }
    catch(err) {
        log.debug(`Failed to get product: ${err.message}`);
        throw new Error(err.message);
    }
};

const deleteProduct = async (idProduct) => {
    return await product.destroy({ where: { idProduct } });
};

const updateProduct  = async (idProduct, products) => {
    const updateProduct = await product.update(products, { where: { idProduct } });
    return updateProduct;

}

const updateProductPhoto = async (name, productPhoto) => {
    const updatedPhoto = await product.update({productPhoto : productPhoto}, { where: { name } });
    return updatedPhoto;

}

module.exports = {
    createProduct,
    getProductByName,
    productExistsByName,
    getProductById,
    deleteProduct,
    updateProduct,
    updateProductPhoto,
    findAllProducts
    
}