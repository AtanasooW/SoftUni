function func(arr) {
    let arr2 = [];
    arr2 = arr.filter((x,i) =>{
        if(i % 2 == 0){
    return x;
        }
    })
    console.log(arr2.join(` `))
}