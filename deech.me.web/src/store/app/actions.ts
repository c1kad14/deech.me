import { AppActionTypes, AppTypes } from "./types"

export function setLoading(): AppActionTypes {
    return {
        type: AppTypes.LOADING
    }
}

export function setLoaded(): AppActionTypes {
    return {
        type: AppTypes.LOADED
    }
}

export function setError(error: string): AppActionTypes {
    return {
        type: AppTypes.ERROR,
        paylaod: {
            error
        }
    }
}