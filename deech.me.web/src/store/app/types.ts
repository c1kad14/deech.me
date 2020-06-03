import { Action } from "redux"

export enum AppTypes {
    DEFAULT = "@@app/DEFAULT",
    LOADING = "@@app/LOADING",
    LOADED = "@@app/LOADED",
    ERROR = "@@app/ERROR",
    MENU_TOGGLE = "@@app/MENU_TOGGLE",
    SET_AUTH = "@@app/SET_AUTH",
    CLEAR_AUTH = "@@app/CLEAR_AUTH"
}

export interface AppState {
    readonly loading: boolean
    readonly error?: string
    readonly username?: string
    readonly access_token?: string
}

export interface SetLoading extends Action {
    type: AppTypes.LOADING
}

export interface SetLoaded extends Action {
    type: AppTypes.LOADED
}

export interface SetAuth extends Action {
    type: AppTypes.SET_AUTH,
    payload: {
        username: string,
        access_token: string
    }
}

export interface ClearAuth extends Action {
    type: AppTypes.CLEAR_AUTH
}

export interface SetError extends Action {
    type: AppTypes.ERROR,
    payload: {
        error: string
    }
}