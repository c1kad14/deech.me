import { Action } from "redux"

export enum AppTypes {
    DEFAULT = "@@app/DEFAULT",
    LOADING = "@@app/LOADING",
    LOADED = "@@app/LOADED",
    ERROR = "@@app/ERROR",
    MENU_TOGGLE = "@@app/MENU_TOGGLE",
    SET_USER = "@@app/SET_USER",
    CLEAR_USER = "@@app/CLEAR_USER"
}

export interface AppState {
    readonly loading: boolean
    readonly error?: string
    readonly username?: string
}

export interface SetLoading extends Action {
    type: AppTypes.LOADING
}

export interface SetLoaded extends Action {
    type: AppTypes.LOADED
}

export interface SetUser extends Action {
    type: AppTypes.SET_USER,
    payload: {
        username: string
    }
}

export interface ClearUser extends Action {
    type: AppTypes.CLEAR_USER
}

export interface SetError extends Action {
    type: AppTypes.ERROR,
    payload: {
        error: string
    }
}