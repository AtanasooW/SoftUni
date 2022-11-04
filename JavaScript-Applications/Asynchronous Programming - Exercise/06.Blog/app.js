async function attachEvents() {
    let menu = document.getElementById(`posts`);
    let response = await fetch(`http://localhost:3030/jsonstore/blog/posts`);
    let data = await response.json();
    Object.entries(data).forEach(([id,body]) => {
        console.log(body.title)
        let option = document.createElement(`option`);
        option.textContent = body.title;
        option.value = body.id;
        menu.appendChild(option)
        //menu.innerHTML += `<options value="${body.id}">${body.title}</options>`
    })

    let btn = document.getElementById(`btnViewPost`);
    let commentsPost = document.getElementById(`post-comments`)
    let postTitle = document.getElementById(`post-title`)
    let postBody = document.getElementById(`post-body`)

    btn.addEventListener(`click`,async ()=>{
            debugger;
            let resposeForComments = await fetch(`http://localhost:3030/jsonstore/blog/comments`);
            let dataForComments = await resposeForComments.json();
            let postId = ``;
        commentsPost.innerHTML = "";
                Object.entries(dataForComments).forEach(([id,body]) => {
                    if (body.postId === menu.value){
                        let option = document.createElement(`li`);
                        option.textContent = body.text;
                        option.id = body.id;
                        postId = body.postId;
                        commentsPost.appendChild(option)
                    }
                });
                let responseForPost = await fetch(`http://localhost:3030/jsonstore/blog/posts/${postId}`)
                let dataForPost = await responseForPost.json();
                postTitle.textContent = dataForPost.title;
                postBody.textContent = dataForPost.body;
    })
}

attachEvents();