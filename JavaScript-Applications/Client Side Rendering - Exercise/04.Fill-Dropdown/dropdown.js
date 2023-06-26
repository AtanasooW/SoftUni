import {html, render} from "./node_modules/lit-html/lit-html.js";

let url = `http://localhost:3030/jsonstore/advanced/dropdown`

let menu = document.getElementById(`menu`);
let form = document.querySelector(`form`);
form.addEventListener(`submit`, onSubmit);

await display();

async function onSubmit(e) {
    e.preventDefault();
    const value = document.getElementById(`itemText`).value;
    await addItem(value);
    document.getElementById(`itemText`).value = "";
    await display();
}

async function addItem(value) {
    await fetch(url, {
            method: `POST`,
            headers: {"Content-type": `application/json`},
            body: JSON.stringify({text: value})
        }
    )
}
async function display() {
    let data = await getData();
    let result = Object.values(data).map(x => generateTemplate(x))
    render(result,menu)
    console.log(data);
}

function generateTemplate(option) {
    return  html`
        <option value="${option._id}">${option.text}</option>
    `
}

async function getData() {
    let response = await fetch(url);
    let data = await response.json();
    return data;
}