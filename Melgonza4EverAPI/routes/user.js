const { Router } = require('express')
const userController = require('../controllers/user.js');

const router = Router();
router.post('/user', userController.createUser);
router.post('/login', userController.userLogin);
router.get('/getUser/:username', userController.getUser);

module.exports = router;
