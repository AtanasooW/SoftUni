import {html} from "../api/lib.js";
import {get} from "../api/api.js";

let catalogTemplate = (data,cardTemplate) => html
    `
        <!-- Dashboard page -->
        <section id="dashboard">
            <h2>Albums</h2>
            <ul class="card-wrapper">
                ${data.length === 0 ? html`<h2>There are no albums added yet.</h2>` : data.map(x => cardTemplate(x))}
                <!-- Display a li with information about every post (if any)-->
                
                
            </ul>

            <!-- Display an h2 if there are no posts -->
            
        </section>
`
function cardTemplate(music) {
return html`
    <li class="card">
    <img src="${music.imageUrl}" alt="travis" />
    <p>
        <strong>Singer/Band: </strong><span class="singer">${music.singer}</span>
    </p>
    <p>
        <strong>Album name: </strong><span class="album">${music.album}</span>
    </p>
    <p><strong>Sales:</strong><span class="sales">${music.sales}</span></p>
    <a class="details-btn" href="/catalog/${music._id}">Details</a>
</li>`
}
export async function showCatalog(ctx) {
    let data = await get(`/data/albums?sortBy=_createdOn%20desc`);
    ctx.render(catalogTemplate(data,cardTemplate));
}
