import React, { useEffect } from "react"
import { useHistory } from "react-router"
import Oidc from "oidc-client"
import { useDispatch } from "react-redux"
import { clearAuth } from "../store/app/actions"
import { userManagerSettings } from "../config"

const SignOutCallback: React.FC = () => {
    const history = useHistory()
    const dispatch = useDispatch()

    useEffect(() => {
        const mgr = new Oidc.UserManager(userManagerSettings)
        mgr.signoutRedirectCallback().then(() => {
            dispatch(clearAuth())
            history.push("/")
        }).catch(function (e) {
            console.error(e);
        });
    })

    return <></>
}

export default SignOutCallback