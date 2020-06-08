import React from "react"
import Oidc from "oidc-client"
import { userManagerSettings } from "../../config"
import "./signin.css"

export const SignOutButton: React.FC = () => {
    const signOutClick = () => {
        // var mgr = new Oidc.UserManager(userManagerSettings)
        // mgr.signoutRedirect()
    }

    return <div className="sign-out-button text-white pt-2" onClick={signOutClick}>
        Sign Out
        </div>
}