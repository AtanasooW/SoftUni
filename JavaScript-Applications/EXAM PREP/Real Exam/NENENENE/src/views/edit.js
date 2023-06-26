import {html} from "../api/lib.js";
import {put,get} from "../api/api.js";
import {createSubmitHandler} from "../api/util.js";

let editTemplate = (music,onEdit) => html
    `
        <!-- Edit Page (Only for logged-in users) -->
        <section id="edit">
            <div class="form">
                <h2>Edit Album</h2>
                <form @submit="${onEdit}" class="edit-form">
                    <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" .value="${music.singer}"/>
                    <input type="text" name="album" id="album-album" placeholder="Album" .value="${music.album}"/>
                    <input type="text" name="imageUrl" id="album-img" placeholder="Image url" .value="${music.imageUrl}"/>
                    <input type="text" name="release" id="album-release" placeholder="Release date" .value="${music.release}"/>
                    <input type="text" name="label" id="album-label" placeholder="Label" .value="${music.label}"/>
                    <input type="text" name="sales" id="album-sales" placeholder="Sales" .value="${music.sales}"/>

                    <button type="submit">post</button>
                </form>
            </div>
        </section>
    `

export async function showEdit(ctx) {
    let id = ctx.params.id;
    let music = await get(`/data/albums/${id}`);
    ctx.render(editTemplate(music, createSubmitHandler(onEdit)));

    async function onEdit({singer,album,imageUrl,release,label,sales}) {
        if (singer === "" || album === "" || imageUrl === "" || release === "" || label === "" || sales === "") {
            return alert(`All fields are required`);
        }
        await put(`/data/albums/${id}`, {singer, album, imageUrl, release, label, sales});
        ctx.page.redirect(`/catalog`);
    }
}
