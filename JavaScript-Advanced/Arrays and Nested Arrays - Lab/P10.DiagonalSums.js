function func(matrix) {
    let sumOfFirstDiagonal = 0;
    let sumOfSecondDiagonal = 0;
    for (let row = 0; row < matrix.length; row++) {
        sumOfFirstDiagonal += matrix[row][row];
        sumOfSecondDiagonal += matrix[row][matrix[row].length - 1 - row];
    }
    console.log(`${sumOfFirstDiagonal} ${sumOfSecondDiagonal}`);

}