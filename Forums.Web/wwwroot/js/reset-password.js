////////////////////////// VARIABILES //////////////////////////////////////////////////

//const password = document.getElementById('Password');
//const conPassword = document.getElementById('ConPassword');


//////////////////// GREEN ARROW ///////////////////////////////////////////////////////

//var passwordAccept = document.getElementById('password-accept-data');
//var conPasswordAccept = document.getElementById('con-password-accept-data');


////////////////// WRONG INPUT ////////////////////////////////////////////////////////

//var errorPassword = document.getElementById('error-password');
//var errorConPassword = document.getElementById('error-con-password');


///////////////////// FORM ///////////////////////////////////////////////////////////
//var reset = document.getElementById('reset-password');

////////////////////// VALIDATE GREEN ARROW /////////////////////////////////////////



/////////////////////////////////////////////////////////////////////////////////

/////////////////// FORM CHECKS /////////////////////////////////////////////////
//reset.addEventListener('submit', (e) => {
//    e.preventDefault();
//    let messagePassword = []
//    let messageConPassword = []

//    ///////////// PASSWORD /////////////////////////////
//    if (password.value.length <= 7) {
//        messagePassword.push('Password MINIM 8 characters');
//        passwordAccept.innerHTML = '';
//    }
//    if (password.value.length > 50) {
//        messagePassword.push('Password MAXIM 50 characters');
//        passwordAccept.innerHTML = '';
//    }
//    ///////////// CON-PASSWORD /////////////////////////
//    if (conPassword.value.length <= 7) {
//        messageConPassword.push('Password MINIM 8 characters');
//        conPasswordAccept.innerHTML = '';
//    }
//    if (conPassword.value.length > 50) {
//        messageConPassword.push('Password MAXIM 50 characters')
//        conPasswordAccept.innerHTML = '';
//    }
//    if (password.value != conPassword.value) {
//        messagePassword.push('Passwords are not identical')
//        messageConPassword.push('Passwords are not identical');
//        passwordAccept.innerHTML = '';
//        conPasswordAccept.innerHTML = '';
//    }
  
//    //////////// MESSAGE ON SCREEN/////////////////////
   
//    if (messagePassword.length > 0) {
//        e.preventDefault();
//        errorPassword.innerText = messagePassword.join(', ');
//    }
//    if (messageConPassword.length > 0) {
//        e.preventDefault();
//        errorConPassword.innerText = messageConPassword.join(', ');
//    }

//});



$(document).ready(function () {
    $('#reset-password').submit(function (e) {
        e.preventDefault();

        // Validare personalizată
        var messagePassword = [];
        var messageConPassword = [];

        var password = $('#Password').val();
        var conPassword = $('#ConPassword').val();

        var passwordAccept = $('#password-accept-data');
        var conPasswordAccept = $('#con-password-accept-data');

        var errorPassword = $('#error-password');
        var errorConPassword = $('#error-con-password');

        // Resetare mesaje eroare
        errorPassword.text('');
        errorConPassword.text('');

        // Validare parola
        if (password.length <= 7) {
            messagePassword.push('Password MINIM 8 characters');
            passwordAccept.text('');
        }
        if (password.length > 50) {
            messagePassword.push('Password MAXIM 50 characters');
            passwordAccept.text('');
        }
        // Validare confirmare parola
        if (conPassword.length <= 7) {
            messageConPassword.push('Password MINIM 8 characters');
            conPasswordAccept.text('');
        }
        if (conPassword.length > 50) {
            messageConPassword.push('Password MAXIM 50 characters');
            conPasswordAccept.text('');
        }
        if (password !== conPassword) {
            messagePassword.push('Passwords are not identical');
            messageConPassword.push('Passwords are not identical');
            passwordAccept.text('');
            conPasswordAccept.text('');
        }

        // Afișare mesaje eroare
        if (messagePassword.length > 0) {
            errorPassword.text(messagePassword.join(', '));
        }
        if (messageConPassword.length > 0) {
            errorConPassword.text(messageConPassword.join(', '));
        }

        // Dacă nu există mesaje de eroare, trimite cererea AJAX
        if (messagePassword.length === 0 && messageConPassword.length === 0) {
            var formData = {
                Password: password,
                ConPassword: conPassword,
                __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
            };

            $.ajax({
                url: '@Url.Action("ResettingProcess", "ResetPassword")',
                type: 'POST',
                data: formData,
                success: function (response) {
                    if (response.success) {
                        alert('Password reset successful. Redirecting to login page.');
                        var newWindow = window.open('@Url.Action("Index", "Login")', '_blank');
                        if (newWindow) {
                            newWindow.focus();
                            window.close();
                        }
                    } else {
                        alert('Error resetting password. Please try again.');
                    }
                },
                error: function () {
                    alert('Error resetting password. Please try again.');
                }
            });
        }
    });
});

