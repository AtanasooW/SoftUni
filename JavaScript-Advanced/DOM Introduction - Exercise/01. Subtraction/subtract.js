function subtract() {
 let numberOne = document.getElementById(`firstNumber`).value
 let numberTwo = document.getElementById(`secondNumber`).value
 let result = document.getElementById(`result`);
 result.textContent = Number(numberOne) - Number(numberTwo);
}