function func(number, command1,command2,command3,command4,command5) {
let arr = [command1,command2,command3,command4,command5];
for (let i = 0; i < 5; i++) {
    switch (arr[i]) {
        case `chop`:
            number /= 2;
            break;
        case `dice`:
            number = Math.floor(Math.sqrt(number))//squirt
            break;
        case `spice`:
            number++;
            break;
        case `bake`:
            number *= 3;
            break;
        case `fillet`:
            number -= (number * 0.2);
            break;
            default:
            break;
    }
    console.log(number);
    
}
}
fucn(9,`dice`,`spice`,`chop`,`bake`,`fillet`)//10
11
5.5
16.5
13.2