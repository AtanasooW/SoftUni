function func(worker) {
    if (worker.dizziness == true){
        let sumToHudrateLevel = 0.1 * worker.weight * worker.experience;
        worker.levelOfHydrated += 0.1 * worker.weight * worker.experience;
        worker.dizziness = false;
    }
    return worker;
}
console.log(func({ weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true }))