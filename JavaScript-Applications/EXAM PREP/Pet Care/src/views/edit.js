import {html} from '../api/lib.js';
import {createSubmitHandler} from "../api/util.js";
import {put,get} from "../api/api.js";

const editTemplate = (pet,onEdit) => html`
    <!--Edit Page-->
    <section id="editPage">
        <form @submit="${onEdit}" class="editForm">
            <img src="./images/editpage-dog.jpg">
            <div>
                <h2>Edit PetPal</h2>
                <div class="name">
                    <label for="name">Name:</label>
                    <input name="name" id="name" type="text" .value="${pet.name}">
                </div>
                <div class="breed">
                    <label for="breed">Breed:</label>
                    <input name="breed" id="breed" type="text" .value="${pet.breed}">
                </div>
                <div class="Age">
                    <label for="age">Age:</label>
                    <input name="age" id="age" type="text" .value="${pet.age}">
                </div>
                <div class="weight">
                    <label for="weight">Weight:</label>
                    <input name="weight" id="weight" type="text" .value="${pet.weight}">
                </div>
                <div class="image">
                    <label for="image">Image:</label>
                    <input name="image" id="image" type="text" .value="${pet.image}">
                </div>
                <button class="btn" type="submit">Edit Pet</button>
            </div>
        </form>
    </section>
`;

export async function editHome(ctx) {
    debugger;
    let id = ctx.params.id;
    console.log(id);
    let pet = await get(`/data/pets/${id}`);
    console.log(pet);
    console.log(pet.name);
    ctx.render(editTemplate(pet,createSubmitHandler(onEdit)));
    async function onEdit({name,breed,age,weight,image}) {
        debugger;
        if (name === "" || breed === "" || age === "" || weight === "" || image === "") {
            return alert(`All fields are required!`);
        }
        await put(`/data/pets/${id}`, {name,breed,age,weight,image});
        ctx.page.redirect(`/catalog/${id}`);
    }
}