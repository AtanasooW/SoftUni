import {render,page} from './api/lib.js';
import {showHome} from "./views/home.js";
import {showNav} from "./views/nav.js";
import {showLogin} from "./views/login.js";
import {showRegister} from "./views/register.js";
import {showCatalog} from "./views/catalog.js";
import {showCatalogDetails} from "./views/details.js";
import {getUserData} from "./api/util.js";
import {showCreate} from "./views/create.js";
import {editHome} from "./views/edit.js";

const main = document.getElementById(`content`);

page(decorateContext)
page(`/`, showHome);
page(`/catalog`, showCatalog);
page(`/catalog/:id`, showCatalogDetails);
page(`/edit/:id`, editHome);
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