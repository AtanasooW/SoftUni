import {html, render} from "./node_modules/lit-html/lit-html.js";
import {post, del, get, put} from "./api.js"
import {result} from "./views/allPage.js";

let body = document.getElementsByTagName(`body`)[0];

displayAllPage();

function displayAllPage() {
    render(result, body);
}

let loadBtn = document.getElementById(`loadBooks`);
loadBtn.addEventListener(`click`, loadBooks);

    let tbody = document.getElementsByTagName(`tbody`)[0];
async function loadBooks() {
    let result = await displayBook();
    render(result, tbody);
}


debugger;
let addForm = document.getElementById(`add-form`);
let editForm = document.getElementById(`edit-form`);
addForm.addEventListener(`submit`, onSubmit);


function onSubmit(e) {
    e.preventDefault();

    let {title, author} = Object.fromEntries(new FormData(addForm).entries());
    if (title === "" || author === "") return;
    post(title, author)
    loadBooks()
    document.querySelector(`[name = "title"]`).value = "";
    document.querySelector(`[name = "author"]`).value = "";
}

async function displayBook() {

    let data = await get();
    let result = Object.entries(data).map((id) => createTemplateForBook(id))
    return result;
}

function createTemplateForBook(id) {
    return html`
        <tr>
            <td>${id[1].title}</td>
            <td>${id[1].author}</td>
            <td id="${id[0]}">
                <button @click="${editBook}">Edit</button>
                <button @click="${removeBook}">Delete</button>
            </td>
        </tr>
    `
}

function editBook(e) {
    let id = e.target.parentElement.id;
    editForm.style.display = "block";
    addForm.style.display = "none";
    debugger;
    document.querySelectorAll(`[name = "title"]`)[1].value = e.target.parentElement.parentElement.children.item(0).textContent;
    document.querySelectorAll(`[name = "author"]`)[1].value = e.target.parentElement.parentElement.children.item(1).textContent;
    editForm.addEventListener(`submit`, onEdit)

   async function onEdit(e) {
        e.preventDefault();
        put(id,document.querySelectorAll(`[name = "title"]`)[1].value, document.querySelectorAll(`[name = "author"]`)[1].value);
        await loadBooks();
        editForm.style.display = "none";
        addForm.style.display = "block";
    }
}

function removeBook(e) {
    debugger;
    let id = e.target.parentElement.id;
    e.target.parentElement.parentElement.remove();
    del(id);
}




