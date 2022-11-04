function func(car) {
let wheels = new Array(4);
    car.wheelsize % 2 == 0 ? wheels.fill(car.wheelsize - 1, 0,4) : wheels.fill(car.wheelsize, 0,4);

    function EngineList(enginePower) {
        if (enginePower > 120){
            return { power: 200, volume: 3500 }
        }
        else if (enginePower > 90){
            return { power: 120, volume: 2400 }
        }
        else {
            return { power: 90, volume: 1800 }
        }
    }
    let result = {
        model: car.model,
        engine: EngineList(car.power),
        carriage: {type: car.carriage, color: car.color},
        wheels

    }
    return result;
}
console.log(func({ model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14 }))