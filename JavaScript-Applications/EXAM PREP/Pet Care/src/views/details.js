import {html, nothing} from '../api/lib.js';
import {del, get} from '../api/api.js';
import {donate, getDonations, getOwnDonations} from "../api/BONUS-donations.js";

const detailsTemplate = (pet, hasUser, isOwner, canDonate, donations, onDelete,onDonation) => html`
    <!--Details Page-->
    <section id="detailsPage">
        <div class="details">
            <div class="animalPic">
                <img src="${pet.image}">
            </div>
            <div>
                <div class="animalInfo">
                    <h1>Name: ${pet.name}</h1>
                    <h3>Breed: ${pet.breed}</h3>
                    <h4>Age: ${pet.age}</h4>
                    <h4>Weight: ${pet.weight}</h4>
                    <h4 class="donation">Donation: ${donations * 100}$</h4>
                </div>
              ${petControler(pet, hasUser, isOwner, canDonate, onDelete,onDonation)}

            </div>
        </div>
    </section>
`;

function petControler(pet, hasUser, isOwner, canDonate, onDelete,onDonation) {
    if (hasUser === false) {
        return nothing;
    }
    if (canDonate) {
        return html`
            <div class="actionBtn">
              <a @click="${onDonation}" href="javascript:void(0)" className="donate">Donate</a>
            </div>`
    }
    if (isOwner) {
        return html`
            <div class="actionBtn">
                <a href="/edit/${pet._id}" class="edit">Edit</a>
                <a @click="${onDelete}" href="javascript:void(0)" class="remove">Delete</a>
            </div>`
    }
}

export async function showCatalogDetails(ctx) {
    const id = ctx.params.id;
    let hasUser = Boolean(ctx.user);
    const request = [
        get(`/data/pets/${id}`),
        getDonations(id),
    ]
    if (ctx.user) {
        request.push(getOwnDonations(id, ctx.user._id));
    }
    const [pet, donations, hasDonation] = await Promise.all(request);
    let isOwner = hasUser && ctx.user._id === pet._ownerId;
    let canDonate = !isOwner && hasDonation === 0;

    ctx.render(detailsTemplate(pet, hasUser, isOwner, canDonate, donations, onDelete,onDonation));

    async function onDelete() {
        const choice = confirm(`Are you sure you want to delete this pet?`);
        if (choice){

        await del(`/data/pets/${id}`);
        ctx.page.redirect(`/`);
        }
    }

    async function onDonation() {
debugger;
        await donate(id);
        ctx.page.redirect(`/catalog/${id}`);
    }
}
