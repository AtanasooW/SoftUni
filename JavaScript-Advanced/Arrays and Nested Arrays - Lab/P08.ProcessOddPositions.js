function func(array) {
    return array.filter((x , i) => i % 2 !== 0)
    .map(function (num) {
       return num * 2
    })
    .reverse()
    .join(` `)
    }