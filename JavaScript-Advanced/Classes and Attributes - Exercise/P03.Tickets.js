function sortingTickets(arrayOfTickets,sortingText) {
    class Ticket {
        constructor(destination,price,status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }
    let result = [];
    for (const ticket of arrayOfTickets) {
        let [destination,price,status] = ticket.split(`|`);
        let curTicket = new Ticket(destination,Number(price),status);
        result.push(curTicket);
    }
    let final = [];
    sortingText != "price" ? final = result.sort((a,b) => a[sortingText].localeCompare(b[sortingText]))
        : final = result.sort((a,b) => a[sortingText] - b[sortingText]);
    return final;
}
console.log(sortingTickets(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination',
    'destination'));