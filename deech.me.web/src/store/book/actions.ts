import { BookTypes, IBook, ClearBook, SetBookId, SetBook, SetProgress } from "./types"

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