//////////////////////// VARIABILES //////////////////////////////////////////////////
const credential = document.getElementById('Credential');
const password = document.getElementById('Password');
const conPassword = document.getElementById('Con-Password');
const email = document.getElementById('Email');
const info = document.getElementById('Info');

////////////////// GREEN ARROW ///////////////////////////////////////////////////////
var credentialAccept = document.getElementById('credential-accept-data');
var passwordAccept = document.getElementById('password-accept-data');
var conPasswordAccept = document.getElementById('con-password-accept-data');
var emailAccept = document.getElementById('email-accept-data');
var infoAccept = document.getElementById('info-accept-data');

//////////////// WRONG INPUT ////////////////////////////////////////////////////////
var errorCredential = document.getElementById('error-credential');
var errorPassword = document.getElementById('error-password');
var errorConPassword = document.getElementById('error-con-password');
var errorEmail = document.getElementById('error-email');
var errorInfoBlog = document.getElementById('error-info-blog');

/////////////////// FORM ///////////////////////////////////////////////////////////
var register = document.getElementById('register');

//////////////////// VALIDATE GREEN ARROW /////////////////////////////////////////
function validateCredential() {

    if (credential.value.length >= 5 && credential.value.length <=30) {
        credentialAccept.innerHTML = '<i class="fa-regular fa-circle-check"></i>';
        return true;
    }
    credentialAccept.innerHTML = '';
    return false;
}
function validatePassword() {
    if (password.value.length >= 8 && password.value.length <= 50) {
        passwordAccept.innerHTML = '<i class="fa-regular fa-circle-check"></i>';
        return true;
        
    }
    passwordAccept.innerHTML = '';
    return false;
}
function validateConPassword() {

    if (conPassword.value.length >= 8 && conPassword.value.length <= 50 && password.value == conPassword.value) {
       
        conPasswordAccept.innerHTML = '<i class="fa-regular fa-circle-check"></i>';
        return true;
    }
    conPasswordAccept.innerHTML = '';
    return false;
}
function validateEmail() {
    if (email.value.length <= 30 && email.value.length!=0) {
    emailAccept.innerHTML = '<i class="fa-regular fa-circle-check"></i>';
        return true;
    }
    emailAccept.innerHTML = '';
    return false;
}
function validateInfo() {
    if (info.value.length <= 150 || info.value.length == 0) {
    infoAccept.innerHTML = '<i class="fa-regular fa-circle-check"></i>';
        return true;
    }
    infoAccept.innerHTML = '';
    return false;
}
///////////////////////////////////////////////////////////////////////////////

///////////////// FORM CHECKS /////////////////////////////////////////////////
register.addEventListener('submit', (e) => {
    let messageCredential = []
    let messageEmail = []
    let messagePassword = []
    let messageConPassword = []
    let messageInfoBlog = []

    ///////////// CREDENTIAL /////////////////////////////
    if (credential.value.length <= 4) {
        messageCredential.push('Username MINIM 5 characters');
        credentialAccept.innerHTML = '';
    }
    if (credential.value.length > 30) {
        messageCredential.push('Username MAXIM 30 characters');
        credentialAccept.innerHTML = '';
    }

    ///////////// PASSWORD /////////////////////////////
    if (password.value.length <= 7) {
        messagePassword.push('Password MINIM 8 characters');
        passwordAccept.innerHTML = '';
    }
    if (password.value.length > 50) {
        messagePassword.push('Password MAXIM 50 characters');
        passwordAccept.innerHTML = '';
    }
    ///////////// CON-PASSWORD /////////////////////////
    if (conPassword.value.length <= 7) {
        messageConPassword.push('Password MINIM 8 characters');
        conPasswordAccept.innerHTML = '';
    }
    if (conPassword.value.length > 50) {
        messageConPassword.push('Password MAXIM 50 characters')
        conPasswordAccept.innerHTML = '';
    }
    if (password.value != conPassword.value) {
        messagePassword.push('Passwords are not identical')
        messageConPassword.push('Passwords are not identical');
        passwordAccept.innerHTML = '';
        conPasswordAccept.innerHTML = '';
    }
    ///////////// EMAIL ////////////////////////////////
    if (email.value.length > 30) {
        messageEmail.push('Email MAXIM 30 characters');
        emailAccept.innerHTML = '';
    }
    ///////////// INFOBLOG /////////////////////////////
    if (info.value.length > 150) {
        messageInfoBlog.push('InfoBlog MAXIM 150 characters');
        infoAccept.innerHTML = '';
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
    if (messageConPassword.length > 0) {
        e.preventDefault();
        errorConPassword.innerText = messageConPassword.join(', ');
    }
    if (messageEmail.length > 0) {
        e.preventDefault();
        errorEmail.innerText = messageEmail.join(', ');
    }
    if (messageInfoBlog.length > 0) {
        e.preventDefault();
        errorInfoBlog.innerText = messageInfoBlog.join(', ');
    }

});


