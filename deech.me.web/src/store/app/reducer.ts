import { Reducer } from 'redux'
import { AppState, AppActionTypes } from './types'
import produce from 'immer'

const initialState: AppState = {
    loading: false,
    error: undefined
}

const reducer: Reducer<AppState> = (state = initialState, action): AppState => {
    return produce(state, draft => {
        switch (action.type) {
            case AppActionTypes.LOADING:
                draft.loading = true
                break;
            case AppActionTypes.LOADED:
                draft.loading = false
                break;
            case AppActionTypes.ERROR:
                draft.loading = false
                draft.error = action.payload
                break;
            default:
                return state;
        }
    });
}

export { reducer as AppReducer }