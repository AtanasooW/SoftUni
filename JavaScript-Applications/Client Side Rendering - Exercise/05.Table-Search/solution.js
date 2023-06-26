import {html, render} from "./node_modules/lit-html/lit-html.js";

let url = "http://localhost:3030/jsonstore/advanced/table";

document.querySelector('#searchBtn').addEventListener('click', onClick);
let tbody = document.getElementsByTagName(`tbody`)[0];

async function onClick() {
    let searchText = document.getElementById(`searchField`).value;
    await display(searchText.toLowerCase());
    document.getElementById(`searchField`).value = "";
}

await display();

async function display(match) {

    let data = await getData();
    let result = Object.values(data).map(x => generateTemplate(x, match))
    render(result, tbody);
}

function generateTemplate(option, match) {
    return html`
        <tr class="${(match && option.firstName.toLowerCase().includes(match) || option.lastName.toLowerCase().includes(match) || option.email.toLowerCase().includes(match) || option.course.toLowerCase().includes(match)) ? "select" : ""}">
            <td>${option.firstName} ${option.lastName}</td>
            <td>${option.email}</td>
            <td>${option.course}</td>
        </tr>
    `
}

async function getData() {
    let response = await fetch(url);
    let data = await response.json();
    return data;
}