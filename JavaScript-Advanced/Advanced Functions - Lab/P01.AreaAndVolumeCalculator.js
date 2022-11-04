function solve(area, vol, input){
    let text = JSON.parse(input);
    let result = [];
    for (const data of text) {
        let volResult = vol.call(data);
        let areaResult = area.call(data);
        result.push({
            area: areaResult,
            volume: volResult
        })
    }
    return result;
}
console.log(solve(area, vol, `[
{"x":"1","y":"2","z":"10"},
{"x":"7","y":"7","z":"10"},
{"x":"5","y":"2","z":"10"}
]`))
function vol() {
    return Math.abs(this.x * this.y * this.z);
};
function area(){
    return Math.abs(this.x * this.y);
};
