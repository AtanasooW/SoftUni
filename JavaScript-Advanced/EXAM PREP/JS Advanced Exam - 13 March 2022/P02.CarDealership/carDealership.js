class CarDealership {
    constructor(name) {
        this.name = name;
        this.availableCars = [];
        this.soldCars = [];
        this.totalIncome = 0;
    }

    addCar(model, horsepower, price, mileage) {
        if (model === "" || horsepower < 0 || price < 0 || mileage < 0) {
            throw new Error("Invalid input!")
        }
        let car = {model, horsepower, price, mileage};
        this.availableCars.push(car);
        return `New car added: ${model} - ${horsepower} HP - ${mileage.toFixed(2)} km - ${price.toFixed(2)}$`
    }

    sellCar(model, desiredMileage) {
        //let Mycar = {model: "Mercedes C63", horsepower: 300, soldPrice: 29000}
        for (const car of this.availableCars) {
            if (car.model === model) {
                if (car.mileage <= desiredMileage) {
                    let index = this.availableCars.indexOf(car);
                    this.availableCars.splice(index, 1);
                    this.soldCars.push({model: car.model, horsepower: car.horsepower, soldPrice: car.price});
                    this.totalIncome += car.price;
                    return `${model} was sold for ${(car.price).toFixed(2)}$`
                } else {
                    let difference = car.mileage - desiredMileage;
                    let discount = 0;
                    if (difference <= 40000) {
                        discount = 0.95;
                    } else if (difference > 40000) {
                        discount = 0.9;
                    }
                    let index = this.availableCars.indexOf(car);
                    this.availableCars.splice(index, 1);
                    this.soldCars.push({model: car.model, horsepower: car.horsepower, soldPrice: car.price * discount});
                    this.totalIncome += car.price * discount;
                    return `${model} was sold for ${(car.price * discount).toFixed(2)}$`
                }
            }
        }
        throw new Error(`${model} was not found!`);
    }

    currentCar() {
        if (this.availableCars.length < 1) {
            return "There are no available cars"
        }
        let result = ["-Available cars:"]
        for (const car of this.availableCars) {
            result.push(`---${car.model} - ${car.horsepower} HP - ${(car.mileage).toFixed(2)} km - ${(car.price).toFixed(2)}$`)
        }
        return result.join(`\n`);
    }

    salesReport(criteria) {

        let result = [`-${this.name} has a total income of ${this.totalIncome.toFixed(2)}$`];
        result.push(`-${this.soldCars.length} cars sold:`)
        if (criteria === "horsepower") {
            let sortedCars = this.soldCars.sort((a, b) => b.horsepower - a.horsepower)
            for (const car of sortedCars) {
                result.push(`---${car.model} - ${car.horsepower} HP - ${(car.soldPrice).toFixed(2)}$`)
            }
        } else if (criteria === "model") {
            let sortedCars = this.soldCars.sort((a, b) => a.model.localeCompare(b.model))
            for (const car of sortedCars) {
                result.push(`---${car.model} - ${car.horsepower} HP - ${(car.soldPrice).toFixed(2)}$`)
            }
        } else {
            throw new Error("Invalid criteria!");
        }
        return result.join('\n');
    }
}

let dealership = new CarDealership('SoftAuto');
console.log(dealership.addCar('Toyota Corolla', 100, 3500, 190000));
console.log(dealership.addCar('Mercedes C63', 300, 29000, 187000));
console.log(dealership.addCar('Audi A3', 120, 4900, 240000));
console.log(dealership.currentCar());
console.log(dealership.sellCar('Toyota Corolla', 230000));
console.log(dealership.sellCar('Mercedes C63', 110000));
console.log(dealership.salesReport('horsepower'));

