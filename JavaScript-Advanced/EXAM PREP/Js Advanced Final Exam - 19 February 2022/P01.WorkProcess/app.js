function solve() {
    let firstName = document.getElementById(`fname`);
    let lastName = document.getElementById(`lname`);
    let email = document.getElementById(`email`);
    let birth = document.getElementById(`birth`);
    let position = document.getElementById(`position`);
    let salary = document.getElementById(`salary`);
    let addWorkerBtn = document.getElementById(`add-worker`);
    let body = document.getElementById(`tbody`);
    let buget = document.getElementById(`sum`);
    let sum = 0;

    addWorkerBtn.addEventListener(`click`,(e) =>{
        e.preventDefault()
        if (firstName.value === "" || lastName.value === "" || email.value === "" || birth.value === "" || position.value === "" || salary.value === ""){
            return;
        }
        let tr = document.createElement(`tr`);
        let tdForFirstName = generator(`td`,firstName.value,tr);
        let tdForLastName = generator(`td`,lastName.value,tr);
        let tdForEmail = generator(`td`,email.value,tr);
        let tdForBirth = generator(`td`,birth.value,tr);
        let tdForPosition = generator(`td`,position.value,tr);
        let tdForSalary =  generator(`td`,salary.value,tr);
        let tdForBtns = document.createElement(`td`);

        let firedBtn = document.createElement(`button`);
        firedBtn.classList.add(`fired`);
        firedBtn.textContent = `Fired`;

        let editBtn = document.createElement(`button`);
        editBtn.classList.add(`edit`);
        editBtn.textContent = `Edit`;

        tdForBtns.appendChild(firedBtn);
        tdForBtns.appendChild(editBtn);
        tr.appendChild(tdForBtns)
        body.appendChild(tr);
        sum += Number(salary.value);
        buget.textContent = sum.toFixed(2);
        editBtn.addEventListener(`click`,() =>{
            firstName.value = tdForFirstName.textContent;
            lastName.value = tdForLastName.textContent;
            email.value = tdForEmail.textContent;
            birth.value = tdForBirth.textContent;
            position.value = tdForPosition.textContent;
            salary.value = tdForSalary.textContent;
            editBtn.parentElement.parentElement.remove();
            sum -= Number(tdForSalary.textContent);
            buget.textContent = sum.toFixed(2);
        })
        firedBtn.addEventListener(`click`, () => {
            firedBtn.parentElement.parentElement.remove();
            sum -= Number(tdForSalary.textContent);
            buget.textContent = sum.toFixed(2);
        });
        cleaner();
    });

    function generator(type,text,parent) {
        let holder = document.createElement(type);
        if (text){
            holder.textContent = text;
        }
        if (parent){
            parent.appendChild(holder);
        }
        return holder;
    }
    function cleaner() {
        firstName.value = "";
        lastName.value = "";
        email.value = "";
        birth.value = "";
        position.value = "";
        salary.value = "";
    }
}
solve()