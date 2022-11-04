async function lockedProfile() {
    let profile = document.getElementsByClassName(`profile`);
    let main = document.getElementById(`main`);

    let response = await fetch(`http://localhost:3030/jsonstore/advanced/profiles`);
    let data = await response.json();
        debugger;
    Object.entries(data).forEach(([id,person]) => {
        let div = document.createElement(`div`);
        main.innerHTML += `
<div class="profile">
    <img src="./iconProfile2.png" class="userIcon" />
    <label>Lock</label>
    <input type="radio" name="user1Locked" value="lock" checked>
    <label>Unlock</label>
    <input type="radio" name="user1Locked" value="unlock"><br>
    <hr>
    <label>Username</label>
    <input type="text" name="user1Username" value="${person.username}" disabled readonly />
    <div class="user1Username" style="display: none">
        <hr>
        <label>Email:</label>
        <input type="email" name="user1Email" value="${person.email}" disabled readonly />
        <label>Age:</label>
        <input type="email" name="user1Age" value="${person.age}" disabled readonly />
</div>
<button>Show more</button>
</div>`
        //let info = div.children.item(9);
        //console.log(info)
        //info.style.display = `none`;
    })
    for (const profil of profile) {
        let btn = profil.children.item(10)
        btn.addEventListener(`click`, function () {

            let unlocked = profil.children.item(4)
            let hiddenInfo = profil.children.item(9)
            console.log(hiddenInfo);
            if (unlocked.checked === true) {
                if (btn.textContent === `Show more`) {
                    hiddenInfo.style.display = `block`;
                    btn.textContent = `Hide it`
                } else if (btn.textContent === `Hide it`) {
                    hiddenInfo.style.display = `none`;
                    btn.textContent = `Show more`
                }
            } else {
                if (btn.textContent === `Hide it`) {
                    btn.disabled = false;
                }
                return;
            }
        });
    }
}