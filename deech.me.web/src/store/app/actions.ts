import { AppTypes, SetError, SetLoaded, SetLoading, SetAuth, ClearAuth } from "./types"

export function setLoading(): SetLoading {
    return {
        type: AppTypes.LOADING
    }
}

export function setLoaded(): SetLoaded {
    return {
        type: AppTypes.LOADED
    }
}

export function setAuth(username: string, access_token: string): SetAuth {
    return {
        type: AppTypes.SET_AUTH,
        payload: {
            username,
            access_token
        }
    }
}

export function clearAuth(): ClearAuth {
    return {
        type: AppTypes.CLEAR_AUTH
    }
}

export function setError(error: string): SetError {
    return {
        type: AppTypes.ERROR,
        payload: {
            error
        }
    }
}