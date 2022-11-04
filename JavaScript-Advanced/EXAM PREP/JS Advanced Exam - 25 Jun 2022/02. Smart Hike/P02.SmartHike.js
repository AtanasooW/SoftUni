class SmartHike{
    constructor(username) {
        this.username = username;
        this.goals = {};
        this.listOfHikes = [];
        this.resources = 100;
    }
    addGoal(peak,altitude){
        if (this.goals[peak] === undefined){
            this.goals[peak] = altitude;
            return `You have successfully added a new goal - ${peak}`
        }
        return`${peak} has already been added to your goals`

    }
    hike(peak,time,difficultyLevel){
        if (this.goals[peak] === undefined){
        throw new Error(`${peak} is not in your current goals`);
        }
        if (this.resources === 0){
            throw new Error(`You don't have enough resources to start the hike`);
        }
        let diffrence = this.resources - (time * 10);
        if (diffrence < 0){
            return "You don't have enough resources to complete the hike";
        }
        this.resources -= time * 10;
        this.listOfHikes.push({ peak, time, difficultyLevel });

        return`You hiked ${peak} peak for ${time} hours and you have ${diffrence}% resources left`
    }
    rest(time){
        this.resources += time * 10;
        if (this.resources >= 100){
            this.resources = 100;
            return `Your resources are fully recharged. Time for hiking!`
        }
        return `You have rested for ${time} hours and gained ${time*10}% resources`
    }
    showRecord(criteria){
        if (this.listOfHikes.length < 1){
            return`${this.username} has not done any hiking yet`
        }
        if (criteria === "hard"|| criteria === "easy"){
            let allHikes = this.listOfHikes.filter(hike => hike.difficultyLevel === criteria)

            let sortedHikes = allHikes.sort((a,b) => a.time - b.time);
            let bestHike = sortedHikes[0];

            if (bestHike === undefined) {
                return `${this.username} has not done any ${criteria} hiking yet`;
            }
            return `${this.username}'s best ${criteria} hike is ${bestHike.peak} peak, for ${bestHike.time} hours`
        }
        else if (criteria === "all"){
            let result = ["All hiking records:"]
            for (const hike of this.listOfHikes) {
                result.push(`${this.username} hiked ${hike.peak} for ${hike.time} hours`)
            }
            return result.join(`\n`);
        }
    }
}
try {
const user = new SmartHike('Vili');
console.log(user.addGoal('Musala', 2925));
console.log(user.hike('Musala', 8, 'hard'));
console.log(user.showRecord("easy"));
console.log(user.addGoal('Vihren', 2914));
//console.log(user.hike('Vihren', 4, 'hard'));
console.log(user.showRecord("hard"));
console.log(user.addGoal('Rui', 1706));
//console.log(user.hike('Rui', 3, 'easy'));
console.log(user.showRecord("all"));

}
catch (e) {
    console.log(e.message);
}



