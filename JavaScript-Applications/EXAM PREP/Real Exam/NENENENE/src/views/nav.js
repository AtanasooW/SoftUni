import {html, render, page} from "../api/lib.js";
import {getUserData} from "../api/util.js";
import {logout} from "../api/user.js";

let header = document.getElementsByTagName(`header`)[0];

let navBarTemplate = (isUser, onLogout) => html
    `
        <!-- Navigation -->
        <a id="logo" href="/"><img id="logo-img" src="./images/logo.png" alt=""/></a>

        <nav>
            <div>
                <a href="/catalog">Dashboard</a>
            </div>
            ${navController(isUser, onLogout)}
    `

function navController(isUser, onLogout) {
    if (isUser === false) {
        return html`
            <!-- Guest users -->
            <div class="guest">
                <a href="/login">Login</a>
                <a href="/register">Register</a>
            </div>
            </nav>
        `
    } else if (isUser) {
        return html`  <!-- Logged-in users -->
        <div class="user">
            <a href="/create">Add Album</a>
            <a @click="${onLogout}" href="javascript:void(0)">Logout</a>
        </div>`
    }
}

export function showNavBar() {
    let isUser = Boolean(getUserData());
    render(navBarTemplate(isUser, onLogout), header);

    async function onLogout() {
        await logout()
        showNavBar();
        page.redirect(`/catalog`);
    }
}
