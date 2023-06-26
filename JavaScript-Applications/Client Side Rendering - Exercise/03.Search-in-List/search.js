import {html, render} from "./node_modules/lit-html/lit-html.js";
import {towns} from "./towns.js";

let resultRoot = document.getElementById(`towns`);
let resultForTowns = document.getElementById(`result`);

document.getElementsByTagName(`button`)[0].addEventListener(`click`, search);

update();

function update(match) {

    let result = createTemplate(towns, match);
    render(result, resultRoot);
}

function createTemplate(townsNames, match) {
    const ul = html`
        <ul>
            ${townsNames.map(townName => createLiForTownName(townName, match))}
        </ul>
    `
    return ul;
}

function createLiForTownName(townName, match) {
    return html`
        <li class="${(match && townName.includes(match)) ? "active" : ""}">${townName}</li>
    `
}

function search() {
    let match = document.getElementById(`searchText`);
    console.log((match.value).toLowerCase());
    update(match.value);
    updateCount();

}
function updateCount() {
    const count = document.querySelectorAll(`.active`).length;
    const countEle = count ? html`<p>${count} matches found</p>` : html`<p>0 matches found</p>`;
    render(countEle,resultForTowns);

}