function extractText() {
    let elements = document.getElementById(`items`)
    let result = document.getElementById(`result`)
    result.value = elements.textContent;
}