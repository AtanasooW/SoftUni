function func(input) {
    let result = [];
    for (const townInfo of input) {
        let [name, productName, price] = townInfo.split(` | `)
        price = Number(price);

        let object = result.find(x => x.productName == productName)
        if (object){
            if (object.price > price){
                object.price = price;
                object.name = name;
            }
        }
        else{
        result.push({name,productName,price})
        }
    }
    for (const town of result) {
    console.log(`${town.productName} -> ${town.price} (${town.name})`)
    }
}
func(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10'])