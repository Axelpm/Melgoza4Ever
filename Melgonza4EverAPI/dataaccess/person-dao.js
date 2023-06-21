const { person } = require('../models');
const log = require('../utils/log.js');

const createUser = async (name, paternalSurname, maternalSurname, username, password, role) => {
    try {
        let newPerson = await person.create({ name, paternalSurname, maternalSurname, username, password, role});
        person.sync();
        return newPerson;
    }
    catch(err) {
        log.debug(`Failed to create user: ${err.message}`);
        throw new Error(err.message);
    }
}

const getPersonByUsername = async (username) => {
    try {
      let user = await person.findOne({
        where: {
          username
        }
      });
  
      return user;
    } catch (err) {
      log.debug(`Failed to get user: ${err.message}`);
      throw new Error(err.message);
    }
  };
  

const personExistsByUsername = async (username) => {
    try {
        let user = await person.findOne({
            where: {
                username
            }
        });
    
        return user !== null;
    }
    catch(err) {
        log.debug(`Failed to get user: ${err.message}`);
        throw new Error(err.message);
    }
};
const getPersonById = async (idPerson) => {
    try {
        let persons = await person.findOne({
            where: {
                idPerson
            }
        });
        return persons;
    }
    catch(err) {
        log.debug(`Failed to get person: ${err.message}`);
        throw new Error(err.message);
    }
};
module.exports = {
    createUser,
    getPersonByUsername,
    personExistsByUsername,
    getPersonById
}
