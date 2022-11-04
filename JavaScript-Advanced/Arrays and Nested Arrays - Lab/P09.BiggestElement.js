function func(matrix) {
    let biggestNum = -515151515
    for (let i = 0; i < matrix.length; i++) {
        for (let cols = 0; cols < matrix[i].length; cols++) {
            if(biggestNum < matrix[i][cols]){
                biggestNum = matrix[i][cols]
            }
            
        }
        
    }
    return biggestNum
}