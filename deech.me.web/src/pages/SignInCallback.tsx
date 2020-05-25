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
        mgr.signinRedirectCallback().then(() => {
            mgr.getUser().then((user) => {
                if (user) {
                    if (user.profile.name) {
                        console.log(`User ${user.profile.name} logged in`)
                        dispatch(setUser(user.profile.name))
                    }
                }
                else {
                    console.log("User not logged in");
                }
                history.push("/")
            })
        }).catch(function (e) {
            console.error(e);
        });
    }, [])

    return <></>
}

export default SignInCallback