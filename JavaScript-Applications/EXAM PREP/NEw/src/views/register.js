import {html} from "../api/lib.js";
import {createSubmitHandler} from "../api/util.js";
import {register} from "../api/user.js";

let registerTemplate = (onRegister) => html
    `
        <!-- Register Page (Only for Guest users) -->
        <section id="register">
            <div class="form">
                <h2>Register</h2>
                <form @submit="${onRegister}" class="login-form">
                    <input type="text" name="email" id="register-email" placeholder="email" />
                    <input type="password" name="password" id="register-password" placeholder="password" />
                    <input type="password" name="re-password" id="repeat-password" placeholder="repeat password" />
                    <button type="submit">register</button>
                    <p class="message">Already registered? <a href="#">Login</a></p>
                </form>
            </div>
        </section>
`
export function showRegister(ctx) {
    ctx.render(registerTemplate(createSubmitHandler(onRegister)));
    function onRegister(data) {
        if (data["email"] === "" || data["password"] === "" || data["re-password"] === ""){
            return alert(`All fields are required`);
        }
        if (data["password"] !== data["re-password"]){
            return alert(`Passwords does not match`);
        }
        register(data["email"], data["password"]);
        ctx.page.redirect(`/catalog`);
    }
}
