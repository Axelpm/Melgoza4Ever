const { Product } = require('../models');
class ProductDao {
 static async createProduct(product) {
 return await Product.create(product);
 }
 static async findProductById(id) {
    return await Product.findByPk(id);
 }
 static async updateProductById(id, product) {
 const [rows, [updatedProduct]] = await Product.update(product, { where: { id },
returning: true });
 return updatedProduct;
 }
 static async deleteProductById(id) {
 return await Product.destroy({ where: { id } });
 }
}
module.exports = ProductDao;