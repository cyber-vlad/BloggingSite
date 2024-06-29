//////////////// VARIABILES /////////////////////////////////////////////////////////
const credential = document.getElementById('Credential');
const password = document.getElementById('Password');

//////////////// WRONG INPUT ////////////////////////////////////////////////////////
var errorCredential = document.getElementById('error-credential-login');
var errorPassword = document.getElementById('error-password-login');

//////////////// FORM ///////////////////////////////////////////////////////////////
var login = document.getElementById('login');

//////////////// FORM CHECKS /////////////////////////////////////////////////////////
login.addEventListener('submit', (e) => {
    let messageCredential = []
    let messagePassword = []

    ///////////// CREDENTIAL /////////////////////////////
    if (credential.value.length <= 4) {
        messageCredential.push('Username MINIM 5 characters');
    }
    if (credential.value.length > 30) {
        messageCredential.push('Username MAXIM 30 characters');
    }

    ///////////// PASSWORD /////////////////////////////
    if (password.value.length <= 7) {
        messagePassword.push('Password MINIM 8 characters');
    }
    if (password.value.length > 50) {
        messagePassword.push('Password MAXIM 50 characters');
    }

    //////////// MESSAGE ON SCREEN/////////////////////
    if (messageCredential.length > 0){
        e.preventDefault();
        errorCredential.innerText = messageCredential.join(', ');
    }
    if (messagePassword.length > 0) {
        e.preventDefault();
        errorPassword.innerText = messagePassword.join(', ');
    }
});