import { Action } from "redux"

export enum AppTypes {
    DEFAULT = "@@app/DEFAULT",
    LOADING = "@@app/LOADING",
    LOADED = "@@app/LOADED",
    ERROR = "@@app/ERROR"
}

export interface AppState {
    readonly loading: boolean
    readonly error?: string
}

interface SetLoading extends Action {
    type: AppTypes.LOADING
}

interface SetLoaded extends Action {
    type: AppTypes.LOADED
}

interface SetError extends Action {
    type: AppTypes.ERROR,
    paylaod: {
        error: string
    }
}

export type AppActionTypes = SetLoading | SetLoaded | SetError