import React, { useEffect } from "react"
import { useHistory } from "react-router"
import Oidc from "oidc-client"
import { useDispatch } from "react-redux"
import { setUser } from "../store/app/actions"

const Callback: React.FC = () => {
    const history = useHistory()
    const dispatch = useDispatch()

    useEffect(() => {
        const manager = new Oidc.UserManager({ response_mode: "query" })
        manager.signinRedirectCallback().then(function () {
            manager.getUser().then(function (user) {
                if (user) {
                    console.log("User logged in", user)
                    if (user.profile.name) {
                        dispatch(setUser(user.profile.name))
                        history.push("/")
                    }
                }
                else {
                    console.log("User not logged in");
                }
            })
        }).catch(function (e) {
            console.error(e);
        });
    }, [])

    return <></>
}

export default Callback