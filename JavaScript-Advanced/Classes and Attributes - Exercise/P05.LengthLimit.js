class Stringer {
    constructor(string, length) {
        this.innerString = string;
        this.innerLength = length;
        this.saveString = string;
    }

    decrease(num) {
        if (this.innerLength - num < 0) {
            this.innerLength = 0;
        } else {
            this.innerLength -= num;
        }
    }

    increase(num) {
        this.innerLength += num;
    }

    toString() {
        if (this.innerString.length <= this.innerLength) {
            return this.innerString
        }
        else if (this.innerString.length > this.innerLength) {
            // 4, 5 - 3 = 2
            this.saveString = this.innerString.substring(0, this.innerLength) + "...";
            return this.saveString;
        }
        else if (this.innerLength === 0) {
            return "..."
        }
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...
test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test
