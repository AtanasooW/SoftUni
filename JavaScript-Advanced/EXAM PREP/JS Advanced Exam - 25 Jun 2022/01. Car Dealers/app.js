window.addEventListener("load", solve);

function solve() {
    let make = document.getElementById(`make`);
    let model = document.getElementById(`model`);
    let year = document.getElementById(`year`);
    let fuel = document.getElementById(`fuel`);
    let originalPrice = document.getElementById(`original-cost`);
    let sellingPrice = document.getElementById(`selling-price`);
    let publishBtn = document.getElementById(`publish`);
    let tableBody = document.getElementById(`table-body`);
    let totalProfit = 0;

    publishBtn.addEventListener("click", (e) => {
        e.preventDefault();
        if (make.value === "" || model.value === ""  || year.value  === ""  || fuel.value  === ""  || originalPrice.value === ""  || sellingPrice.value === "" ) {
            return;
        }
        if (originalPrice.value > sellingPrice.value) {
            return;
        }
        let tr = makeHTML("tr");
        tr.setAttribute("class", "row");
        let tdForMake = makeHTML("td", make.value);
        let tdForModel = makeHTML("td", model.value);
        let tdForYear = makeHTML("td", year.value);
        let tdForFuel = makeHTML("td", fuel.value);
        let tdForOriginalPrice = makeHTML("td", originalPrice.value);
        let tdForSellingPrice = makeHTML("td", sellingPrice.value)

        let tdForBtns = makeHTML("td");
        let editBtn = document.createElement('button');
        editBtn.textContent = 'Edit';
        editBtn.classList.add('action-btn')
        editBtn.classList.add('edit')

        let sellBtn = document.createElement('button');
        sellBtn.textContent = 'Sell'
        sellBtn.classList.add('action-btn');
        sellBtn.classList.add('sell');

        tr.appendChild(tdForMake);
        tr.appendChild(tdForModel);
        tr.appendChild(tdForYear);
        tr.appendChild(tdForFuel);
        tr.appendChild(tdForOriginalPrice);
        tr.appendChild(tdForSellingPrice);

        tdForBtns.appendChild(editBtn);
        tdForBtns.appendChild(sellBtn);
        tr.appendChild(tdForBtns);

        tableBody.appendChild(tr);

        make.value = "";
        model.value = "";
        year.value = "";
        fuel.value = "";
        originalPrice.value = "";
        sellingPrice.value = "";

        editBtn.addEventListener("click", () => {
            make.value = tdForMake.textContent;
            model.value = tdForModel.textContent;
            year.value = tdForYear.textContent;
            fuel.value = tdForFuel.textContent;
            originalPrice.value = tdForOriginalPrice.textContent;
            sellingPrice.value = tdForSellingPrice.textContent;

            editBtn.parentElement.parentElement.remove();
        });
        sellBtn.addEventListener("click", () => {
            let carsList = document.getElementById(`cars-list`);
            let profit = document.getElementById(`profit`);
            let li = document.createElement(`li`);
            li.className = "each-list";
            let spanForMake = document.createElement(`span`);
            let spanForYear = document.createElement(`span`);
            let spanForProfit = document.createElement(`span`);
            debugger;
            let curProfit = tdForSellingPrice.textContent - tdForOriginalPrice.textContent
            spanForMake.textContent = tdForMake.textContent + " " + tdForModel.textContent;

            spanForYear.textContent = tdForYear.textContent;

            spanForProfit.textContent = curProfit;


            li.appendChild(spanForMake)
            li.appendChild(spanForYear)
            li.appendChild(spanForProfit);
            carsList.appendChild(li);

            totalProfit += Number(curProfit);
            profit.textContent = Math.round(totalProfit).toFixed(2);

            sellBtn.parentElement.parentElement.remove();
        });

    })

    function makeHTML(html, text) {
        let holder = document.createElement(html);
        if (text) {
            holder.textContent = text;
        }
        return holder;
    }
}
