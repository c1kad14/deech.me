import React, { useEffect } from "react"
import { useHistory } from "react-router"
import Oidc from "oidc-client"

const Callback: React.FC = () => {
    const history = useHistory()

    useEffect(() => {
        console.log("Hello")
        const manager = new Oidc.UserManager({ response_mode: "query" })
        manager.signinRedirectCallback().then(function () {
            // history.push("/")


            manager.getUser().then(function (user) {
                if (user) {
                    console.log("User logged in", user.profile);
                }
                else {
                    console.log("User not logged in");
                }
            })
        }).catch(function (e) {
            console.error(e);
        });
    }, [])

    return <>yo?</>
}

export default Callback