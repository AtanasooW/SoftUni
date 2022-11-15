import {displayMonths} from "./months.js";

let years = document.getElementById(`years`);
years.style.display = "block";

export function displayYear() {
    years.addEventListener(`click`, checkYear)
}

function checkYear(e) {
    if (e.target.tagName === "DIV") {
        displayMonths(e.target.textContent);
        years.style.display = "none";
    } else if (e.target.tagName === "TD") {
        displayMonths(e.target.children.item(0).textContent)
        years.style.display = "none";

    }
}
