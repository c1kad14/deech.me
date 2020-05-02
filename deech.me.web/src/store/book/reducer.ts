import { Reducer } from 'redux'
import produce from 'immer'
import { BookState, BookTypes } from './types'

const initialState: BookState = {
    id: undefined,
    book: undefined
}

export const TitileReducer: Reducer<BookState> = (state = initialState, action): BookState => {
    return produce<BookState>(state, draft => {
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