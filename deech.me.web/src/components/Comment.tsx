import React, { useState } from "react"
import { IComment } from "../store/comments/types"
import NewComment from "./NewComment";

type CommentProps = {
    comment: IComment
}

const Comment: React.FC<CommentProps> = ({ comment }) => {
    const [replyOpen, setIsReplyOpen] = useState<boolean>(false)
    const reply = replyOpen && <NewComment paragraphId={comment.paragraphId} />

    return <div>
        <div>{comment.value}</div>
        <div>
            <input type="button" name="reply" value="Reply" onClick={() => setIsReplyOpen(!replyOpen)} />
        </div>

        {reply}
    </div>
}

export default Comment