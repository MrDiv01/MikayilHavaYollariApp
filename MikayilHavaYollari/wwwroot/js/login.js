document.getElementById('loginForm').addEventListener('submit', function(e) {
    let isValid = true;
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;

    document.getElementById('emailError').textContent = '';
    document.getElementById('passwordError').textContent = '';

    if (!email) {
        document.getElementById('emailError').textContent = 'Email gereklidir';
        isValid = false;
    } else if (email.indexOf('@') < 0) {
        document.getElementById('emailError').textContent = 'Gecerli bir email adresi girin';
        isValid = false;
    }

    if (!password) {
        document.getElementById('passwordError').textContent = 'Sifre gereklidir';
        isValid = false;
    } else if (password.length < 6) {
        document.getElementById('passwordError').textContent = 'Sifre en az 6 karakter olmalidir';
        isValid = false;
    }

    if (!isValid) {
        e.preventDefault();
    }
});
