import { Reducer } from 'redux'
import { TitleState, TitleInfo, TitleActionTypes } from './types'
import produce from 'immer'

const initialState: TitleState = {
    filter: undefined,
    titles: []
}

const reducer: Reducer<TitleState> = (state = initialState, action): TitleState => {
    return produce<TitleState>(state, draft => {
        switch (action.type) {
            case TitleActionTypes.SET_FILTER:
                draft.filter = action.payload
                break;
            case TitleActionTypes.RESET_FILTER:
                draft.filter = undefined;
                break;
            case TitleActionTypes.SET_TITLES:
                draft.titles = action.payload
                break;
            case TitleActionTypes.CLEAR_TITLES:
                draft.titles = [];
                break;
            default:
                return state;
        }
    });
}

export { reducer as TitileReducer }