function extract(content) {
let text = document.getElementById(content);
let pattern =/\(([^(]+)\)/g;
let matches = text.textContent.matchAll(pattern);
let arr = [];
    for (const match of matches) {
        arr.push(match[1]);
    }
    return  arr.join(`; `)
}
let text = extract(`content`)