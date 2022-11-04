function func(matrix) {
let sumOfRows = 0;

    for (let i = 0; i < matrix.length - 1; i++) {
       let sumOfRowOne = matrix[i].reduce((acc,el) => acc +el)
       let sumOfRowTwo = matrix[i + 1].reduce((acc,el) => acc +el)
        let sumOfColOne = 0
        let sumOfColTwo = 0
        for (let j = 0; j < matrix.length; j++) {
            sumOfColOne += matrix[i][j]
            sumOfColTwo += matrix[i + 1][j]
        }
        if (sumOfRowOne !== sumOfRowTwo || sumOfColOne !== sumOfColTwo){
        return false;
        }
    }
    return true;
}
console.log((func([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]])))