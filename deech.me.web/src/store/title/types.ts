export enum TitleActionTypes {
    SET_FILTER = '@@title/SET_FILTER',
    RESET_FILTER = '@@title/RESET_FILTER',
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