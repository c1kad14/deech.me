import { Reducer } from "redux"
import produce from "immer"
import { IBookState, BookTypes } from "./types"

const initialState: IBookState = {
    id: undefined,
    book: undefined
}

const BookReducer: Reducer<IBookState> = (state = initialState, action): IBookState => {
    return produce<IBookState>(state, draft => {
        switch (action.type) {
            case BookTypes.SET_BOOK_ID:
                draft.id = action.payload.id
                break
            case BookTypes.SET_BOOK:
                draft.book = action.payload.book
                break
            case BookTypes.CLEAR_BOOK:
            default:
                return state
        }
    })
}

export default {
    BookReducer
}