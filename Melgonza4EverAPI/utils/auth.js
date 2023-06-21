const crypto = require('crypto');
const personDao = require('../dataaccess/person-dao.js');
const log = require('./log.js');
const jwt = require('jsonwebtoken');

const autheticateUser = async (username, password) => {
    try {
        let user = await personDao.getPersonByUsername(username);
        if(user !== null) {
            return user.password === await hash(password);
        }
        else {
            throw new Error('User does not exist');
        }
    }
    catch(err) {
        throw new Error(err.message);
    }
}

const hash = async (text) => {
    const hashString = crypto.createHash('sha256');
    hashString.update(`${text}`);
    return hashString.digest('hex');
};

const generateToken = async (username) => {
    try {
        let user = await personDao.getPersonByUsername(username);
        let userId = user.id;
        let token = jwt.sign({ userId }, process.env.TOKEN_SECRET_KEY, { expiresIn: '3h' });
        return token;
    }
    catch(err) {
        log.debug(`Failed to generate token: ${err.message}`);
        throw new Error(err.message);
    }
};

module.exports = {
    autheticateUser,
    hash,
    generateToken
};

