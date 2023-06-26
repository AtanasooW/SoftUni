import {html} from '../api/lib.js';
import {get} from '../api/api.js';

const catalogTemplate = (data) => html`
    <!--Dashboard-->
    <section id="dashboard">
        <h2 class="dashboard-title">Services for every animal</h2>
        <div class="animals-dashboard">
            ${data.length === 0 ? html`
            <div>
                <p class="no-pets">No pets in dashboard</p>
            </div>`  
            : data.map(x => petTemplate(x))}
            
            
            <!--If there is no pets in dashboard-->
            
        </div>
    </section>
`;
function petTemplate(pet) {
    return html`
        <div class="animals-board">
        <article class="service-img">
            <img class="animal-image-cover" src="${pet.image}">
        </article>
        <h2 class="name">${pet.name}</h2>
        <h3 class="breed">${pet.breed}</h3>
        <div class="action">
            <a class="btn" href="/catalog/${pet._id}">Details</a>
        </div>
    </div>`
}
export async function showCatalog(ctx) {
    let data = await get(`/data/pets?sortBy=_createdOn%20desc&distinct=name`);
    ctx.render(catalogTemplate(data));
}