function func(input, number) {
    let array = [...input]
    for (let i = 0; i < number; i++) {
        let lastElement = array.pop();
        array.unshift(lastElement);   
    }
    console.log(array.join(` `))
}