const personDao = require('../dataaccess/person-dao.js');
const log = require('../utils/log.js');
const { autheticateUser, hash, generateToken } = require('../utils/auth.js');
const validations = require('../utils/validations.js');

const createUser = async (req, res) => {
    const { name, paternalSurname, maternalSurname, username, password,role } = req.body;

    if(!validations.validateTextAlpha(name, 50)) {
        res.status(400).json({ message: 'Invalid name: must be between 1 and 50 characters' });
        return;
    }
    else if(!validations.validateTextAlpha(paternalSurname, 50)) {
        res.status(400).json({ message: 'Invalid paternal surname: must be between 1 and 50 characters' });
        return;
    }
    else if(!validations.validateTextAlpha(maternalSurname, 50)) {
        res.status(400).json({ message: 'Invalid maternal surname: must be between 1 and 50 characters' });
        return;
    }
    else if(!validations.validateTextAlphaNumeric(username, 20, 5, false)) {
        res.status(400).json({ message: 'Invalid username: must be between 5 and 20 characters and not contain spaces' });
        return;
    }
    else if(!validations.validateText(password, 50, 6, false) || !validations.checkPasswordStrength(password)) {
        res.status(400).json({ message: 'Invalid password: must be between 6 and 50 characters, and must contain at least one number, one lowercase letter, one uppercase letter, and one special character. No spaces allowed.' });
        return;
    }

    try {
        if(!await personDao.personExistsByUsername(username)) {
            let passwordHash = await hash(password);
            await personDao.createUser(name, paternalSurname, maternalSurname, username, passwordHash, role);
            res.status(201).json({ message: 'User created' });
        }
        else {
            res.status(400).json({ message: 'User already exists' });
        }
    }
    catch(err) {
        log.debug(`Failed to create user: ${err.message}`);
        res.status(500).json({ message: err.message });
    }
};

const userLogin = async (req, res) => {
    const { username, password } = req.body;
    try {
      const user = await personDao.getPersonByUsername(username);
      if (user !== null) {
        const authenticated = await autheticateUser(user.username, password); // Autenticar la contraseña
        if (authenticated) {
          const role = user.role; // Obtener el rol de la persona
          res.status(200).json({ username, role }); // Devolver el nombre de usuario y el rol en la respuesta
        } else {
          res.status(401).json({ message: 'Invalid password' }); // Contraseña inválida
        }
      } else {
        res.status(404).json({ message: 'User does not exist' }); // Usuario no existe
      }
    } catch (err) {
      log.debug(`Failed to login user: ${err.message}`);
      res.status(500).json({ message: err.message });
    }
  };
  

const getUser = async (req, res) => {
    const { username } = req.params;
    try{
        const user = await personDao.getPersonByUsername(username);
        res.status(200).json(user);
    }catch (err){
        log.debug(`Failed to get person: ${err.message}`);
        res.status(500).json({ message: err.message });
    }
};

module.exports = {
    createUser,
    userLogin,
    getUser
}
