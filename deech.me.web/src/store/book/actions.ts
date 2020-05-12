import { BookTypes, IBook, ClearBook, SetBookId, SetBook } from "./types"

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