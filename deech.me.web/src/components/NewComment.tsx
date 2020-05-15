import React, { useState } from "react"
import { useDispatch } from "react-redux"
import { addComment } from "../store/comments/actions"
import { IComment } from "../store/comments/types"
import TextAreaAutoSize from "react-textarea-autosize"
import moment from "moment"

type NewCommentProps = {
    paragraphId: number
    associated?: number
};

const NewComment: React.FC<NewCommentProps> = ({ paragraphId, associated }) => {
    const dispatch = useDispatch()
    const [comment, setComment] = useState("")

    const addNewComment = () => {
        if (comment.trim() !== "") {
            const newComment: IComment = {
                associated,
                paragraphId,
                date: moment().format("YYYY-MM-DD HH:m"),
                value: comment,
            }

            setComment("")
            dispatch(addComment(newComment))
        }
    }

    const commentInputChanged = (e: React.ChangeEvent<HTMLTextAreaElement>) => setComment(e.target.value);

    return <div>
        <TextAreaAutoSize className="form-control comment-input-dark rounded borderless" name="new-comment" placeholder="Leave comment" value={comment} onChange={commentInputChanged} />
        <div className="justify-content-end d-flex mt-2">
            <input className="btn btn-outline-light btn-sm" type="button" name="add-comment" value="Add" onClick={addNewComment} />
        </div>
    </div>
}

export default NewComment