import { WebStorageStateStore } from "oidc-client"

export const domain = "http://localhost:5000"

export const userManagerSettings = {
    userStore: new WebStorageStateStore({ store: localStorage }),
    authority: "https://localhost:5050",
    client_id: "js",
    redirect_uri: "http://localhost:3000/sicb",
    response_type: "code",
    scope: "openid profile api1",
    post_logout_redirect_uri: "http://localhost:3000/socb",
    automaticSilentRenew: true,
    silent_redirect_uri: "http://localhost:3000/renew" 
}