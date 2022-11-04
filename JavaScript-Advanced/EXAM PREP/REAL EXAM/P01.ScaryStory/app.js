window.addEventListener("load", solve);

function solve() {
  let firstName = document.getElementById(`first-name`);
  let lastName = document.getElementById(`last-name`);
  let age = document.getElementById(`age`);
  let storyTitle = document.getElementById(`story-title`);
  let genre = document.getElementById(`genre`);
  let story = document.getElementById(`story`);
  let publishBtn = document.getElementById(`form-btn`);
  let previewList = document.getElementById(`preview-list`);
  publishBtn.addEventListener(`click`, (e)=>{
      e.preventDefault();
      if (firstName.value === "" || lastName.value === "" || age.value === "" || storyTitle.value === "" || story.value === ""){
          return;
      }
      let li = document.createElement(`li`);
      li.classList.add("story-info");
      let article = generator(`article`);
      let h4ForName = generator(`h4`,`Name: ${firstName.value} ${lastName.value}`,article)
      let pForAge = generator(`p`,`Age: ${age.value}`,article);
      let pForTitle = generator(`p`,`Title: ${storyTitle.value}`, article);
      let pForGenre = generator(`p`,`Genre: ${genre.value}`,article);
      let pForText = generator(`p`,story.value, article);

      let _firstName = firstName.value
      let _lastName = lastName.value
      let _age = age.value
      let _storyTitle = storyTitle.value
      let _genre = genre.value;
      let _text = story.value

      let saveBtn = document.createElement(`button`);
      saveBtn.classList.add(`save-btn`);
      saveBtn.textContent = "Save Story";

      let editBtn = document.createElement(`button`);
      editBtn.classList.add(`edit-btn`);
      editBtn.textContent = "Edit Story";

      let deleteBtn = document.createElement(`button`);
      deleteBtn.classList.add(`delete-btn`);
      deleteBtn.textContent = "Delete Story";

      li.appendChild(article);
      li.appendChild(saveBtn);
      li.appendChild(editBtn);
      li.appendChild(deleteBtn);
      previewList.appendChild(li);

      publishBtn.disabled = true;
      cleaner();
      editBtn.addEventListener(`click`, () =>{
          firstName.value = _firstName;
          lastName.value = _lastName;
          age.value = _age;
          storyTitle.value = _storyTitle;
          story.value = _text;
          genre.value = _genre;
          publishBtn.disabled = false;
          editBtn.parentElement.remove()
      });
      saveBtn.addEventListener(`click`, () =>{
         let main = document.getElementById(`main`);
         let side = document.getElementById(`side-wrapper`);
         let some = document.getElementsByClassName('form-wrapper')[0];
         some.remove()
         side.remove();
          let h1 = document.createElement(`h1`);
          h1.textContent = "Your scary story is saved!";
          main.appendChild(h1);
      });
      deleteBtn.addEventListener(`click`, ()=>{
          publishBtn.disabled = false;
          deleteBtn.parentElement.remove();
      });
  });
    function generator(type,text,parent) {
        let holder = document.createElement(type);
        if (text){
            holder.textContent = text;
        }
        if (parent){
            parent.appendChild(holder);
        }
        return holder;
    }
    function cleaner() {
        firstName.value = "";
        lastName.value = "";
        age.value = "";
        storyTitle.value = "";
        story.value = "";
    }
}
