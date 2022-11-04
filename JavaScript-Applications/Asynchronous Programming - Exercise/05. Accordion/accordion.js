async function solution() {
    let main = document.getElementById(`main`);
    let response = await fetch(`http://localhost:3030/jsonstore/advanced/articles/list`);
    let data = await response.json();
    for (const story of data) {
        main.innerHTML += `<div class="accordion">
            <div class="head">
                <span>${story.title}</span>
                <button class="button" id="${story._id}">More</button>
            </div>
            <div class="extra">
                <p></p>
            </div>
        </div> `
    }
    let btns = document.getElementsByClassName(`button`);
    for (const btn of btns) {
        btn.addEventListener(`click`, async () => {
            if (btn.textContent === "More") {
                let url = `http://localhost:3030/jsonstore/advanced/articles/details/`
                let id = btn.id;
                let response = await fetch(`${url}${id}`);
                let data = await response.json();
                let div = btn.parentElement.parentElement.children.item(1);
                div.style.display = "block";
                let p = btn.parentElement.parentElement.children.item(1).children.item(0);
                p.textContent = data.content;
                btn.textContent = "Less"
            } else if (btn.textContent === "Less") {
                let div = btn.parentElement.parentElement.children.item(1);
                div.style.display = "none";
                btn.textContent = "More"
            }
        });
    }
}