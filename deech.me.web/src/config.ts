import { WebStorageStateStore } from "oidc-client"

export const domain = "http://192.168.50.204:5000"

export const userManagerSettings = {
    userStore: new WebStorageStateStore({ store: localStorage }),
    authority: "https://localhost:5050",
    client_id: "js",
    redirect_uri: "http://localhost:3000/sicb",
    response_type: "code",
    scope: "openid profile api1",
    post_logout_redirect_uri: "http://localhost:3000/socb"
}