function encodeAndDecodeMessages() {
    let btns = document.getElementsByTagName(`button`);
    for (const btn of btns) {
        btn.addEventListener("click", function () {
            let parent = btn.parentElement;
            let text = parent.children.item(0);
            if (text.textContent === `Message`) {
                let textInput = parent.children.item(1).value;
                let result = "";
                for (const sym of textInput) {
                    let asciiNum = sym.charCodeAt(0);
                    asciiNum++;
                    result += String.fromCharCode(asciiNum);
                }
                let main = parent.parentElement;
                let secondDiv = main.children.item(1);
                secondDiv.children.item(1).textContent = result;
                parent.children.item(1).value = "";

            } else if (text.textContent === `Last received message`) {
                let textInput = parent.children.item(1).textContent;
                let result = "";
                for (const sym of textInput) {
                    let asciiNum = sym.charCodeAt(0);
                    asciiNum--;
                    result += String.fromCharCode(asciiNum);
                }
                let main = parent.parentElement;
                let firstDiv = main.children.item(0);
                parent.children.item(1).textContent = result;
            }
        })
    }
}