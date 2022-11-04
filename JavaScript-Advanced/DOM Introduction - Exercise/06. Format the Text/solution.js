function solve() {
    let text = document.getElementById(`input`).value;
    let output = document.getElementById(`output`);
    output.innerHTML = ``;
    let arr = text.split(`.`).filter(x => x.length > 0);

    for (let i = 0; i < arr.length; i += 3) {
        let result = [];
        for (let j = 0; j < 3; j++) {
            if (arr[i + j]) {
                result.push(arr[i + j]);
            }
        }
        let outputText = result.join(". ") + ".";
        output.innerHTML += `<p>${outputText}</p>`
    }
}
