function createCard(face,suit) {
    let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    let validSuits = ['S', 'H', 'D', 'C'];

    if (validFaces.indexOf(face) === -1){
        throw new Error();
    }
    if (validSuits.indexOf(suit) === -1){
        throw new Error();
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
console.log(createCard(`A`,`S`).toString())