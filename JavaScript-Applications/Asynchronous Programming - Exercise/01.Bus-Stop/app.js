async function getInfo() {
let stopName = document.getElementById(`stopName`);
let busesList = document.getElementById(`buses`);
let stopId = document.getElementById(`stopId`);

stopName.innerHTML = "";
busesList.innerHTML = "";
try {
    let response = await fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopId.value}`);
    let data = await response.json();

    stopName.textContent = data.name;
    Object.entries(data.buses).forEach(([busId,time]) => {
        let li = document.createElement(`li`);
        li.textContent = `Bus ${busId} arrives in ${time} minutes`
        busesList.appendChild(li);
    });
 }
 catch (e) {
     stopName.textContent = "Error";
 }
}