function func(array) {
    array.sort((a,b) => a - b)
    let result = [];
    while(array.length != 0){
        result.push(array.shift())
        result.push(array.pop())
    }
    return result
}
console.log(func([-20,-10,-50,10,510,90]))