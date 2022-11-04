function func(heroRegister) {
    let result = [];
    for (const element of heroRegister) {
        let[heroName,level,items] = element.split(` / `)
        level = Number(level);
        items = items ? items.split(`, `) : []
        result.push({name: heroName, level: level, items})
    }
    console.log(JSON.stringify(result));
}
func(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'])