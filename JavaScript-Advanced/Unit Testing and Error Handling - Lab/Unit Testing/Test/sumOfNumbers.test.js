const { expect } = require('chai');
const { chooseYourCar } = require('../index.js');
describe("choosingType", () => {
    it(`ShouldThrowError_InvalidYear`, () => {
        //Arrange
        //Act
        //Assert
        expect(function () {
            chooseYourCar.choosingType("car", "red", 1899);
        }).to.throw(`Invalid Year!`)
    })
    it(`ShouldThrowError_InvalidYear2`, () => {
        //Arrange
        //Act
        //Assert
        expect(function () {
            chooseYourCar.choosingType("car", "red", 2023);
        }).to.throw(`Invalid Year!`)
    })
    it(`ShouldThrowError_InvalidType`, () => {
        //Arrange
        //Act
        expect(function () {
            chooseYourCar.choosingType("Truck", "red", 2020);
        }).to.throw(`This type of car is not what you are looking for.`)
    })
    it(`ShouldWork_Successfully`, () => {
        //Arrange
        //Act
        //Assert
       let result = chooseYourCar.choosingType("Sedan","red",2010);
       expect(result).to.be.equal(`This red Sedan meets the requirements, that you have.`)
    })
    it(`ShouldWork_Successfully2`, () => {
        //Arrange
        //Act
        //Assert
       let result = chooseYourCar.choosingType("Sedan","red",1999);
       expect(result).to.be.equal(`This Sedan is too old for you, especially with that red color.`);
    })
});
describe(`brandName`, () => {
    it(`ShouldThrowError_InvalidInfo`, () => {
        //Arrange
        //Act
        //Assert
        expect(function () {
            chooseYourCar.brandName({},5);
        }).to.throw("Invalid Information!")
    })
    it(`ShouldThrowError_InvalidInfo2`, () => {
        //Arrange
        //Act
        //Assert
        expect(function () {
            chooseYourCar.brandName(["merc","bmw","audi"],{});
        }).to.throw("Invalid Information!")
    })
    it(`ShouldThrowError_InvalidInfo3`, () => {
        //Arrange
        //Act
        //Assert
        expect(function () {
            chooseYourCar.brandName(["merc","bmw","audi"],-5);
        }).to.throw("Invalid Information!")
    })
    it(`ShouldWork_Successfully`, () => {
        //Arrange
        //Act
        //Assert
        let result = chooseYourCar.brandName(["merc","bmw","audi"],1);
       expect(result).to.be.equal("merc, audi")
    })
    it(`ShouldWork_Successfully2`, () => {
        //Arrange
        //Act
        //Assert
        let result = chooseYourCar.brandName(["merc","bmw","audi"],0);
       expect(result).to.be.equal("bmw, audi")
    })
    it(`ShouldWork_Successfully3`, () => {
        //Arrange
        //Act
        //Assert
        let result = chooseYourCar.brandName(["merc","bmw","audi"],2);
       expect(result).to.be.equal("merc, bmw")
    })
})
describe("carFuelConsumption", () => {
    it("ShouldThrowError_InvalidInfo", () => {
        //Arrange
        //Act
        //Assert
        expect(function () {
            chooseYourCar.carFuelConsumption({},2);
        }).to.throw("Invalid Information!")
    })
    it("ShouldThrowError_InvalidInfo2", () => {
        //Arrange
        //Act
        //Assert
        expect(function () {
            chooseYourCar.carFuelConsumption(0,2);
        }).to.throw("Invalid Information!")
    })
    it("ShouldThrowError_InvalidInfo3", () => {
        //Arrange
        //Act
        //Assert
        expect(function () {
            chooseYourCar.carFuelConsumption(2,{});
        }).to.throw("Invalid Information!")
    })
    it("ShouldThrowError_InvalidInfo4", () => {
        //Arrange
        //Act
        //Assert
        expect(function () {
            chooseYourCar.carFuelConsumption(2,0);
        }).to.throw("Invalid Information!")
    })
    
    it("ShouldWork_Successfully", () => {
        //Arrange
        //Act
        //Assert
        let result = chooseYourCar.carFuelConsumption(100,7);
        expect(result).to.be.equal(`The car is efficient enough, it burns 7.00 liters/100 km.`)
    })
    it("ShouldWork_Successfully2", () => {
        //Arrange
        //Act
        //Assert
        let result = chooseYourCar.carFuelConsumption(100,15);
        expect(result).to.be.equal(`The car burns too much fuel - 15.00 liters!`)
    })
    it("ShouldWork_Successfully3", () => {
        //Arrange
        //Act
        //Assert
        let result = chooseYourCar.carFuelConsumption(100.25,15);
        expect(result).to.be.equal(`The car burns too much fuel - 14.96 liters!`)
    })
    it("ShouldWork_Successfully4", () => {
        //Arrange
        //Act
        //Assert
        let result = chooseYourCar.carFuelConsumption(100,15.25);
        expect(result).to.be.equal(`The car burns too much fuel - 15.25 liters!`)
    })
    it("ShouldWork_Successfully5", () => {
        //Arrange
        //Act
        //Assert
        let result = chooseYourCar.carFuelConsumption(100,6.25);
        expect(result).to.be.equal(`The car is efficient enough, it burns 6.25 liters/100 km.`)
    })
    it("ShouldWork_Successfully6", () => {
        //Arrange
        //Act
        //Assert
        let result = chooseYourCar.carFuelConsumption(100.25, 7);
        expect(result).to.be.equal(`The car is efficient enough, it burns 6.98 liters/100 km.`)
    })
})