import { Action } from "redux"

export enum CommentTypes {
    COMMENT_ADD = "@@comments/COMMENT_ADD",
    COMMENT_ADDED = "@@comments/COMMENT_ADDED",
    COMMENTS_SHOW = "@@comments/COMMENTS_SHOW",
    COMMENTS_HIDE = "@@comments/COMMENTS_HIDE",
    COMMENTS_LOADED = "@@comments/COMMENTS_LOADED"
}

export interface IComment {
    associated?: number
    date: string
    id?: number
    value: string
    paragraphId: number
    username: string
}

export interface ICommentsState {
    readonly paragraphId: number
    readonly comments: IComment[]
}

export interface AddComment extends Action {
    type: CommentTypes.COMMENT_ADD
    payload: {
        comment: IComment
    }
}

export interface CommentAdded extends Action {
    type: CommentTypes.COMMENT_ADDED
    payload: {
        comment: IComment
    }
}

export interface ShowComments extends Action {
    type: CommentTypes.COMMENTS_SHOW
    payload: {
        paragraphId: number
    }
}

export interface HideComments extends Action {
    type: CommentTypes.COMMENTS_HIDE
}

export interface SetComments {
    type: CommentTypes.COMMENTS_LOADED
    payload: {
        comments: IComment[]
    }
}