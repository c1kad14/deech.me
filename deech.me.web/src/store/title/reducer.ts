import { Reducer } from 'redux'
import { TitleState, TitleTypes } from './types'
import produce from 'immer'

const initialState: TitleState = {
    filter: undefined,
    titles: []
}

export const TitileReducer: Reducer<TitleState> = (state = initialState, action): TitleState => {
    return produce<TitleState>(state, draft => {
        switch (action.type) {
            case TitleTypes.SET_FILTER:
                draft.filter = action.payload.filter
                break
            case TitleTypes.RESET_FILTER:
                draft.filter = undefined
                break
            case TitleTypes.SET_TITLES:
                draft.titles = action.payload.titles
                break
            case TitleTypes.CLEAR_TITLES:
                draft.titles = []
                break
            default:
                return state
        }
    })
}