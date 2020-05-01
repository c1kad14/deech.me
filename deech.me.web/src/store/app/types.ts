export enum AppActionTypes {
    DEFAULT = '@@app/DEFAULT',
    LOADING = '@@app/LOADING',
    LOADED = '@@app/LOADED',
    ERROR = '@@app/ERROR'
}

export interface AppState {
    readonly loading: boolean
    readonly error?: string
}