async function Submit(e) {
    debugger;
    let form = document.getElementById(`form`);
    form.addEventListener(`submit`, onSubmit)

    await display();

    async function onSubmit(e) {
        e.preventDefault();

        let data = new FormData(form);
        const studentObject = Object.fromEntries(data.entries());
        if (Object.values(studentObject).includes("")) {
            return;
        }

        await fetch(`http://localhost:3030/jsonstore/collections/students`, {
            method: `POST`,
            headers: {"Content-type": `application/json`},
            body: JSON.stringify(studentObject)
        });

        await display();
    }

    async function display() {
        let response = await fetch(`http://localhost:3030/jsonstore/collections/students`);
        let data = await response.json();
        let results = document.getElementById(`results`);
        let tbody = results.children.item(1);
        tbody.innerHTML = "";
        Object.entries(data).forEach(([id, person]) => {
            console.log(id);
            console.log(person);
            let tr = document.createElement(`tr`);
            let tdForFirstName = document.createElement(`td`);
            let tdForLastName = document.createElement(`td`);
            let tdForNumber = document.createElement(`td`);
            let tdForGrade = document.createElement(`td`);

            tdForFirstName.textContent = person.firstName;
            tdForLastName.textContent = person.lastName;
            tdForNumber.textContent = person.facultyNumber;
            tdForGrade.textContent = person.grade;
            tr.appendChild(tdForFirstName);
            tr.appendChild(tdForLastName);
            tr.appendChild(tdForNumber);
            tr.appendChild(tdForGrade);
            tbody.appendChild(tr)
        });
    }
}
Submit();