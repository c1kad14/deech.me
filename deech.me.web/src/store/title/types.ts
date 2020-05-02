import { Action } from "redux";

export enum TitleActionTypes {
    SET_FILTER = '@@title/SET_FILTER',
    RESET_FILTER = '@@title/RESET_FILTER',
    SEARCH_TITLES = '@@title/SEARCH_TITLES',
    SET_TITLES = '@@title/SET_TITLES',
    CLEAR_TITLES = '@@title/CLEAR_TITLES'
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
    type: TitleActionTypes.SET_FILTER
    payload: {
        filter: TitleFilter
    }
}

interface ResetFilter extends Action {
    type: TitleActionTypes.RESET_FILTER
}

interface SetTitles extends Action {
    type: TitleActionTypes.SET_TITLES
    payload: {
        titles: TitleInfo[]
    }
}

interface ClearTitles extends Action {
    type: TitleActionTypes.CLEAR_TITLES
}

interface SearchTitles extends Action {
    type: TitleActionTypes.SEARCH_TITLES
    payload: {
        filter: TitleFilter
    }
}

export type TitleActionType = SetFilter | ResetFilter | SetTitles | ClearTitles | SearchTitles