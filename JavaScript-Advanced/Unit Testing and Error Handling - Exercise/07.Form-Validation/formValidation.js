function validate() {
    let username = document.getElementById("username");
    let email = document.getElementById(`email`);
    let password = document.getElementById("password");
    let confrimPass = document.getElementById("confirm-password");
    let company = document.getElementById("company");
    let submitBtn = document.getElementById("registerForm");
    let companyInfo = document.getElementById("companyInfo");
    company.addEventListener("change", () => {
        if (company.checked) {
            companyInfo.style.display = "block"
        } else {
            companyInfo.style.display = "none"
        }
    })

    submitBtn.addEventListener("submit", (e) => {
        e.preventDefault()
        let userNamePattern = /^[A-Za-z0-9]{3,20}$/;
        let emailPattern = /^[^@.]+@[^@]*\.[^@]*$/;
        let passwordPattern = /^[\w]{5,15}$/;
        let usernameBool = false;
        let passBool = false;
        let emailBool = false
        let companyBool = false;
        //USERNAME
        if (username.value.length >= 3 && username.value.length <= 20) {
            if (userNamePattern.test(username.value)) {
                username.style.borderColor = "none"
                usernameBool = true;
            } else {
                username.style.borderColor = "red";
            }
        }
        else{
                username.style.borderColor = "red";
        }
        //PASSWORD
        if (passwordPattern.test(password.value) && passwordPattern.test(confrimPass.value) && password.value === confrimPass.value) {
            password.style.borderColor = "none";
            confrimPass.style.borderColor = "none";
            passBool = true;
        } else {
            password.style.borderColor = "red";
            confrimPass.style.borderColor = "red";
        }
        //EMAIL
        if (emailPattern.test(email.value)) {
            email.style.borderColor = "none"
            emailBool = true;
        } else {
            email.style.borderColor = "red"
        }

        //company
        if (company.checked) {
            let companyNum = document.getElementById("companyNumber");
            if (companyNum.value >= 1000 && companyNum.value <= 9999) {
                companyNum.style.borderColor = "none";
                companyBool = true;
            } else {
                companyNum.style.borderColor = "red";
            }
        }
        let valid = document.getElementById(`valid`);
        if (company.checked){
            if (usernameBool && passBool && emailBool && companyBool){
                valid.style.display = "block";
            }
            else{
                valid.style.display = "none"
            }
        }
        else{
            if (usernameBool && passBool && emailBool){
                valid.style.display = "block";
            }
            else{
                valid.style.display = "none"
            }
        }
    });
}
