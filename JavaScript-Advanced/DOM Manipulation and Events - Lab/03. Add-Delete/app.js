function addItem() {
    let text = document.getElementById(`newItemText`).value;
    let items = document.getElementById(`items`);

    let li = document.createElement(`li`);
    li.textContent = text;

    let btn = document.createElement(`a`);
    btn.textContent = "[Delete]";
    btn.href = `#`
    btn.addEventListener(`click`, function(event){
    event.target.parentElement.remove()
    });


    li.appendChild(btn);
    items.appendChild(li);
    document.getElementById(`newItemText`).value = ""
}