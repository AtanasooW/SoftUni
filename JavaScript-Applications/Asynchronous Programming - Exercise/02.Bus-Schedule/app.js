function solve() {
    let currStop = `depot`;
    let name = ``;

    let baseUrl = `http://localhost:3030/jsonstore/bus/schedule`;
    let departBtn = document.getElementById(`depart`);
    let arriveBtn = document.getElementById(`arrive`);
    let info = document.getElementById(`info`);

    async function depart() {
            let response = await fetch(`${baseUrl}/${currStop}`);
            let data = await response.json();
            name = data.name;

            info.textContent = `Next stop ${name}`;
            currStop = data.next;

            departBtn.disabled = true;
            arriveBtn.disabled = false
    }

    async function arrive() {
            info.textContent = `Arriving at ${name}`

            departBtn.disabled = false;
            arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();