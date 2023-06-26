import {html, render} from "./node_modules/lit-html/lit-html.js";
import {cats} from "./catSeeder.js";

let allCats = document.getElementById(`allCats`);
let result = createCatsCard()
render(result, allCats);
function createCatsCard() {
    let catsCard = html`
    <ul>
        ${cats.map(cat => catCard(cat))}
    </ul>
    `
    return catsCard;
}
function catCard(cat) {
    let liForCat = html`
        <li>
            <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
            <div class="info">
                <button @click="${showContent}" class="showBtn">Show status code</button>
                <div class="status" style="display: none" id="${cat.id}">
                    <h4>Status Code: ${cat.statusCode}</h4>
                    <p>${cat.statusMessage}</p>
                </div>
            </div>
        </li>
    `
    return liForCat;
}
function showContent(e) {
    let div = e.target.parentElement.querySelector(`div`);
    if(div.style.display === "none"){
        e.target.textContent = "Hide status code";
        div.style.display = "block";
    }
    else if (div.style.display === "block"){
    e.target.textContent = "Show status code";
    div.style.display = "none";
    }
}