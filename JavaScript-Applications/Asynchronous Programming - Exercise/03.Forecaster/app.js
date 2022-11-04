function attachEvents() {
    let btn = document.getElementById(`submit`)
    let input = document.getElementById(`location`)
    let today = document.getElementById(`current`)
    let forecast = document.getElementById(`forecast`)
    let upcoming = document.getElementById(`upcoming`)


    btn.addEventListener(`click`, async () =>{
        let response = await fetch(`http://localhost:3030/jsonstore/forecaster/locations`);
        let data = await response.json();
        let bool = true;
        for (const city of data) {
            if (city.name === input.value){
                bool = false;
                let url = `http://localhost:3030/jsonstore/forecaster/today`
                let todayResponse = await fetch(`${url}/${city.code}`)
                let todayData = await todayResponse.json();


                let div = generator(`div`);
                div.classList.add(`forecasts`);

                let symbol = ``;
                switch (todayData.forecast.condition) {
                    case "Sunny": symbol = `☀`;break
                    case "Partly sunny": symbol = `⛅`;break
                    case "Overcast": symbol = `☁`;break
                    case "Rain": symbol = `☂`;break
                }
                let spanForConditionSymbol = generator(`span`,symbol,div);

                spanForConditionSymbol.classList.add(`condition`);
                spanForConditionSymbol.classList.add(`symbol`);

                let spanforConditions = generator(`span`)
                spanforConditions.classList.add(`condition`);

                div.appendChild(spanforConditions);

                let spanForCity = generator(`span`,todayData.name, spanforConditions)
                let spanForTemp = generator(`span`,`${todayData.forecast.low}°/${todayData.forecast.high}°`,spanforConditions)
                let spanForConditons = generator(`span`,todayData.forecast.condition,spanforConditions);

                spanForCity.classList.add(`forecast-data`);
                spanForTemp.classList.add(`forecast-data`);
                spanForConditons.classList.add(`forecast-data`);

                today.appendChild(div);
                forecast.style.display = `block`

                let urlThreeDay = `http://localhost:3030/jsonstore/forecaster/upcoming`
                let threeDayResponse = await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${city.code}`);
                let threeDayData = await threeDayResponse.json();

                let div3 = generator(`div`);
                div3.classList.add(`forecast-info`);

                 debugger;
                for (const day of threeDayData.forecast) {

                    let symbol = ``;
                    switch (day.condition) {
                        case "Sunny": symbol = `☀`;break
                        case "Partly sunny": symbol = `⛅`;break
                        case "Overcast": symbol = `☁`;break
                        case "Rain": symbol = `☂`;break
                    }

                let spanUp = generator(`span`);
                spanUp.classList.add(`upcoming`);

                let spanSymbol = generator(`span`, symbol,spanUp);
                spanSymbol.classList.add("symbol");

                let spanForTemp = generator(`span`, `${day.low}°/${day.high}°`,spanUp)
                let spanForName = generator(`span`, day.condition,spanUp)

                    spanForTemp.classList.add(`forecast-data`);
                    spanForName.classList.add(`forecast-data`);
                    div3.appendChild(spanUp);
                }
                upcoming.appendChild(div3);
            }
        }
        if (bool){//error
            forecast.textContent = "Error";
            forecast.style.display = "block";
        }
    });
}
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
attachEvents();