export function displayDays(year, month) {
    //month-2020-2
    console.log(`month-${year}-${month}`);
    let section = document.getElementById(`month-${year}-${month}`)
    section.style.display = "block";
}