import React from "react"
import Oidc from "oidc-client"
import { userManagerSettings } from "../../config"
import "./signin.css"

export const SignInButton: React.FC = () => {
    const signInClick = async () => {
        // var mgr = new Oidc.UserManager(userManagerSettings)
        // await mgr.signinRedirect()
    }

    return <div className="sign-in-button text-white pt-2" onClick={signInClick}>
        Sign In
    </div>
}