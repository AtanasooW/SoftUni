class LibraryCollection {
    constructor(capacity) {
        this.capacity = capacity;
        this.books = [];
    }

    addBook(bookName, bookAuthor) {
        if (this.capacity === this.books.length) {
            throw new Error("Not enough space in the collection.")
        }
        this.books.push({bookName, bookAuthor, payed: false});
        return `The ${bookName}, with an author ${bookAuthor}, collect.`
    }

    payBook(bookName) {
        for (const book of this.books) {
            if (book.bookName === bookName) {
                if (book.payed) {
                    throw new Error(`${bookName} has already been paid.`)
                }
                book.payed = true;
                return `${bookName} has been successfully paid.`
            }
        }
        throw new Error(`${bookName} is not in the collection.`)
    }

    removeBook(bookName) {
        for (const book of this.books) {
            if (book.bookName === bookName) {
                if (book.payed === false) {
                    throw new Error(`${bookName} need to be paid before removing from the collection.`)
                }
                let index = this.books.indexOf(book);
                this.books.splice(index, 1);
                return `${bookName} remove from the collection.`
            }
        }
        throw new Error("The book, you're looking for, is not found.")
    }

    getStatistics(bookAuthor) {
        let result = [];
        this.books.sort((a, b) => a.bookName.localeCompare(b.bookName));
        if (bookAuthor) {
            let bool = true;
            for (const book of this.books) {
                if (book.bookAuthor === bookAuthor) {
                    bool = false;
                    if (book.payed) {
                        result.push(`${book.bookName} == ${book.bookAuthor} - Has Paid.`)
                    } else {
                        result.push(`${book.bookName} == ${book.bookAuthor} - Not Paid.`)
                    }
                }
            }
            if (bool){
                throw new Error(`${bookAuthor} is not in the collection.`)
            }
        } else {
            result.push(`The book collection has ${this.capacity - this.books.length} empty spots left.`)
            for (const book of this.books) {
                if (book.payed) {
                    result.push(`${book.bookName} == ${book.bookAuthor} - Has Paid.`)
                } else {
                    result.push(`${book.bookName} == ${book.bookAuthor} - Not Paid.`)
                }
            }
        }
        return result.join(`\n`)
    }
}
try{

    const library = new LibraryCollection(5)
    library.addBook('Don Quixote', 'Miguel de Cervantes');
    library.payBook('Don Quixote');
    library.addBook('In Search of Lost Time', 'Marcel Proust');
    library.addBook('Ulysses', 'James Joyce');
    console.log(library.getStatistics());



}
catch (e) {
    console.log(e.message)
}

