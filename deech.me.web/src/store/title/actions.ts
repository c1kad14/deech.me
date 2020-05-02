import { action } from 'typesafe-actions'
import { TitleFilter, TitleInfo, TitleActionTypes, TitleActionType } from './types'
import { Action } from 'redux'

// const setFilter = (filter: TitleFilter) => action(TitleActionTypes.SET_FILTER, filter)
// const resetFilter = () => action(TitleActionTypes.RESET_FILTER)
// const setTitles = (titles: TitleInfo[]) => action(typeof TitleActionTypes.SET_TITLES, titles)
// const clearTitles = () => action(TitleActionTypes.CLEAR_TITLES)

export function setFilter(filter: TitleFilter): TitleActionType {
    return {
        type: TitleActionTypes.SET_FILTER,
        payload: {
            filter
        }
    }
}

export function resetFilter(): TitleActionType {
    return {
        type: TitleActionTypes.RESET_FILTER
    }
}

export function setTitles(titles: TitleInfo[]): TitleActionType {
    return {
        type: TitleActionTypes.SET_TITLES,
        payload: {
            titles
        }
    }
}

export function clearTitles(): TitleActionType {
    return {
        type: TitleActionTypes.CLEAR_TITLES
    }
}

export function searchTitles(filter: TitleFilter): TitleActionType {
    return {
        type: TitleActionTypes.SEARCH_TITLES,
        payload: {
            filter
        }
    }
}