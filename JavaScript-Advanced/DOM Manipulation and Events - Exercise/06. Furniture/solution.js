function solve() {
    let btns = document.getElementsByTagName(`button`);
    for (const btn of btns) {
        btn.addEventListener("click", function () {
            if (btn.textContent === "Generate") {
                let json = document.getElementsByTagName(`textarea`)[0].value
                let fortnite = json.slice(1, json.length - 1)
                let arr = fortnite.split(`}, `);

                for (let i = 0; i < arr.length - 1; i++) {
                    let word =`${arr[i]}}`
                    arr[i] = word;
                }
                for (const element of arr) {
                let text = JSON.parse(element);
                let tbody = document.createElement(`tbody`);
                let tr = document.createElement(`tr`);
                //img
                let tdForImg = document.createElement(`td`);
                let img = document.createElement(`img`);
                img.src = text.img;
                tdForImg.appendChild(img);
                //name
                let tdForName = document.createElement(`td`);
                let pForName = document.createElement(`p`);
                pForName.textContent = text.name;
                tdForName.appendChild(pForName);
                //price
                let tdForPrice = document.createElement(`td`);
                let pForPrice = document.createElement(`p`);
                pForPrice.textContent = text.price;
                tdForPrice.appendChild(pForPrice);
                //decFactor
                let tdForDecFactor = document.createElement(`td`);
                let pForDecFactor = document.createElement(`p`);
                pForDecFactor.textContent = text.decFactor;
                tdForDecFactor.appendChild(pForDecFactor);
                //chekbox
                let tdForChekBox = document.createElement(`td`);
                let input = document.createElement(`input`);
                input.type = "checkbox";
                tdForChekBox.appendChild(input);
                //connecting
                tr.appendChild(tdForImg);
                tr.appendChild(tdForName);
                tr.appendChild(tdForPrice);
                tr.appendChild(tdForDecFactor);
                tr.appendChild(tdForChekBox);
                tbody.appendChild(tr);
                //debugger;
                let tableInHtml = document.getElementsByClassName(`table`)[0];
                let tBody = tableInHtml.children.item(1);
                console.log(tBody)
                tBody.appendChild(tr)

                }
            } else if (btn.textContent === "Buy") {
                let tableInHtml = document.getElementsByClassName(`table`)[0];
                let tbodies = tableInHtml.children;
                let names = [];
                let sum = 0;
                let decSum = 0;
                let counter = 0;

                for (const tbody of tbodies) {

                    if (tbody.tagName === `TBODY`) {

                        let tr = tbody.children

                        for (const td of tr) {
                            let everyTd = td.children
                                let allData = [];
                            for (const currentTd of everyTd) {
                                let info = currentTd.children.item(0);
                                if (info.tagName === `P`) {
                                    allData.push(info.textContent)
                                }
                                if (info.tagName === "INPUT") {
                                    if (info.checked === true) {
                                        names.push(allData[0]);
                                        sum += Number(allData[1]);
                                        decSum += Number(allData[2]);
                                        counter++;
                                    }
                                }
                            }
                        }
                    }
                }

                let textArea = document.getElementsByTagName(`textarea`)[1];
                if (names.length < 1){
                    return
                }
                let output = `Bought furniture: ${names.join(", ")}\nTotal price: ${sum.toFixed(2)}\nAverage decoration factor: ${decSum / counter}`;
                textArea.value = output
            }
        })
    }
}