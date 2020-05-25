import { AppTypes, SetError, SetLoaded, SetLoading, SetUser, ClearUser } from "./types"

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

export function setUser(user: string): SetUser {
    return {
        type: AppTypes.SET_USER,
        payload: {
            user
        }
    }
}

export function clearUser(): ClearUser {
    return {
        type: AppTypes.CLEAR_USER
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