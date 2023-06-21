const { wallet } = require('../models');
const log = require('../utils/log.js');

const createWallet = async (direction, numberCard, idPerson) => {
    try {
        let newWallet = await wallet.create({direction, numberCard, idPerson});
        wallet.sync();
        return newWallet;
    }
    catch(err) {
        log.debug(`Failed to create wallet: ${err.message}`);
        throw new Error(err.message);
    }
}

const getWalletById = async (idWallet) => {
    try {
        let wallets = await wallet.findOne({
            where: {
                idWallet
            }
        });
        return wallets;
    }
    catch(err) {
        log.debug(`Failed to get wallets: ${err.message}`);
        throw new Error(err.message);
    }
};

const getWalletsByUser = async (idPerson) => {
    try {
        let wallets = await wallet.findAll({
            where: {
                idPerson
            }
        });
        return wallets;
    }
    catch(err) {
        log.debug(`Failed to get wallets: ${err.message}`);
        throw new Error(err.message);
    }
};

const walletExistsByNumberCard = async (numberCard) => {
    try {
        let walletNumber = await wallet.findOne({
            where: {
                numberCard
            }
        });
    
        return walletNumber;
    }
    catch(err) {
        log.debug(`Failed to get Wallet: ${err.message}`);
        throw new Error(err.message);
    }
};


const deleteWallet = async (idWallet) => {
    return await wallet.destroy({ where: { idWallet } });
};


const updateWallets = async (idWallet, wallets) => {
    const updateWallet = await wallet.update(wallets, { where: { idWallet } });
    return updateWallet;

}
module.exports = {
    createWallet,
    getWalletById,
    deleteWallet,
    walletExistsByNumberCard,
    getWalletsByUser,
    updateWallets


}
