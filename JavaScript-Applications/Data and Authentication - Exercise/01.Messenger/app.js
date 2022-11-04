function attachEvents() {
    let textArea = document.getElementById(`messages`);
    let author = document.getElementsByName(`author`)[0];
    let content = document.getElementsByName(`content`)[0];
    let submitBtn = document.getElementById(`submit`);
    let refreshBtn = document.getElementById(`refresh`);

    refreshBtn.addEventListener(`click`, async () =>{
    let response = await fetch(`http://localhost:3030/jsonstore/messenger`);
    let data = await response.json();
    textArea.textContent = "";
    let result = [];
    Object.entries(data).forEach(([id,message]) =>{

        result.push(message.author + ": " + message.content );
    });
    textArea.textContent += result.join("\n");
    });
    submitBtn.addEventListener(`click`,async () =>{
        const data = {"author": author.value, "content": content.value}
        debugger;
        await fetch(`http://localhost:3030/jsonstore/messenger`, {
            method: `post`,
            headers: {"Content-type": `application/json`},
            body: JSON.stringify(data)
        })
        author.value = "";
        content.value = "";
    });
}

attachEvents();