function func(array) {
    array.sort((a, b) => a - b)    
    let result = array.slice(array.length / 2)
    return result;
}