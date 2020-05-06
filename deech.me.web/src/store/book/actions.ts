import { BookTypes, BookActionTypes, Book } from "./types"

export function setBookId(id: string): BookActionTypes {
    return {
        type: BookTypes.SET_BOOK_ID,
        payload: {
            id
        }
    }
}

export function setBook(book: Book): BookActionTypes {
    return {
        type: BookTypes.SET_BOOK,
        payload: {
            book
        }
    }
}

export function clearBook(): BookActionTypes {
    return {
        type: BookTypes.CLEAR_BOOK
    }
}