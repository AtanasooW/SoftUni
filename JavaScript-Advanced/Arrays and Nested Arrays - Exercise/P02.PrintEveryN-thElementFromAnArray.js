function fucn(array, number) {
    let result = [];
    result.push(array[0]);
    for (let i = 0; i < array.length; i++) {
        for (let j = i; j < array.length; j += number) {
            if (j >= array.length){
                break;
            }
            i+= number;
            result.push(array[i]);
        }
    }
    return result;
}