import { BookTypes, IBook, ClearBook, SetBookId, SetBook, SetProgress, SetParagraph, IBookmark, AddBookmark, AddNote, AddCitation, ICitation, INote, DeleteBookmark, DeleteCitation, DeleteNote, BookmarkAdded, BookmarkDeleted, CitationAdded, CitationDeleted, NoteAdded, NoteDeleted } from "./types"

export function setBookId(id: string): SetBookId {
    return {
        type: BookTypes.SET_BOOK_ID,
        payload: {
            id
        }
    }
}

export function setBook(book: IBook): SetBook {
    return {
        type: BookTypes.SET_BOOK,
        payload: {
            book
        }
    }
}

export function clearBook(): ClearBook {
    return {
        type: BookTypes.CLEAR_BOOK
    }
}

export function setProgress(progress: number): SetProgress {
    return {
        type: BookTypes.SET_PROGRESS,
        payload: {
            progress
        }
    }
}

export function setParagraph(paragraphId: number): SetParagraph {
    return {
        type: BookTypes.SET_PARAGRAPH,
        payload: {
            paragraphId
        }
    }
}

export function addBookmark(bookmark: IBookmark): AddBookmark {
    return {
        type: BookTypes.ADD_BOOKMARK,
        payload: {
            bookmark
        }
    }
}

export function bookmarkAdded(bookmark: IBookmark): BookmarkAdded {
    return {
        type: BookTypes.BOOKMARK_ADDED,
        payload: {
            bookmark
        }
    }
}

export function deleteBookmark(bookmark: IBookmark): DeleteBookmark {
    return {
        type: BookTypes.DELETE_BOOKMARK,
        payload: {
            bookmark
        }
    }
}

export function bookmarkDeleted(bookmark: IBookmark): BookmarkDeleted {
    return {
        type: BookTypes.BOOKMARK_DELETED,
        payload: {
            bookmark
        }
    }
}

export function addCitation(citation: ICitation): AddCitation {
    return {
        type: BookTypes.ADD_CITATION,
        payload: {
            citation
        }
    }
}

export function citationAdded(citation: ICitation): CitationAdded {
    return {
        type: BookTypes.CITATION_ADDED,
        payload: {
            citation
        }
    }
}

export function citationDeleted(citation: ICitation): CitationDeleted {
    return {
        type: BookTypes.CITATION_DELETED,
        payload: {
            citation
        }
    }
}

export function addNote(note: INote): AddNote {
    return {
        type: BookTypes.ADD_NOTE,
        payload: {
            note
        }
    }
}

export function noteAdded(note: INote): NoteAdded {
    return {
        type: BookTypes.NOTE_ADDED,
        payload: {
            note
        }
    }
}

export function deleteNote(note: INote): DeleteNote {
    return {
        type: BookTypes.DELETE_NOTE,
        payload: {
            note
        }
    }
}

export function noteDeleted(note: INote): NoteDeleted {
    return {
        type: BookTypes.NOTE_DELETED,
        payload: {
            note
        }
    }
}