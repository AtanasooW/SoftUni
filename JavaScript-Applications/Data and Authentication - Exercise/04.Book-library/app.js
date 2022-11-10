function solve() {
    const baseUrl = 'http://localhost:3030/jsonstore/collections/books';
    let loadBooks = document.getElementById(`loadBooks`);
    let form = document.querySelector(`form`);
    let tbody = document.querySelector(`tbody`);
    loadBooks.addEventListener(`click`, onLoad)
    tbody.addEventListener(`click`, modify)

    form.addEventListener(`submit`, onSubmit);

    async function onSubmit(e) {
        e.preventDefault();
        debugger;
        if(e.target.children.item(5).tagName !== "BUTTON")return
        if(e.target.children.item(5).textContent === "Save"){
            await onSave(e);
            return;
        }
        let {title,author} = Object.fromEntries(new FormData(form).entries());
        if(title === "" || author === "")return;

        let response = await fetch(baseUrl, {
            method: `POST`,
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({title,author})
        })
        document.querySelector(`[name = "title"]`).value = "";
        document.querySelector(`[name = "author"]`).value = "";
        await onLoad();
    }
    async function onSave(e) {
        debugger;
        document.querySelector(`form h3`).textContent = "FORM";

        document.querySelector(`form button`).textContent = "Submit";
        let id = document.querySelector(`form button`).id;
        let title = document.querySelector(`[name = "title"]`).value;
        let author =  document.querySelector(`[name = "author"]`).value;
        await fetch(`${baseUrl}/${id}`, {
            method: `PUT`,
            headers: {"Content-type": `applications/json`},
            body: JSON.stringify({title,author})
        })
        document.querySelector(`[name = "title"]`).value = "";
        document.querySelector(`[name = "author"]`).value = "";
       await onLoad();
    }
    function modify(e) {
        console.log(e.target)
        if(e.target.tagName !== `BUTTON`)return;
        e.target.textContent === `Edit` ? onEdit(e) : onDelete(e);
    }
    function onEdit(e) {
debugger;
        document.querySelector(`form h3`).textContent = `Edit FORM`;

        let title = e.target.parentElement.parentElement.children.item(0).textContent;
        let author = e.target.parentElement.parentElement.children.item(1).textContent;

        document.querySelector(`[name = "title"]`).value = title;
        document.querySelector(`[name = "author"]`).value = author;

        e.target.parentElement.parentElement.remove();
        document.querySelector(`form button`).textContent = `Save`;
        document.querySelector(`form button`).id = e.target.id;
    }
    async function onDelete(e) {
        await fetch(`${baseUrl}/${e.target.parentElement.children.item(0).id}`,{
            method: `DELETE`,
        })
        e.target.parentElement.parentElement.remove();
    }
    async function onLoad() {
        debugger;
        let response = await fetch(`http://localhost:3030/jsonstore/collections/books`);
        let data = Object.entries(await response.json());
        tbody.innerHTML = "";

        for (const [key,{author,title}] of data) {
            let tr = document.createElement(`tr`);

            let tdForBtns = document.createElement(`td`);
            let editBtn = document.createElement(`button`);
            editBtn.textContent = "Edit";
            editBtn.id = key;

            let deleteBtn = document.createElement(`button`);
            deleteBtn.textContent = "Delete";

            tdForBtns.appendChild(editBtn);
            tdForBtns.appendChild(deleteBtn);

            let tdForTitle = document.createElement(`td`);
            let tdForAuthor = document.createElement(`td`);
            tdForAuthor.textContent = author;
            tdForTitle.textContent = title;
            tr.appendChild(tdForTitle);
            tr.appendChild(tdForAuthor);
            tr.appendChild(tdForBtns);
            tbody.appendChild(tr);

        }
    }
}
solve();