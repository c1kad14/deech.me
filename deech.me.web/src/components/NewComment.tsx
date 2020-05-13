import React, { useState } from "react"
import { useDispatch } from "react-redux"
import { addComment } from "../store/comments/actions"
import { IComment } from "../store/comments/types";

type NewCommentProps = {
    paragraphId: number
    associated?: number
};

const NewComment: React.FC<NewCommentProps> = ({ paragraphId, associated }) => {
    const dispatch = useDispatch()
    const [comment, setComment] = useState("")

    const addNewComment = () => {
        const newComment: IComment = {
            associated,
            paragraphId,
            date: new Date(),
            value: comment,
        }
        dispatch(addComment(newComment))
    }

    const commentInputChanged = (e: React.ChangeEvent<HTMLInputElement>) => setComment(e.target.value);

    return <div>
        <input type="text" name="new-comment" placeholder="Leave comment" onChange={commentInputChanged} />
        <input type="button" name="add-comment" value="Add" onClick={addNewComment} />
    </div>
}

export default NewComment