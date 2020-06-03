import { Reducer } from "redux"
import produce from "immer"
import { IBookState, BookTypes } from "./types"

const initialState: IBookState = {
    id: undefined,
    book: undefined,
    progress: 0,
    paragraphId: -1
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
            case BookTypes.SET_PARAGRAPH:
                draft.paragraphId = action.payload.paragraphId
                break
            case BookTypes.CLEAR_BOOK:
                draft.id = undefined
                draft.book = undefined
                break
            case BookTypes.BOOKMARK_ADDED:
                if (draft.book) {
                    draft.book.paragraphs.filter((p) => p.id === action.payload.bookmark.paragraphId)[0].bookmark = action.payload.bookmark
                }
                break
            case BookTypes.CITATION_ADDED:
                if (draft.book) {
                    draft.book.paragraphs.filter(p => p.id === action.payload.citation.paragraphId)[0].citation = action.payload.citation
                }
                break
            case BookTypes.NOTE_ADDED:
                if (draft.book) {
                    draft.book.paragraphs.filter(p => p.id === action.payload.note.paragraphId)[0].note = action.payload.note
                }
                break
            case BookTypes.BOOKMARK_DELETED:
                if (draft.book) {
                    draft.book.paragraphs.filter(p => p.id === action.payload.bookmark.paragraphId)[0].bookmark = undefined
                }
                break
            case BookTypes.CITATION_DELETED:
                if (draft.book) {
                    draft.book.paragraphs.filter(p => p.id === action.payload.citation.paragraphId)[0].citation = undefined
                }
                break
            case BookTypes.NOTE_DELETED:
                if (draft.book) {
                    draft.book.paragraphs.filter(p => p.id === action.payload.note.paragraphId)[0].note = undefined
                }
                break
            default:
                return state
        }
    })
}

export default {
    BookReducer
}