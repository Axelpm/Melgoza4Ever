const { Router } = require('express')
const walletController = require('../controllers/wallets.js');

const router = Router();
router.post('/wallet', walletController.createWallet);
router.delete('/deleteWallet/:idWallet', walletController.deleteWallet);
router.get('/getWallet', walletController.getWallet);
router.get('/getWalletByUser/:idPerson', walletController.getWalletByPerson);
router.put('/updateWallet/:idWallet', walletController.updateWallet);


module.exports = router;
