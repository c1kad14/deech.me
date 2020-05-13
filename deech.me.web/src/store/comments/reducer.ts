import { ICommentsState, CommentTypes } from "./types"
import produce from "immer"
import { Reducer } from "redux"

const initialState: ICommentsState = {
    comments: [],
    paragraphId: -1
}

const CommentsReducer: Reducer<ICommentsState> = (state = initialState, action): ICommentsState => {
    return produce<ICommentsState>(state, draft => {
        switch (action.type) {
            case CommentTypes.COMMENT_ADDED:
                draft.comments.push(action.payload.comment)
                break
            case CommentTypes.COMMENTS_SHOW:
                draft.paragraphId = action.payload.paragraphId
                break
            case CommentTypes.COMMENTS_LOADED:
                draft.comments = action.payload.comments
                break
            case CommentTypes.COMMENTS_HIDE:
                draft = initialState
                break
            default:
                return state
        }
    })
}

export default {
    CommentsReducer
}