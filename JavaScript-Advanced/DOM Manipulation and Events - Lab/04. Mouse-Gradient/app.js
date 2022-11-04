function attachGradientEvents() {
    let box = document.getElementById(`gradient`);
    let result = document.getElementById(`result`);
    box.addEventListener(`mousemove`, function (event){
       let gradientWith = event.target.clientWidth;
       let offsetX = event.offsetX;
       let procent = Math.floor((offsetX / gradientWith) * 100);
       result.textContent = `${procent}%`
    });
}