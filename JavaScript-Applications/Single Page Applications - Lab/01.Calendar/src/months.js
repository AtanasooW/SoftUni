import {displayDays} from "./days.js";
let sect = '';
let year1 = "";

export function displayMonths(year) {
    year1 = year;
let section = document.getElementById(`year-${year}`)
    section.style.display = "block";
    sect = section;

    section.addEventListener(`click`,onClick);

}
function onClick(e) {
    let month = "";
    if (e.target.tagName === "DIV") {
        month = e.target.textContent;

    }
else if (e.target.tagName === "TD"){
        month  = e.target.children.item(0).textContent;
    }
    let number = 0;
    switch (month) {
        case "Jan": number = 1; break;
        case "Feb": number = 2; break;
        case "Mar": number = 3; break;
        case "Apr": number = 4; break;
        case "May": number = 5; break;
        case "Jun": number = 6; break;
        case "Jul": number = 7; break;
        case "Aug": number = 8; break;
        case "Sept": number = 9; break;
        case "Oct": number = 10; break;
        case "Nov": number = 11; break;
        case "Dec": number = 12; break;
    }
    displayDays(year1,number);
    sect.style.display = "none";
}
