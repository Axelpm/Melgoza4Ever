
const validateText = (text, maxLength, minLength = 1, spacesAllowed = true) => {
    if(text.length < minLength || text.length > maxLength) {
        return false;
    }
    if(!spacesAllowed) {
        if(text.includes(' ')) {
            return false;
        }
    }
    return true;
}; 


const validateTextWithSpace = (text, maxLength, minLength = 1, spacesAllowed = true) => {
    if(text.length < minLength || text.length > maxLength) {
        return false;
    }
    return true;
}; 

const validateTextAlphaNumeric = (text, maxLength, minLength = 1, spacesAllowed = true) => {
    if(!validateText(text, maxLength, minLength, spacesAllowed)) {
        return false;
    }
    if(!text.match(/^[a-zA-Z0-9]+$/)) {
        return false;
    }
    return true;
};

const validateTextAlpha = (text, maxLength, minLength = 1, spacesAllowed = true) => {
    if(!validateText(text, maxLength, minLength, spacesAllowed)) {
        return false;
    }
    if(!text.match(/^[a-zA-Z]+$/)) {
        return false;
    }
    return true;
};

const validateTextNumeric = (text, maxLength, minLength = 1, spacesAllowed = true) => {
    if(!validateText(text, maxLength, minLength, spacesAllowed)) {
        return false;
    }
    if(!text.match(/^[0-9]+$/)) {
        return false;
    }
    return true;
}

const validateEmail = (email) => {
    if(!email.match(/^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$/)) {
        return false;
    }
    return true;
}

const checkPasswordStrength = (password) => {
    if(!password.match(/^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_+.])/)) {
        return false;
    }
    return true;
}

module.exports = {
    validateText,
    validateTextAlphaNumeric,
    validateTextAlpha,
    validateTextNumeric,
    validateEmail,
    checkPasswordStrength,
    validateTextWithSpace
}
