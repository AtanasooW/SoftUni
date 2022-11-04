function func(n,k) {
    let arr = [];
    let number = 0;
    arr.push(1);
    let sum = 0;
    for (let i = 1; i < n; i++) {
        sum = 0;
        if(i - k < 0){
    for (let l = 0; l < i; l++) {
    sum += arr[l];
}
arr[i] = sum;
        } 
        else{
            for (let j = 1; j <= k; j++) {
                    sum += arr[i-j];
            }
            arr[i] = sum;
        } 
        }
    return arr;
}
console.log(func(6,3));