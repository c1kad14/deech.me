import { TitleInfo } from "../title/types"
import { Action } from "redux"

export enum BookTypes {
    CLEAR_BOOK = "@@book/CLEAR_BOOK",
    SET_BOOK = "@@book/SET_BOOK",
    SET_BOOK_ID = "@@book/SET_BOOK_ID"
}

export interface Paragraph {
    sequence: number
    type: string
    value: string
    id: number
}

export interface Book {
    title: TitleInfo
    paragraphs: Paragraph[]
    file: string
}

export interface BookState {
    readonly id?: string
    readonly book?: Book
}

interface SetBook extends Action {
    type: BookTypes.SET_BOOK
    payload: {
        book: Book
    }
}

export interface SetBookId extends Action {
    type: BookTypes.SET_BOOK_ID
    payload: {
        id: string
    }
}

interface ClearBook extends Action {
    type: BookTypes.CLEAR_BOOK
}

export type BookActionTypes = SetBook | SetBookId | ClearBook