function printDeckOfCards(cards) {
    try{
        let result = [];
        for (const card of cards) {
            let face = card[0];
            let suit = card[1];
            if (card[0] === `1` && card[1] === `0`){
                face = `10`;
                suit = card[2]
            }
            let currentCard = createCard(face,suit)
            result.push(currentCard);
        }
        console.log(result.join(` `));
    }
    catch (error){
        console.log(error.message)
        return;
    }
    function createCard(face,suit) {
        let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        let validSuits = ['S', 'H', 'D', 'C'];

        if (validFaces.indexOf(face) === -1){
            throw new Error(`Invalid card: ${face}${suit}`);
        }
        if (validSuits.indexOf(suit) === -1){
            throw new Error(`Invalid card: ${face}${suit}`);
        }
        switch (suit){
            case 'S': suit = '\u2660'; break;
            case 'H': suit = '\u2665'; break;
            case 'D': suit = '\u2666'; break;
            case 'C': suit = '\u2663'; break;
        }
        return {
            face: face,
            suit: suit,
            toString(){
                return this.face + this.suit;
            }
        }
    }
    // TODO
}
printDeckOfCards(['5S', '3D', 'QD', '1C'])
