function func(array) {
    let result = []
    let index = 0;
    let number = 0;

    for (const  element of array) {
        if (element === `add`){
    number++;
    result.push(number);
}
else if (element === `remove`){
    result.pop();
    number++;
}
    }
    if (result.length < 1){
        console.log(`Empty`)
    }
    else{

console.log(result.join(`\n`))
    }
}
func([`add`,`add`,`remove`,`add`,`add`])