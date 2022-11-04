function editElement(ref,match,replacer) {
    let matcher = new RegExp(match, `g`)
    ref.textContent = ref.textContent.replace(matcher,replacer)
}