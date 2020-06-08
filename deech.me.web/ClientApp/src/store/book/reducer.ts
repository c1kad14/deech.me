import { Reducer } from "redux"
import produce from "immer"
import { IBookState, BookTypes } from "./types"

const initialState: IBookState = {
    paragraphId: 0
}

const BookReducer: Reducer<IBookState> = (state = initialState, action): IBookState => {
    return produce<IBookState>(state, draft => {
        switch (action.type) {
            case BookTypes.SET_BOOK:
                draft.book = action.payload.book
                break
            case BookTypes.SET_PARAGRAPH:
                draft.paragraphId = action.payload.paragraphId
                break
            case BookTypes.CLEAR_BOOK:
                draft.paragraphId = 0
                draft.book = undefined
                break
            case BookTypes.BOOKMARK_ADDED:
                if (draft.book) {
                    if (!draft.book.bookmarks) {
                        draft.book.bookmarks = []
                    }
                    draft.book.bookmarks.push(action.payload.bookmark)
                }
                break
            case BookTypes.CITATION_ADDED:
                if (draft.book) {
                    if (!draft.book.citations) {
                        draft.book.citations = []
                    }
                    draft.book.citations.push(action.payload.citation)
                }
                break
            case BookTypes.NOTE_ADDED:
                if (draft.book) {
                    if (!draft.book.notes) {
                        draft.book.notes = []
                    }
                    draft.book.notes.push(action.payload.note)
                }
                break
            case BookTypes.BOOKMARK_DELETED:
                if (draft.book && draft.book.bookmarks) {
                    draft.book.bookmarks = draft.book.bookmarks.filter(b => b.paragraphId !== action.payload.bookmark.paragraphId)
                }
                break
            case BookTypes.CITATION_DELETED:
                if (draft.book && draft.book.citations) {
                    draft.book.citations = draft.book.citations.filter(c => c.id !== action.payload.citation.id)
                }
                break
            case BookTypes.NOTE_DELETED:
                if (draft.book && draft.book.notes) {
                    draft.book.notes = draft.book.notes.filter(n => n.paragraphId !== action.payload.note.paragraphId)
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