import { Action } from "redux"

export enum TitleTypes {
    SET_FILTER = "@@title/SET_FILTER",
    RESET_FILTER = "@@title/RESET_FILTER",
    SEARCH_TITLES = "@@title/SEARCH_TITLES",
    SET_TITLES = "@@title/SET_TITLES",
    CLEAR_TITLES = "@@title/CLEAR_TITLES"
}

export interface TitleFilter {
    author?: string
    title?: string
    language?: string
    genre?: string
}

export interface TitleInfo {
    annotation?: string
    authors?: string[]
    cover?: string
    date?: Date
    genres?: string[]
    id?: string
    keywords?: string[]
    language?: string
    src_language?: string
    title?: string
    translators?: string[]
}

export interface TitleState {
    readonly filter?: TitleFilter
    readonly titles?: TitleInfo[]
}

interface SetFilter extends Action {
    type: TitleTypes.SET_FILTER
    payload: {
        filter: TitleFilter
    }
}

interface ResetFilter extends Action {
    type: TitleTypes.RESET_FILTER
}

interface SetTitles extends Action {
    type: TitleTypes.SET_TITLES
    payload: {
        titles: TitleInfo[]
    }
}

interface ClearTitles extends Action {
    type: TitleTypes.CLEAR_TITLES
}

interface SearchTitles extends Action {
    type: TitleTypes.SEARCH_TITLES
    payload: {
        filter: TitleFilter
    }
}

export type TitleActionTypes = SetFilter | ResetFilter | SetTitles | ClearTitles | SearchTitles