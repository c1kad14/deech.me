import React, { useEffect } from "react"
import { useHistory } from "react-router"
import Oidc from "oidc-client"
import { useDispatch } from "react-redux"
import { setAuth } from "../store/app/actions"
import { userManagerSettings } from "../config"

const SignInCallback: React.FC = () => {
    const history = useHistory()
    const dispatch = useDispatch()

    useEffect(() => {
        const mgr = new Oidc.UserManager(userManagerSettings)
        mgr.signinRedirectCallback().then((user) => {
            console.log(user)
            if (user.profile.name) {
                console.log(`User ${user.profile.name} logged in`)
                dispatch(setAuth(user.profile.name, user.access_token))
                history.push("/")
            }
            else {
                console.log("User not logged in")
                history.push("/")
            }
        }).catch(function (e) {
            console.error(e)
        })
    }, [])

    return <></>
}

export default SignInCallback