function focused() {
let inpunts = document.getElementsByTagName(`input`);
    for (const input of inpunts) {
    input.addEventListener(`focus` , focus)
    input.addEventListener(`blur` , blur)
    }
function focus(event) {
event.target.parentElement.classList.add(`focused`)
}
function blur(event) {
event.target.parentElement.classList.remove(`focused`)
}
}
