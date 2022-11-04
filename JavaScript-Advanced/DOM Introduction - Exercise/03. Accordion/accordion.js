function toggle() {
    let buttonText = document.getElementsByClassName(`button`)[0];
    let text = document.getElementById(`extra`);
    if (buttonText.textContent === `More`){
        buttonText.textContent = `Less`
        text.style.display = `block`;
    }
    else{
        buttonText.textContent = `More`;
        text.style.display = `none`;
    }
}