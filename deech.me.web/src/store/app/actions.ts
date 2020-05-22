import { AppTypes, SetError, SetLoaded, SetLoading } from "./types"

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

export function setError(error: string): SetError {
    return {
        type: AppTypes.ERROR,
        paylaod: {
            error
        }
    }
}