function func(array) {
    let arr2 = [];
    for (const element of array) {
        if (element >= 0){
            arr2.push(element);
        }
        else{
            arr2.unshift(element)
        }
    }
    
console.log(arr2.join(`\n`))
}


func([7,-2,8,9])