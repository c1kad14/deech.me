import { Action } from "redux"

export enum CommentTypes {
    ADD_COMMENT = "@@comments/ADD_COMMENT",
    SHOW_COMMENTS = "@@comments/SHOW_COMMENTS",
    SET_COMMENTS = "@@comments/SET_COMMENTS"
}

export interface IComment {
    id?: number
    text: string
    paragraphId: number
    associated?: number
}

export interface ICommentsState {
    readonly paragraphId: number
    readonly comments: IComment[]
}

export interface SetComments {
    type: CommentTypes.SET_COMMENTS
    payload: {
        comments: IComment[]
    }
}

export interface AddComment extends Action {
    type: CommentTypes.ADD_COMMENT
    payload: {
        comment: IComment
    }
}

export interface ShowComments extends Action {
    type: CommentTypes.SHOW_COMMENTS
    payload: {
        paragraphId: number
    }
}