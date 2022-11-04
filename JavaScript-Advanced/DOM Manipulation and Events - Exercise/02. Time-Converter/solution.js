function attachEventsListeners() {
let daysBtn = document.getElementById(`daysBtn`);
let hoursBtn = document.getElementById(`hoursBtn`);
let minutesBtn = document.getElementById(`minutesBtn`);
let secondBtn = document.getElementById(`secondsBtn`);
daysBtn.addEventListener("click", function (event) {
    let days = document.getElementById(`days`).value
    document.getElementById(`hours`).value = days * 24;
    document.getElementById(`minutes`).value = days * 1440;
    document.getElementById(`seconds`).value = days * 86400;
});
hoursBtn.addEventListener("click", function (event) {
    let hours = document.getElementById(`hours`).value
    document.getElementById(`days`).value = hours / 24;
    document.getElementById(`minutes`).value = hours * 60;
    document.getElementById(`seconds`).value = (hours * 60) * 60;
});
minutesBtn.addEventListener("click", function (event) {
    let minutes = document.getElementById(`minutes`).value
    document.getElementById(`days`).value = (minutes / 60) / 24;
    document.getElementById(`hours`).value = minutes / 60;
    document.getElementById(`seconds`).value = minutes * 60;
});
secondBtn.addEventListener("click", function (event) {
    let seconds = document.getElementById(`seconds`).value;
    document.getElementById(`days`).value = ((seconds / 60) / 60) / 24;
    document.getElementById(`hours`).value = (seconds / 60) / 60;
    document.getElementById(`minutes`).value = seconds / 60;
});

}