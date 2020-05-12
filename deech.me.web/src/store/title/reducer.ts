import { Reducer } from "redux"
import { ITitleState, TitleTypes } from "./types"
import produce from "immer"

const initialState: ITitleState = {
    filter: undefined,
    titles: []
}

const TitleReducer: Reducer<ITitleState> = (state = initialState, action): ITitleState => {
    return produce<ITitleState>(state, draft => {
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

export default {
    TitleReducer
}