import {render, html, page} from '../api/lib.js';
import {getUserData} from "../api/util.js";
import {logout} from "../api/user.js";
const header = document.getElementsByTagName(`header`)[0];

const navTemplate = (user) => html`
    <nav>
        <section class="logo">
            <img src="/images/logo.png" alt="logo">
        </section>
        <ul>
            <!--Users and Guest-->
            <li><a href="/">Home</a></li>
            <li><a href="/catalog">Dashboard</a></li>
            ${!user ? html`<li><a href="/login">Login</a></li>
            <li><a href="/register">Register</a></li>` 
             : 
             html`<li><a href="/create">Create Postcard</a></li>
            <li><a @click="${onLogout}" href="javascript:void(0)">Logout</a></li>`}
        </ul>
    </nav>
`;
async function onLogout() {

    await logout();
    showNav();
    page.redirect(`/`)
}
export function showNav() {
    let user = getUserData();
    render(navTemplate(user), header);
}