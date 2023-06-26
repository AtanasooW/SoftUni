import {html, render} from "./node_modules/lit-html/lit-html.js";

let root = document.getElementById(`root`);
let form = document.getElementsByTagName(`form`)[0];
form.addEventListener(`submit`, onSubmit)

function onSubmit(e) {
    e.preventDefault()
    let towns = (form.querySelector(`input`).value).split(", ");
    renderTowns(towns);

}

function renderTowns(data) {
    let result = createTowns(data);
    render(result, root);
}

function createTowns(data) {
    let ul = html`
        <ul>
            ${data.map(town => html`<li>${town}</li>`)}
        </ul>
    `;
    return ul;
}