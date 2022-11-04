function deleteByEmail() {
    let email = document.getElementsByName(`email`)[0].value.trim();
    let cols = document.querySelectorAll(`#customers tr td:nth-child(2)`)
    let result = document.getElementById(`result`);
    let isFound = false
    for (const col of cols) {
        if (email === col.textContent){
            col.parentElement.remove();
            isFound = true;
        }
    }
    if (isFound){
        result.textContent = 'Deleted.'
    }
    else{
        result.textContent = `Not found.`
    }
}