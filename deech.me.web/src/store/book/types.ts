import { ITitleInfo } from "../title/types"
import { Action } from "redux"

export enum BookTypes {
    CLEAR_BOOK = "@@book/CLEAR_BOOK",
    SET_BOOK = "@@book/SET_BOOK",
    SET_BOOK_ID = "@@book/SET_BOOK_ID",
    SET_PROGRESS = "@@book/SET_PROGRESS"
}

export interface IParagraph {
    id: number
    comments: number
    sequence: number
    type: string
    value: string
}

export interface IBook {
    title: ITitleInfo
    paragraphs: IParagraph[]
    file: string
}

export interface IBookState {
    readonly id?: string
    readonly book?: IBook
    readonly progress: number
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