const PersonDao = require('../dao/PersonDao');
async function createPerson(req, res) {
 const { name, lastname,email, username, role,password } = req.body;
 const person = {name, lastname,email, username, role,password };
 try {
 const newPerson = await PersonDao.createPerson(person);
 res.status(201).json(newPerson);
 } catch (error) {
 console.error(error);
 res.status(500).json({ message: 'Error creating person' });
 }
}
async function getPersonById(req, res) {
    const { id } = req.params;
    try {
    const person = await PersonDao.findPersonById(id);
    res.json(person);
    } catch (error) {
    console.error(error);
    res.status(500).json({ message: 'Error retrieving person' });
    }
   }
   async function updatePersonById(req, res) {
    const { id } = req.params;
    const { name, email, password } = req.body;
    const person = { name, lastname,email, username, role,password };
    try {
    const updatedPerson = await PersonDao.updatePersonById(id, person);
    res.json(updatedPerson);
    } catch (error) {
    console.error(error);
    res.status(500).json({ message: 'Error updating person' });
    }
   }
   async function deletePersonById(req, res) {
    const { id } = req.params;
    try {
    await PersonDao.deletePersonById(id);
    res.sendStatus(204);
    } catch (error) {
    console.error(error);
    res.status(500).json({ message: 'Error deleting person' });
    }
   }
   module.exports = {
    createPerson,
    getPersonById,
    updatePersonById,
    deletePersonById,
   };