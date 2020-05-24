import React from "react"
import "./signin.css"
import Oidc from "oidc-client";

export const SignInButton: React.FC = () => {
    var config = {
        authority: "https://localhost:5050",
        client_id: "js",
        redirect_uri: "https://localhost:3000/callback",
        response_type: "code",
        scope: "openid profile api1",
        post_logout_redirect_uri: "https://localhost:3000/",
    }

    var mgr = new Oidc.UserManager(config)

    const signInClick = async () => {
        await mgr.signinRedirect()
    }

    return <div className="sign-in-button text-white pt-2" onClick={signInClick}>
        Sign In
    </div>
}