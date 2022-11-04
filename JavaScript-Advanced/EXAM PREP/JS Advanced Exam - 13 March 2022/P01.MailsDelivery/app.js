function solve() {
    let recipientName = document.getElementById(`recipientName`);
    let title = document.getElementById(`title`);
    let message = document.getElementById(`message`);
    let addBtn = document.getElementById(`add`);
    let resetBtn = document.getElementById(`reset`);
    let list = document.getElementById(`list`);
    let sentList = document.getElementsByClassName(`sent-list`);
    let deleteList = document.getElementsByClassName(`delete-list`);
    resetBtn.addEventListener('click', (e) =>{
        e.preventDefault();
        cleaner();
    });
    addBtn.addEventListener("click", (e) => {
        e.preventDefault();
        if (recipientName.value === "" || title.value === "" || message.value === "") {
            return;
        }
        let _titleValue = title.value;
        let _recipNameValue = recipientName.value;
        let li = generator("li");
        let h4ForTitle = generator("h4", `Title: ${title.value}`)
        let h4ForRecipName = generator("h4", `Recipient Name: ${recipientName.value}`);
        let spanForMessage = generator("span", message.value);
        let divForBtn = generator("div");
        divForBtn.setAttribute(`id`,"list-action")
        let sendBtn = document.createElement(`button`);
        sendBtn.textContent = "Send";
        sendBtn.setAttribute(`type`, "submit");
        sendBtn.setAttribute(`id`, "send");

        divForBtn.appendChild(sendBtn);

        let deleteBtn = document.createElement(`button`);
        deleteBtn.textContent = "Delete";
        deleteBtn.setAttribute(`type`, "submit");
        deleteBtn.setAttribute(`id`, `delete`);

        divForBtn.appendChild(deleteBtn);

        li.appendChild(h4ForTitle);
        li.appendChild(h4ForRecipName);
        li.appendChild(spanForMessage);
        li.appendChild(divForBtn);

        list.appendChild(li);
        deleteBtn.addEventListener('click', ()=>{
            let liForTrash = generator(`li`);
            let spanForName = generator(`span`,`To: ${_recipNameValue}`);
            let spanForTitle = generator(`span`,`Title: ${_titleValue}`);
            liForTrash.appendChild(spanForName);
            liForTrash.appendChild(spanForTitle);

            deleteList[0].appendChild(liForTrash);
            li.remove();
        })
        sendBtn.addEventListener('click', ()=>{
        let liForSent = generator(`li`);
        let spanForName = generator(`span`,`To: ${_recipNameValue}`);
        let spanForTitle = generator(`span`,`Title: ${_titleValue}`);
        let divForBtn = generator(`div`);
        divForBtn.classList.add(`btn`);
        let deleteBtn2 = document.createElement(`button`);
            deleteBtn2.textContent = "Delete";
            deleteBtn2.setAttribute(`type`, "submit");
            deleteBtn2.classList.add(`delete`);

            divForBtn.appendChild(deleteBtn2);

            liForSent.appendChild(spanForName);
            liForSent.appendChild(spanForTitle);
            liForSent.appendChild(divForBtn);
            li.remove();
            sentList[0].appendChild(liForSent);
            deleteBtn2.addEventListener('click', ()=>{
                let liForTrash = generator(`li`);
                let spanForName = generator(`span`,`To: ${_recipNameValue}`);
                let spanForTitle = generator(`span`,`Title: ${_titleValue}`);
                liForTrash.appendChild(spanForName);
                liForTrash.appendChild(spanForTitle);

                deleteList[0].appendChild(liForTrash);
                liForSent.remove();
            })
        });

        cleaner();
    });

    function generator(type, text) {
        let holder = document.createElement(type);
        if (text) {
            holder.textContent = text;
        }
        return holder;
    }

    function cleaner() {
        recipientName.value = "";
        title.value = "";
        message.value = "";
    }
}

solve()