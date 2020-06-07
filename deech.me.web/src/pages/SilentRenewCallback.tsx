import React, { useEffect } from "react"
import Oidc from "oidc-client"
import { useDispatch } from "react-redux"
import { userManagerSettings } from "../config"

const SilentRenewCallback: React.FC = () => {
    const dispatch = useDispatch()

    useEffect(() => {
        const mgr = new Oidc.UserManager(userManagerSettings)
        mgr.signinSilentCallback()
    }, [dispatch])

    return <></>
}

export default SilentRenewCallback