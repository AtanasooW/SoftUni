function func(pies, firstPie, secondPie) {
    let indexOfTheFirstPie = pies.indexOf(firstPie);
    let indexOfTheSecondPie = pies.indexOf(secondPie);
    return pies.slice(indexOfTheFirstPie,indexOfTheSecondPie + 1)
}