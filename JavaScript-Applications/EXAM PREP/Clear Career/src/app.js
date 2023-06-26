import {page,render} from './api/lib.js';
import {showNav} from './views/nav.js'
import {showLogin} from "./views/login.js";
import {showRegister} from "./views/register.js";
import {showHome} from "./views/home.js";
import {showCatalog} from "./views/catalog.js";
import {getUserData} from "./api/util.js";
import {showDetails} from "./views/details.js";
import {showCreate} from "./views/create.js";
import {showEdit} from "./views/edit.js";

let main = document.getElementsByTagName(`main`)[0];

page(decorateContext);
page(`/`,showHome);
page(`/catalog`, showCatalog);
page(`/catalog/:id`, showDetails);
page(`/edit/:id`, showEdit);
page(`/create`, showCreate);
page(`/login`, showLogin);
page(`/register`, showRegister);

page.start();
showNav();

function decorateContext(ctx,next) {
    ctx.render = renderMain;
    ctx.updateNav = showNav;
    ctx.user = getUserData();
    next();
}
function renderMain(content) {
    render(content,main)
}
