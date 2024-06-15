document.addEventListener('DOMContentLoaded', () => {
    const phoneInputField = document.querySelector("#phone");
    const phoneInput = window.intlTelInput(phoneInputField, {
        preferredCountries: ["us", "in", "gb", "de"],
        utilsScript: "https://cdnjs.cloudflare.com/ajax/libs/intl-tel-input/17.0.8/js/utils.js",
    });

    function calculateAge() {
        const dob = document.getElementById('dob').value;
        if (dob) {
            const birthDate = new Date(dob);
            const today = new Date();

            let years = today.getFullYear() - birthDate.getFullYear();
            let months = today.getMonth() - birthDate.getMonth();

            if (months < 0 || (months === 0 && today.getDate() < birthDate.getDate())) {
                years--;
                months = (months + 12) % 12;
            }

            if (today.getDate() < birthDate.getDate()) {
                months--;
                if (months < 0) {
                    months = 11;
                }
            }

            document.getElementById('age').value = `${years} years ${months} months`;
            document.getElementById('dobError').innerText = '';
            document.getElementById('dob').classList.remove('is-invalid');
            document.getElementById('dob').classList.add('is-valid');
        } else {
            document.getElementById('dobError').innerText = 'Please enter your date of birth.';
            document.getElementById('dob').classList.remove('is-valid');
            document.getElementById('dob').classList.add('is-invalid');
        }
    }

    function validateName() {
        const name = document.getElementById('name').value;
        if (name.trim() === '') {
            document.getElementById('nameError').innerText = 'Name is required.';
            document.getElementById('name').classList.remove('is-valid');
            document.getElementById('name').classList.add('is-invalid');
            return false;
        } else {
            document.getElementById('nameError').innerText = '';
            document.getElementById('name').classList.remove('is-invalid');
            document.getElementById('name').classList.add('is-valid');
            return true;
        }
    }

    function validatePhone() {
        const phoneNumber = phoneInput.getNumber();
        if (!phoneInput.isValidNumber()) {
            document.getElementById('phoneError').innerText = 'Please enter a valid phone number.';
            document.getElementById('phone').classList.remove('is-valid');
            document.getElementById('phone').classList.add('is-invalid');
            return false;
        } else {
            document.getElementById('phoneError').innerText = '';
            document.getElementById('phone').classList.remove('is-invalid');
            document.getElementById('phone').classList.add('is-valid');
            return true;
        }
    }

    function validateEmail() {
        const email = document.getElementById('email').value;
        const emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
        if (!emailPattern.test(email)) {
            document.getElementById('emailError').innerText = 'Please enter a valid email address.';
            document.getElementById('email').classList.remove('is-valid');
            document.getElementById('email').classList.add('is-invalid');
            return false;
        } else {
            document.getElementById('emailError').innerText = '';
            document.getElementById('email').classList.remove('is-invalid');
            document.getElementById('email').classList.add('is-valid');
            return true;
        }
    }

    function validateProfession() {
        const profession = document.getElementById('profession').value;
        const professionError = document.getElementById('professionError');

        if (profession === '') {
            professionError.innerText = 'Profession cannot be empty.';
            document.getElementById('profession').classList.remove('is-valid');
            document.getElementById('profession').classList.add('is-invalid');
            return false;
        } else {
            professionError.innerText = '';
            document.getElementById('profession').classList.remove('is-invalid');
            document.getElementById('profession').classList.add('is-valid');
            return true;
        }
    }

    function validateForm() {
        const isNameValid = validateName();
        const isPhoneValid = validatePhone();
        const isEmailValid = validateEmail();
        const dob = document.getElementById('dob').value;
        const gender = document.querySelector('input[name="gender"]:checked');
        const qualifications = document.querySelectorAll('input[name="qualification"]:checked');
        const profession = document.getElementById('profession').value;
        let isFormValid = true;

        if (!dob) {
            document.getElementById('dobError').innerText = 'Please enter your date of birth.';
            document.getElementById('dob').classList.remove('is-valid');
            document.getElementById('dob').classList.add('is-invalid');
            isFormValid = false;
        } else {
            document.getElementById('dobError').innerText = '';
            document.getElementById('dob').classList.remove('is-invalid');
            document.getElementById('dob').classList.add('is-valid');
        }

        if (!gender) {
            document.getElementById('genderError').innerText = 'Please select your gender.';
            isFormValid = false;
        } else {
            document.getElementById('genderError').innerText = '';
        }

        if (qualifications.length === 0) {
            document.getElementById('qualificationError').innerText = 'Please select at least one qualification.';
            isFormValid = false;
        } else {
            document.getElementById('qualificationError').innerText = '';
        }

        if (profession.trim() === '') {
            document.getElementById('professionError').innerText = 'Please select or enter your profession.';
            document.getElementById('profession').classList.remove('is-valid');
            document.getElementById('profession').classList.add('is-invalid');
            isFormValid = false;
        } else {
            validateProfession();
            document.getElementById('professionError').innerText = '';
            document.getElementById('profession').classList.remove('is-invalid');
            document.getElementById('profession').classList.add('is-valid');
        }

        if (isFormValid && isNameValid && isPhoneValid && isEmailValid) {
            document.getElementById('registrationForm').reset();
            showToast();
        }
    }

    function showToast() {
        const toast = document.getElementById("toast");
        toast.className = "toast show";
        setTimeout(function () {
            toast.className = toast.className.replace("show", "");
        }, 3000);

        var closeButton = document.querySelector('.toast .close');
        closeButton.onclick = function () {
            var toast = this.parentElement;
            toast.style.visibility = 'hidden';
        };
    }

    window.calculateAge = calculateAge;
    window.validateForm = validateForm;
});
