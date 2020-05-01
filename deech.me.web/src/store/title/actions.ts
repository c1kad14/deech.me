import titleConstants from './constants'
import { action } from 'typesafe-actions'
import { TitleFilter, TitleInfo, TitleActionTypes } from './types'

export const setFilter = (filter: TitleFilter) => action(TitleActionTypes.SET_FILTER, filter)
export const resetFilter = () => action(TitleActionTypes.RESET_FILTER)
export const setTitles = (titles: TitleInfo[]) => action(TitleActionTypes.SET_TITLES, titles)
export const clearTitles = () => action(TitleActionTypes.CLEAR_TITLES)