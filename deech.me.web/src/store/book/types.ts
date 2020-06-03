import { ITitleInfo } from "../title/types"
import { Action } from "redux"

export enum BookTypes {
    CLEAR_BOOK = "@@book/CLEAR_BOOK",
    SET_BOOK = "@@book/SET_BOOK",
    SET_BOOK_ID = "@@book/SET_BOOK_ID",
    SET_PROGRESS = "@@book/SET_PROGRESS",
    SET_PARAGRAPH = "@@book/SET_PARAGRAPH",
    ADD_BOOKMARK = "@@book/ADD_BOOKMARK",
    DELETE_BOOKMARK = "@@book/DELETE_BOOKMARK",
    ADD_CITATION = "@@book/ADD_CITATION",
    DELETE_CITATION = "@@book/DELETE_CITATION",
    ADD_NOTE = "@@book/ADD_NOTE",
    DELETE_NOTE = "@@book/DELETE_NOTE",
    BOOKMARK_ADDED = "@@book/BOOKMARK_ADDED",
    CITATION_ADDED = "@@book/CITATION_ADDED",
    NOTE_ADDED = "@@book/NOTE_ADDED",
    BOOKMARK_DELETED = "@@book/BOOKMARK_DELETED",
    CITATION_DELETED = "@@book/CITATION_DELETED",
    NOTE_DELETED = "@@book/NOTE_DELETED",
    BOOKMARK_DELETE = "BOOKMARK_DELETE"
}

export interface IParagraph {
    id: number
    bookmark?: IBookmark
    citation?: ICitation
    comments: number
    note?: INote
    sequence: number
    type: string
    value: string

}

export interface IBook {
    title: ITitleInfo
    paragraphs: IParagraph[]
    file: string
}

export interface IBookmark {
    created: string
    paragraphId: number
    userId?: string
}

export interface ICitation {
    created: string
    paragraphId: number
    userId?: string
    value: string
}

export interface INote {
    created: string
    paragraphId: number
    userId?: string
    value: string
}

export interface IBookState {
    readonly id?: string
    readonly book?: IBook
    readonly progress: number
    readonly paragraphId: number
}

export interface SetBook extends Action {
    type: BookTypes.SET_BOOK
    payload: {
        book: IBook
    }
}

export interface SetBookId extends Action {
    type: BookTypes.SET_BOOK_ID
    payload: {
        id: string
    }
}

export interface SetProgress extends Action {
    type: BookTypes.SET_PROGRESS,
    payload: {
        progress: number
    }
}

export interface ClearBook extends Action {
    type: BookTypes.CLEAR_BOOK
}

export interface SetParagraph extends Action {
    type: BookTypes.SET_PARAGRAPH
    payload: {
        paragraphId: number
    }
}

export interface AddBookmark extends Action {
    type: BookTypes.ADD_BOOKMARK
    payload: {
        bookmark: IBookmark
    }
}

export interface BookmarkAdded extends Action {
    type: BookTypes.BOOKMARK_ADDED
    payload: {
        bookmark: IBookmark
    }
}

export interface DeleteBookmark extends Action {
    type: BookTypes.DELETE_BOOKMARK
    payload: {
        bookmark: IBookmark
    }
}

export interface BookmarkDeleted extends Action {
    type: BookTypes.BOOKMARK_DELETED
    payload: {
        bookmark: IBookmark
    }
}

export interface AddCitation extends Action {
    type: BookTypes.ADD_CITATION
    payload: {
        citation: ICitation
    }
}

export interface CitationAdded extends Action {
    type: BookTypes.CITATION_ADDED
    payload: {
        citation: ICitation
    }
}

export interface DeleteCitation extends Action {
    type: BookTypes.DELETE_CITATION
    payload: {
        citation: ICitation
    }
}

export interface CitationDeleted extends Action {
    type: BookTypes.CITATION_DELETED
    payload: {
        citation: ICitation
    }
}

export interface AddNote extends Action {
    type: BookTypes.ADD_NOTE
    payload: {
        note: INote
    }
}

export interface NoteAdded extends Action {
    type: BookTypes.NOTE_ADDED
    payload: {
        note: INote
    }
}

export interface DeleteNote extends Action {
    type: BookTypes.DELETE_NOTE
    payload: {
        note: INote
    }
}

export interface NoteDeleted extends Action {
    type: BookTypes.NOTE_DELETED
    payload: {
        note: INote
    }
}