function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);
let result = [];
   function onClick () {
      let input = JSON.parse(document.getElementById(`inputs`).children[1].value);
      let bestRestaurantInfo = document.querySelector("#bestRestaurant p");
      let bestWorkers = document.querySelector("#workers p");
      for (const data of input) {
         let [name, workerList] = data.split(` - `)
         if (!result.find(x => x.name === name)){
            result.push({
               name,
               avgSalary: 0,
               bestSalary: 0,
               sumSalary: 0,
               workerList: []
            });
         }
         let currentRestaurant = result.find(x => x.name === name)
         workerList = workerList && workerList.split(`, `);
         for (const worker of workerList) {
            updateRestaurant(currentRestaurant, worker)
         }
      }
      let bestRestaurant = result.sort((a, b) => b.avgSalary - a.avgSalary)[0];
      bestRestaurantInfo.textContent = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.avgSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`
      let arrOfWorkers = bestRestaurant.workerList.sort((a,b) => b.salary - a.salary)
      let resultForWorkers = ``;
      for (const worker of bestRestaurant.workerList) {

         resultForWorkers += `Name: ${worker.name} With Salary: ${worker.salary} `
      }
      bestWorkers.textContent += resultForWorkers;
   }
   function updateRestaurant(obj,worker){
      let [name,salary] = worker.split(" ")
      salary = Number(salary);
      obj.workerList.push({
         name,
         salary
      })
      if (obj.bestSalary < salary){
         obj.bestSalary = salary;
      }
      obj.sumSalary += salary;
obj.avgSalary = obj.sumSalary / obj.workerList.length;
   }
}