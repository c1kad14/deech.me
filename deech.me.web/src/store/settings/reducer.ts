import { Reducer } from "redux"
import { ITextSettingsState, SettingsTypes } from "./types"
import produce from "immer"

const initialState: ITextSettingsState = {
    size: 1
}

const SettingsReducer: Reducer<ITextSettingsState> = (state = initialState, action): ITextSettingsState => {
    return produce<ITextSettingsState>(state, draft => {
        switch(action.type) {
            case SettingsTypes.INCREASE_TEXT:
                draft.size += 1
                break
            case SettingsTypes.DECREASE_TEXT:
                draft.size -= 1
                break
            default:
                return state
        }
    })
}

export default {
    SettingsReducer
}