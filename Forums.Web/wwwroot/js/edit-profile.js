//////////////// VARIABILES /////////////////////////////////////////////////////////
const phone = document.getElementById('PhoneNumber');
const username = document.getElementById('Fullname')
const email = document.getElementById('Email')
const info = document.getElementById('InfoBlog');
const profession = document.getElementById('Profession')
//////////////// WRONG INPUT ////////////////////////////////////////////////////////
var errorPhone = document.getElementById('error-phone');
var errorUsername = document.getElementById('error-username');
var errorEmail = document.getElementById('error-email');
var errorInfoBlog = document.getElementById('error-info');
var errorProfession = document.getElementById('error-profession')
/////////////////// FORM ///////////////////////////////////////////////////////////
var edit = document.getElementById('edit');

///////////////////////////////////////////////////////////////////////////////

///////////////// FORM CHECKS /////////////////////////////////////////////////
edit.addEventListener('submit', (e) => {
    let messagePhone = []
    let messageUsername = []
    let messageEmail = []
    let messageInfoBlog = []
    let messageProfession = []

    ///////////// USERNAME /////////////////////////////
    if (username.value.length > 30) {
        messageUsername.push('Username MAXIM 30 characters');

    }
    ///////////// EMAIL ////////////////////////////////
    if (email.value.length > 30) {
        messageEmail.push('Email MAXIM 30 characters');
    }
    ///////////// INFOBLOG /////////////////////////////
    if (info.value.length > 150) {
        messageInfoBlog.push('InfoBlog MAXIM 150 characters');
    }

    ///////////// PHONE /////////////////////////////
    if (phone.value.length > 20) {
        messagePhone.push('Phone Number MAXIM 20 characters');
    }
    ///////////// PROFESSION /////////////////////////////
    if (profession.value.length > 50) {
        messageProfession.push('Profession MAXIM 50 characters');
    }

    //////////// MESSAGE ON SCREEN/////////////////////
    if (messageUsername.length > 0) {
        e.preventDefault();
        errorUsername.innerText = messageUsername.join(', ');
    }
    if (messageEmail.length > 0) {
        e.preventDefault();
        errorEmail.innerText = messageEmail.join(', ');
    }
    if (messageInfoBlog.length > 0) {
        e.preventDefault();
        errorInfoBlog.innerText = messageInfoBlog.join(', ');
    }
    if (messagePhone.length > 0) {
        e.preventDefault();
        errorPhone.innerText = messagePhone.join(', ');
    }
    if (messageProfession.length > 0) {
        e.preventDefault();
        errorProfession.innerText = messageProfession.join(', ');
    }
});
