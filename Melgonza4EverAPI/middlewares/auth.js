const jwt = require('jsonwebtoken');

const validateToken = async (req, res, next) => {
    try {
        let accessToken = req.headers['authorization'] || req.headers['x-access-token']; 
        if(!accessToken) {
            res.json({ message: "Access denied, token?" });
        }
        if(accessToken.startsWith('Bearer ')) {
            accessToken = accessToken.slice(7, accessToken.lenght);
        }

        jwt.verify(accessToken, process.env.SECRET_KEY, (err, userId) => {
            if(err) {
                res.json({ message: "Access denied, token expired or incorrect" });
            }
            else {
                next();
            }
        })
    } 
    catch(error) {
        res.status(418).json({ message: "Quack" });
    }
}

module.exports = {
    validateToken
}
