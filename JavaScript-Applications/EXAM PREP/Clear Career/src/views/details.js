import {html, nothing} from "../api/lib.js";
import {del, get} from "../api/api.js";
import {getLikes, getOwnLikes, like} from "../api/BONUS-donations.js";


const detailsTemplate = (offer, isUser, isOwner, canLike, likes, onDelete, onLike) => html`<!-- Details page -->
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
        <p>Applications: <strong id="applications">${likes}</strong></p>

        <!--Edit and Delete are only for creator-->
        ${detailsController(offer, isUser, isOwner, canLike, onDelete, onLike)}

    </div>
</section>`

function detailsController(offer, isUser, isOwner, canLike, onDelete, onLike) {
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
    if (isUser && canLike) {
        return html`
            <div id="action-buttons">
                <a @click="${onLike}" href="javascript:void(0)" id="apply-btn">Apply</a>
            </div>`
    }
}

export async function showDetails(ctx) {
    let id = ctx.params.id;

    const request = [
        get(`/data/offers/${id}`),
        getLikes(id),
    ]

    let isUser = Boolean(ctx.user);

    if (ctx.user) {
        request.push(getOwnLikes(id, ctx.user._id));
    }

    const [offer, likes, hasLiked] = await Promise.all(request);

    let isOwner = isUser && ctx.user._id === offer._ownerId;
    const canLike = !isOwner && hasLiked === 0;
    ctx.render(detailsTemplate(offer, isUser, isOwner, canLike, likes, onDelete, onLike));

    async function onDelete() {
        await del(`/data/offers/${id}`);
        ctx.page.redirect(`/catalog`);
    }

    async function onLike() {
        await like(id);
        ctx.page.redirect(`/catalog/${id}`);
    }
}
