import { Action } from "redux"

export enum TitleTypes {
    SET_FILTER = "@@title/SET_FILTER",
    RESET_FILTER = "@@title/RESET_FILTER",
    SEARCH_TITLES = "@@title/SEARCH_TITLES",
    SET_TITLES = "@@title/SET_TITLES",
    CLEAR_TITLES = "@@title/CLEAR_TITLES"
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
    readonly titles?: ITitleInfo[]
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

export interface SearchTitles extends Action {
    type: TitleTypes.SEARCH_TITLES
    payload: {
        title: string
    }
}