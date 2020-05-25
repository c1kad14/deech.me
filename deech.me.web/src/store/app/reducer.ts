import { Reducer } from "redux"
import { AppState, AppTypes } from "./types"
import produce from "immer"

const initialState: AppState = {
    loading: false,
    error: undefined,
    user: undefined
}

const AppReducer: Reducer<AppState> = (state = initialState, action): AppState => {
    return produce(state, draft => {
        switch (action.type) {
            case AppTypes.LOADING:
                draft.loading = true
                break
            case AppTypes.LOADED:
                draft.loading = false
                break
            case AppTypes.ERROR:
                draft.loading = false
                draft.error = action.payload.error
                break
            case AppTypes.SET_USER:
                draft.user = action.payload.user
                break
            case AppTypes.CLEAR_USER:
                draft.user = undefined
                break
            default:
                return state
        }
    })
}

export default {
    AppReducer
}