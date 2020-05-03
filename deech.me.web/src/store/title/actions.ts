import { TitleFilter, TitleInfo, TitleTypes, TitleActionTypes } from "./types"

export function setFilter(filter: TitleFilter): TitleActionTypes {
    return {
        type: TitleTypes.SET_FILTER,
        payload: {
            filter
        }
    }
}

export function resetFilter(): TitleActionTypes {
    return {
        type: TitleTypes.RESET_FILTER
    }
}

export function setTitles(titles: TitleInfo[]): TitleActionTypes {
    return {
        type: TitleTypes.SET_TITLES,
        payload: {
            titles
        }
    }
}

export function clearTitles(): TitleActionTypes {
    return {
        type: TitleTypes.CLEAR_TITLES
    }
}

export function searchTitles(title: string): TitleActionTypes {
    return {
        type: TitleTypes.SEARCH_TITLES,
        payload: {
            title
        }
    }
}