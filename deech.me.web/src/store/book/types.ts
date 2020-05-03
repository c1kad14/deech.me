import { TitleInfo } from "../title/types";
import { Action } from "redux";

export enum BookTypes {
    CLEAR_BOOK = "@@book/CLEAR_BOOK",
    SET_BOOK = "@@book/SET_BOOK",
    SET_BOOK_ID = "@@book/SET_BOOK_ID"
}

export interface Book {
    title: TitleInfo
    contents: string[]
    images: string[]
}

export interface BookState {
    readonly id?: number
    readonly book?: Book
}

interface SetBook extends Action {
    type: BookTypes.SET_BOOK
    payload: {
        book: Book
    }
}

interface SetBookId extends Action {
    type: BookTypes.SET_BOOK_ID
    payload: {
        id: number
    }
}

interface ClearBook extends Action {
    type: BookTypes.CLEAR_BOOK
}

export type BookActionTypes = SetBook | SetBookId | ClearBook