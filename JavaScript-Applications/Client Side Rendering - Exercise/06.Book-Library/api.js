let url = `http://localhost:3030/jsonstore/collections/books`;


export async function post(title, author) {
    await fetch(url, {
        method: `POST`,
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({title, author})
    })
}
export function del (id) {
    fetch(url + `/${id}`, {
        method: `DELETE`
    })
}


export async function get() {
    let response = await fetch(url)
    let data = await response.json();
    return data;
}
export function put(id,title,author) {
    fetch(url + `/${id}`,{
        method: `PUT`,
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({title, author})
    })
}