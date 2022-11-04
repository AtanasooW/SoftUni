function fubc(array) {
    let result = array.map(element => {
        let data = element.split(` <-> `)
        return {
            name: data[0],
            population: Number(data[1])
        }
    })
    let registry = {}
    for (const element of result) {
        if (registry[element.name] === undefined){
            registry[element.name] = element.population;
        }
        else{
            registry[element.name] += element.population;
        }
    }
    for (const town in registry) {
        console.log(`${town} : ${registry[town]}`)
    }
}