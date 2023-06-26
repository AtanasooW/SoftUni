import {html} from "../api/lib.js";
import {createSubmitHandler} from "../api/util.js";
import {get, put} from "../api/api.js";

const editTemplate = (offer, onEdit) => html`
    <!-- Edit Page (Only for logged-in users) -->
    <section id="edit">
        <div class="form">
            <h2>Edit Offer</h2>
            <form @submit="${onEdit}" class="edit-form">
                <input type="text" name="title" id="job-title" placeholder="Title" .value="${offer.title}"/>
                <input type="text" name="imageUrl" id="job-logo" placeholder="Company logo url"
                       .value="${offer.imageUrl}"/>
                <input type="text" name="category" id="job-category" placeholder="Category" .value="${offer.category}"/>
                <textarea id="job-description" name="description" placeholder="Description" rows="4" cols="50"
                          .value="${offer.description}"></textarea>
                <textarea id="job-requirements" name="requirements" placeholder="Requirements" rows="4" cols="50"
                          .value="${offer.requirements}"></textarea>
                <input type="text" name="salary" id="job-salary" placeholder="Salary" .value="${offer.salary}"/>

                <button type="submit">post</button>
            </form>
        </div>
    </section>`

export async function showEdit(ctx) {
    let id = ctx.params.id;
    let offer = await get(`/data/offers/${id}`)
    console.log(offer);
    ctx.render(editTemplate(offer, createSubmitHandler(onEdit)));

    async function onEdit({title, imageUrl, category, description, requirements, salary}) {
        if (title === "" || imageUrl === "" || category === "" || description === "" || requirements === "" || salary === "") {
            return alert(`All fields are required`);
        }
        await put(`/data/offers/${id}`, {title, imageUrl, category, description, requirements, salary});
        ctx.page.redirect(`/catalog/${id}`);
    }
}
