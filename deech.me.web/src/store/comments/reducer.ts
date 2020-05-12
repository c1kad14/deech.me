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
            case CommentTypes.ADD_COMMENT:
                draft.comments.push(action.payload.comment)
                break
            case CommentTypes.SHOW_COMMENTS:
                draft.paragraphId = action.payload.paragraphId
                break
            default:
                return state
        }
    })
}

export default {
    CommentsReducer
}