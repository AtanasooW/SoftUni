class Point{
    constructor(x,y) {
        this.x = x;
        this.y = y;
    }
    static distance(pointOne, pointTwo){
        let a = 0;
        let b = 0;
        let c = 0;
        if (pointOne.x > pointTwo.x){
            a = pointOne.x - pointTwo.x;
            if (pointOne.y > pointTwo.y){
                b = pointOne.y - pointTwo.y;
            }
            else{
                b = pointTwo.y - pointOne.y;
            }
        }
        else{
            a = pointTwo.x - pointOne.x
            if (pointOne.y > pointTwo.y){
                b = pointOne.y - pointTwo.y;
            }
            else{
                b = pointTwo.y - pointOne.y;
            }
        }
        c = (a * a) + (b*b)
        return Math.sqrt(c);
    }
}
let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));