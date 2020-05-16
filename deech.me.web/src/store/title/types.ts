import { Action } from "redux"

export enum TitleTypes {
    SET_FILTER = "@@title/SET_FILTER",
    RESET_FILTER = "@@title/RESET_FILTER",
    LOAD_TITLES = "@@title/LOAD_TITLES",
    LOAD_MORE_TITLES = "@@title/LOAD_MORE_TITLES",
    SET_TITLES = "@@title/SET_TITLES",
    CLEAR_TITLES = "@@title/CLEAR_TITLES",
    ADD_TITLES = "@@title/ADD_TITLES"
}

export interface ITitleFilter {
    author?: string
    title?: string
    language?: string
    genre?: string
}

export interface ITitleInfo {
    annotation?: string
    authors?: string[]
    cover?: string
    date?: string
    genres?: string[]
    id: string
    keywords?: string[]
    language?: string
    sourceLanguage?: string
    title?: string
    translators?: string[]
}

export interface ITitleState {
    readonly filter?: ITitleFilter
    readonly titles: ITitleInfo[]
}

export interface SetFilter extends Action {
    type: TitleTypes.SET_FILTER
    payload: {
        filter: ITitleFilter
    }
}

export interface ResetFilter extends Action {
    type: TitleTypes.RESET_FILTER
}

export interface SetTitles extends Action {
    type: TitleTypes.SET_TITLES
    payload: {
        titles: ITitleInfo[]
    }
}

export interface ClearTitles extends Action {
    type: TitleTypes.CLEAR_TITLES
}

export interface LoadTitles extends Action {
    type: TitleTypes.LOAD_TITLES
}

export interface LoadMoreTitles extends Action {
    type: TitleTypes.LOAD_MORE_TITLES
}

export interface AddTitles extends Action {
    type: TitleTypes.ADD_TITLES,
    payload: {
        titles: ITitleInfo[]
    }
}