import React, { useEffect } from "react"
import { useHistory } from "react-router"
import Oidc from "oidc-client"
import { useDispatch } from "react-redux"
import { setUser } from "../store/app/actions"
import { userManagerSettings } from "../config"

const SignInCallback: React.FC = () => {
    const history = useHistory()
    const dispatch = useDispatch()

    useEffect(() => {
        const mgr = new Oidc.UserManager(userManagerSettings)
        mgr.signinRedirectCallback().then((user) => {
            console.log(user)
            if (user) {
                console.log(`User ${user.profile.sub} logged in`)
                dispatch(setUser(user.profile.sub))
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