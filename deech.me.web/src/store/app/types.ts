import { Action } from "redux"

export enum AppTypes {
    DEFAULT = "@@app/DEFAULT",
    LOADING = "@@app/LOADING",
    LOADED = "@@app/LOADED",
    ERROR = "@@app/ERROR",
    MENU_TOGGLE = "@@app/MENU_TOGGLE",
}

export interface AppState {
    readonly loading: boolean
    readonly error?: string
}

export interface SetLoading extends Action {
    type: AppTypes.LOADING
}

export interface SetLoaded extends Action {
    type: AppTypes.LOADED
}

export interface SetError extends Action {
    type: AppTypes.ERROR,
    paylaod: {
        error: string
    }
}