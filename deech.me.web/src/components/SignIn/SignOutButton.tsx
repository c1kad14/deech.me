import React from "react"
import Oidc from "oidc-client"
import "./signin.css"

export const SignOutButton: React.FC = () => {
    var config = {
        authority: "https://localhost:5050",
        client_id: "js",
        redirect_uri: "https://localhost:3000/callback",
        response_type: "code",
        scope: "openid profile api1",
        post_logout_redirect_uri: "https://localhost:3000/",
    }

    var mgr = new Oidc.UserManager(config)
    const signOutClick = async () => {
        await mgr.signoutRedirect()
    }

    return <div className="sign-out-button text-white pt-2" onClick={signOutClick}>
        Sign Out
        </div>
}