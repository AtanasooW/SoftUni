function func(array) {
    let result =  {};
    for (let i = 0; i < array.length; i++) {
        if (i % 2 !== 0){
        result[array[i - 1]] = Number(array[i]);
        }
    }
    return result;
}
console.log(func(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']))