import {html, nothing} from "../api/lib.js";
import {getLikes, getOwnLikes, like} from "../api/BONUS-donations.js";
import {del,get} from "../api/api.js";

let detailsTemplate = (music, isUser, isOwner, canLike, likes, onLike,onDelete) => html
    `
        <!-- Details page -->
        <section id="details">
            <div id="details-wrapper">
                <p id="details-title">Album Details</p>
                <div id="img-wrapper">
                    <img src="${music.imageUrl}" alt="example1"/>
                </div>
                <div id="info-wrapper">
                    <p><strong>Band:</strong><span id="details-singer">${music.singer}</span></p>
                    <p>
                        <strong>Album name:</strong><span id="details-album">${music.album}</span>
                    </p>
                    <p><strong>Release date:</strong><span id="details-release">${music.release}</span></p>
                    <p><strong>Label:</strong><span id="details-label">${music.label}</span></p>
                    <p><strong>Sales:</strong><span id="details-sales">${music.sales}</span></p>
                </div>


                <div id="likes">Likes: <span id="likes-count">${likes}</span></div>
                ${detailsController(music, isUser, isOwner, canLike, onLike,onDelete)}
                <!--Edit and Delete are only for creator-->

            </div>
        </section>
    `

function detailsController(music, isUser, isOwner, canLike, onLike,onDelete) {
    if (isUser === false) {
        return nothing;
    }
    if (isOwner) {
        return html`
            <div id="action-buttons">

                <a href="/edit/${music._id}" id="edit-btn">Edit</a>
                <a @click="${onDelete}" href="javascript:void(0)" id="delete-btn">Delete</a>
            </div>
        `
    }
    if (isUser && canLike) {
        return html`
            <div id="action-buttons">
                <a @click="${onLike}" href="javascript:void(0)" id="like-btn">Like</a>
            </div>
        `
    }
}

export async function showDetails(ctx) {
    debugger;
    let id = ctx.params.id;

    const request = [
        get(`/data/albums/${id}`),
        getLikes(id)
    ]
    let isUser = Boolean(ctx.user)
console.log(ctx.user.id);
    if (ctx.user) {
        request.push(getOwnLikes(id, ctx.user._id));
    }

    let [music, likes, hasLiked] = await Promise.all(request);

    let isOwner = isUser && ctx.user._id === music._ownerId;
    debugger;
    let canLike = !isOwner && hasLiked === 0;

    ctx.render(detailsTemplate(music, isUser, isOwner, canLike, likes, onLike,onDelete))

    async function onLike() {
        await like(id);
        ctx.page.redirect(`/catalog/${id}`);

    }
   async function onDelete() {
        await del(`/data/albums/${id}`);
        ctx.page.redirect(`/catalog`)
    }
}
