function sumTable() {
    let elements = document.querySelectorAll(`table tr`)
    let sum = 0;
    for (let i = 1; i < elements.length - 1; i++) {
        let num = elements[i].children
        sum += Number(num[1].textContent);
    }
    let result = document.getElementById(`sum`);
    result.textContent = sum;
}