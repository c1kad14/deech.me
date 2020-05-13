import { CommentTypes, IComment, AddComment, ShowComments, SetComments, CommentAdded, HideComments } from "./types"

export function addComment(comment: IComment): AddComment {
    return {
        type: CommentTypes.COMMENT_ADD,
        payload: {
            comment
        }
    }
}

export function commentAdded(comment: IComment): CommentAdded {
    return {
        type: CommentTypes.COMMENT_ADDED,
        payload: {
            comment
        }
    }
}

export function showComments(paragraphId: number): ShowComments {
    return {
        type: CommentTypes.COMMENTS_SHOW,
        payload: {
            paragraphId
        }
    }
}

export function setComments(comments: IComment[]): SetComments {
    return {
        type: CommentTypes.COMMENTS_LOADED,
        payload: {
            comments
        }
    }
}

export function hideComments(comments: IComment[]): HideComments {
    return {
        type: CommentTypes.COMMENTS_HIDE
    }
}