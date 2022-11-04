function func(input) {
    let result = {};
    for (const element of input.sort((a,b) => a.localeCompare(b))) {
        let[productName, price] = element.split(` : `)
        price = Number(price);
        let firstLetter = productName[0];
        if (!result[firstLetter]){
            result[firstLetter] = [];
        }

        result[firstLetter].push({productName, price});
    }

    for (const resultKey of Object.keys(result)) {
        console.log(resultKey);
        for (const item of result[resultKey]) {
            console.log(`  ${item.productName}: ${item.price}`)
        }
    }
}
func(['Appricot : 2{0.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']

)