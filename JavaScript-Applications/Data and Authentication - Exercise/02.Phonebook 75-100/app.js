async function attachEvents() {
    let loadBtn = document.getElementById(`btnLoad`);
    let phoneBook = document.getElementById(`phonebook`);

    loadBtn.addEventListener(`click`, load);

    let createBtn = document.getElementById(`btnCreate`);
    let person = document.getElementById(`person`)
    let phone = document.getElementById(`phone`)

    createBtn.addEventListener(`click`, async () => {
        let data = {"person": person.value, "phone": phone.value};
        person.value = "";
        phone.value = "";
        if (data.person === "") {
            return;
        }
        let url = `http://localhost:3030/jsonstore/phonebook/`
        await fetch(url, {
            method: `POST`,
            headers: {"Content-type": `application/json`},
            body: JSON.stringify(data)
        })
        await load()
    });

    async function load() {
        let response = await fetch(`http://localhost:3030/jsonstore/phonebook`);
        let data = await response.json();
        phoneBook.innerHTML = "";
        Object.entries(data).forEach(([id, phone]) => {
            let li = document.createElement(`li`);
            li.textContent = phone.person + ": " + phone.phone;
            li.id = id;
            phoneBook.appendChild(li);

        });
        for (const li of phoneBook.children) {
            let deleteBtn = document.createElement(`button`);
            deleteBtn.textContent = `Delete`;
            li.innerHTML = li.textContent;
            li.appendChild(deleteBtn);
            deleteBtn.addEventListener(`click`, async () => {

                await fetch(`http://localhost:3030/jsonstore/phonebook/${li.id}`, {
                    method: `DELETE`
                })
            });
        }

    }
}

attachEvents();