function calc() {
   let numberOne = document.getElementById(`num1`)
   let numberTwo = document.getElementById(`num2`)
    let sum = document.getElementById(`sum`);
   sum.value = Number(numberOne.value) + Number(numberTwo.value);
}
