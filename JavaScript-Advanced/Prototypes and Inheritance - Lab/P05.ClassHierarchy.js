function func() {
    class Figure {
        constructor(units = "cm") {
            this.unit = units;
            this.lastUnit = "";
        }
        get area() {

        }

        changeUnits(unit) {
            this.unit = unit;
        }

        toString() {
            return `Figures units: ${this.unit}`
        }
    }

    class Circle extends Figure {
        constructor(radius) {
            super();
            this.radius = radius;
        }

        get area() {
            let sum = Math.PI * (this.radius * this.radius);
            if (this.unit === "mm"){
                sum *= 100;
                this.radius *= 100;
            }
            else if(this.unit === "cm"){
                sum *= 100;
                this.radius *= 100;
            }
            if (this.unit === "m"){
                sum /= 1000;
                this.radius /= 1000;
            }
            return sum;
        }
        toString() {
            return super.toString() +` Area: ${this.area} - radius: ${this.radius}`;
        }
    }

    class Rectangle extends Figure {
        constructor(width, height, units) {
            super(units);
            this.width = width;
            this.height = height;
        }
        get area(){
            let sum = this.width * this.height;
            if (this.unit === "mm"){
                sum *= 100;
                this.width *= 100;
                this.height *= 100;
            }
            if (this.unit === "m"){
                sum /= 1000;
                this.width /= 1000;
                this.height /= 1000;
            }
            return sum;
        }
        toString() {
            return super.toString() + ` Area: ${this.area} - width: ${this.width}, height: ${this.height}`;
        }
    }
    return {
        Figure,
        Circle,
        Rectangle
    }
}