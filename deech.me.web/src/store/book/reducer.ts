import { Reducer } from "redux"
import produce from "immer"
import { IBookState, BookTypes } from "./types"

const initialState: IBookState = {
    id: undefined,
    book: undefined,
    progress: 0
}

const BookReducer: Reducer<IBookState> = (state = initialState, action): IBookState => {
    return produce<IBookState>(state, draft => {
        switch (action.type) {
            case BookTypes.SET_BOOK_ID:
                draft.id = action.payload.id
                draft.book = undefined
                break
            case BookTypes.SET_BOOK:
                draft.book = action.payload.book
                break
            case BookTypes.SET_PROGRESS:
                draft.progress = action.payload.progress === 1 ? 0 : action.payload.progress
                break
            case BookTypes.CLEAR_BOOK:
                draft.id = undefined
                draft.book = undefined
                break
            default:
                return state
        }
    })
}

export default {
    BookReducer
}