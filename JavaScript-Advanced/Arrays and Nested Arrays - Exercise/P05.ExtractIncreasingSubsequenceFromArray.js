function func(input) {
    let array = [...input];
    let result = [];
    let biggestNum = -51515151
    for (let i = 0; i < array.length; i++) {
        if (biggestNum <= array[i]) {
            result.push(array[i]);
            biggestNum = array[i];
        }
        
    }
    return result;
}