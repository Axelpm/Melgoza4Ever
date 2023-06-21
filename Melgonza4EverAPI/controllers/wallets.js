const walletDao = require('../dataaccess/wallet-dao.js');
const personDao = require('../dataaccess/person-dao.js');
const log = require('../utils/log.js');
const validations = require('../utils/validations.js');

const createWallet = async (req, res) => {
  const {direction, numberCard, idPerson } = req.body;

  if(!validations.validateText(direction, 100)) {
      res.status(400).json({ message: 'Invalid direccion: must be between 1 and 100 characters' });
      return;
  }


  else if(!validations.validateTextNumeric(numberCard, 28, 16, false)) {
      res.status(400).json({ message: 'Invalid number card: must be between 16 and 28 characters and not contain spaces' });
      return;
  }

  try {
    
    const persons = await personDao.getPersonById(idPerson);
    
      if (!persons) {
        return res.status(404).json({ error: 'La persona no existe' });
      }else if(!await walletDao.walletExistsByNumberCard(numberCard)){
      walletDao.createWallet( direction, numberCard, idPerson);
      res.status(201).json({ message: 'Wallet created' });
      }else{
        res.status(201).json({ message: 'Ya existe Wallet' });
      }
            
}

catch(err) {
  log.debug(`Failed to create Wallet: ${err.message}`);
}
};

const deleteWallet = async (req, res = response) => {
    const {idWallet} = req.params;
    try {
      const product = await walletDao.getWalletById(idWallet);
  
      if (!product) {
        return res.status(404).json({ error: 'Wallet no encontrado' });
      }

       await walletDao.deleteWallet(idWallet);
  
      return res.status(200).json({ message: `Se ha eliminado ${idWallet}` });
    } catch (error) {
      console.error(error);
      return res.status(500).json({ message: `Error al eliminar ${idWallet}`, error });
    }
  };

  const getWallet = async (req, res) => {
    const { idWallet } = req.body;
    try{
        const wallet = await walletDao.getWalletById(idWallet);
        res.status(200).json(wallet);
    }catch (err){
        log.debug(`Failed to get wallet: ${err.message}`);
        res.status(500).json({ message: err.message });
    }
};

const getWalletByPerson = async (req, res) => {
  const { idPerson } = req.params;
  try{
      const wallet = await walletDao.getWalletsByUser(idPerson);
      res.status(200).json(wallet);
  }catch (err){
      log.debug(`Failed to get wallet: ${err.message}`);
      res.status(500).json({ message: err.message });
  }
};

const updateWallet = async (req, res = response) => {
  const { idWallet } = req.params;
  const { numberCard, direction } = req.body; // Datos a actualizar

  try {
    // Buscar el wallet por ID
    const walletFind = await walletDao.getWalletById(idWallet);

    if (!walletFind) {
      return res.status(404).json({ error: 'Wallet no encontrado' });
    }
    const wallets = { numberCard, direction }
    // Actualizar el producto con los datos proporcionados
    const updateWalletPut = await walletDao.updateWallets(idWallet, wallets);

    res.status(200).json({ message: 'Billetera Actualizado con exito' });
  } catch (error) {
    console.error(error);
    return res.status(500).json({ error: 'Error al actualizar el producto' });
  }
};

module.exports = {
    createWallet,
    deleteWallet,
    getWallet,
    getWalletByPerson,
    updateWallet
}
