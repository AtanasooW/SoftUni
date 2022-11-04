function func(data, startIndex = 0, endIndex = data.length - 1) {
    if (!Array.isArray(data)){
       return NaN;
    }
    if (startIndex < 0){
        startIndex = 0;
    }
    if (endIndex > data.length - 1){
        endIndex = data.length - 1;
    }
    let result = 0;
    for (let i = startIndex; i <= endIndex ; i++) {
        //if (typeof(data[i]) !== 'number'){
           // return NaN;
        //}
        result += Number(data[i]);
    }
    return result;
}