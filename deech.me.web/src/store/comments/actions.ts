import { CommentTypes, IComment, AddComment, ShowComments, SetComments } from "./types"

export function addComment(comment: IComment): AddComment {
    return {
        type: CommentTypes.ADD_COMMENT,
        payload: {
            comment
        }
    }
}

export function showComments(paragraphId: number): ShowComments {
    return {
        type: CommentTypes.SHOW_COMMENTS,
        payload: {
            paragraphId
        }
    }
}

export function setComments(comments: IComment[]): SetComments {
    return {
        type: CommentTypes.SET_COMMENTS,
        payload: {
            comments
        }
    }
}