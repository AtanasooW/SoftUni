import {html, render, page} from "../api/lib.js";
import {getUserData} from "../api/util.js";
import {logout} from "../api/user.js";

let header = document.getElementsByTagName(`header`)[0];

const navTemplate = (user, navControler) => html`
    <!-- Navigation -->
    <a id="logo" href="/"
    ><img id="logo-img" src="./images/logo.jpg" alt=""/></a>
    <nav>
        <div>
            <a href="/catalog">Dashboard</a>
        </div>
        ${navControler(user)}
    </nav>`;

function navController(user) {
    if (user) {
        return html` <!-- Logged-in users -->
        <div class="user">
            <a href="/create">Create Offer</a>
            <a @click="${onLogout}" href="javascript:void(0)">Logout</a>
        </div>`
    }
    return html`<!-- Guest users -->
    <div class="guest">
        <a href="/login">Login</a>
        <a href="/register">Register</a>
    </div>`
}

async function onLogout() {
    await logout();
    showNav();
    page.redirect(`/catalog`);//TO CATALAG
}

export function showNav() {
    let user = getUserData();

    render(navTemplate(user, navController), header)
}