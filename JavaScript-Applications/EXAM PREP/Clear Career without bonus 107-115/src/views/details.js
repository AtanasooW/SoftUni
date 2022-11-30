import {html, nothing} from "../api/lib.js";
import {del, get} from "../api/api.js";


const detailsTemplate = (offer, isUser, isOwner, onDelete) => html`<!-- Details page -->
<section id="details">
    <div id="details-wrapper">
        <img id="details-img" src="${offer.imageUrl}" alt="example1"/>
        <p id="details-title">${offer.title}</p>
        <p id="details-category">
            Category: <span id="categories">${offer.category}</span>
        </p>
        <p id="details-salary">
            Salary: <span id="salary-number">${offer.salary}</span>
        </p>
        <div id="info-wrapper">
            <div id="details-description">
                <h4>Description</h4>
                <span>${offer.description}</span
                >
            </div>
            <div id="details-requirements">
                <h4>Requirements</h4>
                <span>${offer.requirements}</span
                >
            </div>
        </div>
        <p>Applications: <strong id="applications">1</strong></p>

        <!--Edit and Delete are only for creator-->
        ${detailsController(offer, isUser, isOwner, onDelete)}

    </div>
</section>`

function detailsController(offer, isUser, isOwner, onDelete) {
    if (isUser === false) {
        return nothing;
    }
    if (isOwner) {
        return html`
            <div id="action-buttons">
                <a href="/edit/${offer._id}" id="edit-btn">Edit</a>
                <a @click="${onDelete}" href="javascript:void(0)" id="delete-btn">Delete</a>
            </div>`
    }
    if (isUser) {
        return html`
            <div id="action-buttons">
                <a href="" id="apply-btn">Apply</a>
            </div>`
    }
}

export async function showDetails(ctx) {
    let id = ctx.params.id;
    let offer = await get(`/data/offers/${id}`);
    let isUser = Boolean(ctx.user);
    console.log(isUser);
    debugger;
    let isOwner = isUser && ctx.user._id === offer._ownerId;
    ctx.render(detailsTemplate(offer, isUser, isOwner, onDelete));

    async function onDelete() {
        await del(`/data/offers/${id}`);
        ctx.page.redirect(`/catalog`);
    }
}
