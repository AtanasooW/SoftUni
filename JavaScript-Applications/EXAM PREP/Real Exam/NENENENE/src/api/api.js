import {getUserData} from "./util.js";

const hostName = `http://localhost:3030`

async function request(method, url, data) {
    const options = {
        method,
        headers: {}
    };
    if (data !== undefined) {
        options.headers[`Content-Type`] = `application/json`;
        options.body = JSON.stringify(data);
    }
    const user = getUserData();
    if (user) {
        options.headers [`X-Authorization`] = user.accessToken ;
    }
    try {
        const response = await fetch(hostName + url, options);
        if (response.status === 204) {
            return response;
        }
        const result = await response.json();
        if (response.ok == false) {
            throw new Error(result.message);
        }
        return result;

    } catch (Error) {
        alert(Error.message);
        throw Error;
    }
}

export const get = request.bind(null, "GET");
export const post = request.bind(null, "POST");
export const put = request.bind(null, "PUT");
export const del = request.bind(null, "DELETE");