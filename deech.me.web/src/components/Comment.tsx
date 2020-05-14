import React, { useState } from "react"
import { IComment } from "../store/comments/types"
import NewComment from "./NewComment"
import moment from "moment"

type CommentProps = {
    comment: IComment
}

const Comment: React.FC<CommentProps> = ({ comment }) => {
    const [replyOpen, setIsReplyOpen] = useState<boolean>(false)
    const reply = replyOpen && <NewComment paragraphId={comment.paragraphId} associated={comment.id} />

    return <div className="comment-container mt-1 p-2">
        <div>
            <span className="text-white rounded bg-success p-1">username </span>
            <span className="text-muted p-1">{moment(comment.date).fromNow()}</span>
        </div>
        <div className="text-light mt-1 pl-2">{comment.value}</div>
        <div className="justify-content-end d-flex mt-2">
            {!reply && <input className="btn btn-outline-light btn-sm" type="button" name="reply" value="Reply" onClick={() => setIsReplyOpen(!replyOpen)} />}
        </div>
        {reply}
    </div>
}

export default Comment