import {page,render} from './api/lib.js';
import {getUserData} from "./api/util.js";
import {showHome} from "./views/home.js";
import {showNavBar} from "./views/nav.js";
import {showLogin} from "./views/login.js";
import {showRegister} from "./views/register.js";
import {showCatalog} from "./views/catalog.js";
import {showDetails} from "./views/details.js";


let main = document.getElementsByTagName(`main`)[0];

page(prepareContext)
page(`/`, showHome)
page(`/catalog`, showCatalog)
page(`/catalog/:id`, showDetails)
page(`/edit/:id`, () => console.log('edit'))
page(`/create`, () => console.log('create'))
page(`/login`, showLogin)
page(`/register`, showRegister)

page.start();
showNavBar();
function prepareContext(ctx,next) {

ctx.render = renderMain;
ctx.user = getUserData;
ctx.updateNav = showNavBar;

next();
}


function renderMain(content) {
render(content,main);
}