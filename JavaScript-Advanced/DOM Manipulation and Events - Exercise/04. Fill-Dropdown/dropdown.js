function addItem() {
let text = document.getElementById(`newItemText`).value;
let textValue = document.getElementById(`newItemValue`).value;
let option = document.createElement(`option`);
option.textContent = text;
option.value = textValue;
let menu = document.getElementById(`menu`);
menu.appendChild(option);
document.getElementById(`newItemText`).value = "";
document.getElementById(`newItemValue`).value = "";
}