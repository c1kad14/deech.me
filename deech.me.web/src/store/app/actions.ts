import { action } from 'typesafe-actions'
import { AppActionTypes, AppState } from './types'

export const loading = () => action(AppActionTypes.LOADING)
export const loaded = () => action(AppActionTypes.LOADED)
export const error = (error: string) => action(AppActionTypes.ERROR, error)