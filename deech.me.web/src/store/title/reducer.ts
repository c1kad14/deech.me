import { Reducer } from "redux"
import { ITitleState, TitleTypes } from "./types"
import produce from "immer"

const initialState: ITitleState = {
    filter: undefined,
    titles: [],
    hasMore: true
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
            case TitleTypes.ADD_TITLES:
                if(action.payload.titles.length > 0) {
                    draft.titles.push(...action.payload.titles)
                } else {
                    draft.hasMore = false
                }
                break
            case TitleTypes.CLEAR_TITLES:
                draft.titles = []
                draft.hasMore = true
                break
            default:
                return state
        }
    })
}

export default {
    TitleReducer
}