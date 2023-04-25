const { Person } = require('../models');
class PersonDao {
 static async createPerson(person) {
 return await Person.create(person);
 }
 static async findPersonById(id) {
    return await Person.findByPk(id);
 }
 static async findPersonByEmail(email) {
 return await Person.findOne({ where: { email } });
 }
 static async updatePersonById(id, person) {
 const [rows, [updatedPerson]] = await Person.update(person, { where: { id },
returning: true });
 return updatedPerson;
 }
 static async deletePersonById(id) {
 return await Person.destroy({ where: { id } });
 }
}
module.exports = PersonDao;