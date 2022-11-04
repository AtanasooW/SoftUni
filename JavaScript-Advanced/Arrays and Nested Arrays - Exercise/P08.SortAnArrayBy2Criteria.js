function func(array) {
   let result = array.sort((a,b) => {
       if(a.length === b.length){
           return a.localeCompare(b);
       }
       else{
       return a.length - b.length;
       }
   })
   console.log(array.join(`\n`))
}
func([`pesho`, `gosho`,`ata`])