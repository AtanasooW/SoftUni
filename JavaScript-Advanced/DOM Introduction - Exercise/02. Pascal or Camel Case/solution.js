function solve() {
let text = document.getElementById(`text`).value;
let formOftTheText = document.getElementById(`naming-convention`).value;
let result = document.getElementById(`result`);

let final = ``;
if (formOftTheText === `Camel Case`) {
    let array = [];
    array = text.split(` `);
    final += array[0].toLowerCase();
    for (let i = 1; i < array.length; i++) {
        let currentWord = array[i].toLowerCase();
        let firstLetter = currentWord[0].toUpperCase();
        let fixedWord = currentWord.replace(firstLetter.toLowerCase(),firstLetter)
        final += fixedWord;
    }
}
else if (formOftTheText === `Pascal Case`){
    let array = [];
    array = text.split(` `);
    for (let i = 0; i < array.length; i++) {
        let currentWord = array[i].toLowerCase();
        let firstLetter = currentWord[0].toUpperCase();
        let fixedWord = currentWord.replace(firstLetter.toLowerCase(),firstLetter)
        final += fixedWord;
    }
}
else{
    final += `Error!`
    }
result.textContent = final;
}
