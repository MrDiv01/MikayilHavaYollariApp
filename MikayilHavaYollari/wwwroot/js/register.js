document.getElementById('password').addEventListener('input', function() {
    const password = this.value;
    const strengthBar = document.getElementById('strengthBar');
    const strengthText = document.getElementById('strengthText');
    let strength = 0;

    if (password.length >= 8) strength++;
    if (/[a-z]/.test(password) && /[A-Z]/.test(password)) strength++;
    if (/[0-9]/.test(password)) strength++;
    if (/[^a-zA-Z0-9]/.test(password)) strength++;

    strengthBar.className = 'strength-bar';
    if (strength <= 1) {
        strengthBar.classList.add('strength-weak');
        strengthText.textContent = 'Zayif sifre';
    } else if (strength <= 2) {
        strengthBar.classList.add('strength-medium');
        strengthText.textContent = 'Orta guclu sifre';
    } else {
        strengthBar.classList.add('strength-strong');
        strengthText.textContent = 'Guclu sifre';
    }
});

document.getElementById('registerForm').addEventListener('submit', function(e) {
    let isValid = true;
    const firstName = document.getElementById('firstName').value;
    const lastName = document.getElementById('lastName').value;
    const email = document.getElementById('email').value;
    const phone = document.getElementById('phone').value;
    const password = document.getElementById('password').value;
    const confirmPassword = document.getElementById('confirmPassword').value;
    const termsAccepted = document.getElementById('termsAccepted').checked;

    document.querySelectorAll('.form-error').forEach(el => el.textContent = '');

    if (!firstName) {
        document.getElementById('firstNameError').textContent = 'Ad gereklidir';
        isValid = false;
    }

    if (!lastName) {
        document.getElementById('lastNameError').textContent = 'Soyadi gereklidir';
        isValid = false;
    }

    if (!email) {
        document.getElementById('emailError').textContent = 'Email gereklidir';
        isValid = false;
    } else if (email.indexOf('@') < 0) {
        document.getElementById('emailError').textContent = 'Gecerli bir email adresi girin';
        isValid = false;
    }

    if (!phone) {
        document.getElementById('phoneError').textContent = 'Telefon gereklidir';
        isValid = false;
    }

    if (!password) {
        document.getElementById('passwordError').textContent = 'Sifre gereklidir';
        isValid = false;
    } else if (password.length < 6) {
        document.getElementById('passwordError').textContent = 'Sifre en az 6 karakter olmalidir';
        isValid = false;
    }

    if (!confirmPassword) {
        document.getElementById('confirmPasswordError').textContent = 'Sifre onayi gereklidir';
        isValid = false;
    } else if (password !== confirmPassword) {
        document.getElementById('confirmPasswordError').textContent = 'Sifreler eslesmiyor';
        isValid = false;
    }

    if (!termsAccepted) {
        document.getElementById('termsError').textContent = 'Sartlari kabul etmelisiniz';
        isValid = false;
    }

    if (!isValid) {
        e.preventDefault();
    }
});
