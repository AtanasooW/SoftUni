function create(words) {
   let result = document.getElementById(`content`);
   for (const word of words) {
      let div = document.createElement(`div`);
      let p = document.createElement(`p`);
      p.textContent = word;
      p.style.display = `none`;
      div.appendChild(p);
      div.addEventListener(`click`, function (event) {
         p.style.display = `block`;
      })
      result.appendChild(div)
   }
}