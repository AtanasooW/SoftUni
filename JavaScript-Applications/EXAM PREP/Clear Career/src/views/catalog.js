import {html} from "../api/lib.js";
import {get} from "../api/api.js";

const catalogTemplate = (offers) => html`
    <!-- Dashboard page -->
    <section id="dashboard">
        <h2>Job Offers</h2>
        ${offers.length === 0 ? html`<h2>No offers yet.</h2>` : offers.map(x => offerTemplate(x))}
    </section>`
function offerTemplate(offer) {
    return html`
    <div class="offer">
        <img src="${offer.imageUrl}" alt="example1" />
        <p>
            <strong>Title: </strong><span class="title">${offer.title}</span>
        </p>
        <p><strong>Salary:</strong><span class="salary">${offer.salary}</span></p>
        <a class="details-btn" href="/catalog/${offer._id}">Details</a>
    </div>`
}
export async function showCatalog(ctx) {
    let offers = await get(`/data/offers?sortBy=_createdOn%20desc`);
    ctx.render(catalogTemplate(offers));
}
