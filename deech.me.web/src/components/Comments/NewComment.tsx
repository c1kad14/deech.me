import React, { useState } from "react"
import { useDispatch, useSelector } from "react-redux"
import { addComment } from "../../store/comments/actions"
import { IComment } from "../../store/comments/types"
import TextAreaAutoSize from "react-textarea-autosize"
import moment from "moment"
import { RootState } from "../../store/rootReducer"

type NewCommentProps = {
    paragraphId: number
    associated?: number
};

const NewComment: React.FC<NewCommentProps> = ({ paragraphId, associated }) => {
    const dispatch = useDispatch()
    const [comment, setComment] = useState("")
    const { username } = useSelector((state: RootState) => state.app)

    const addNewComment = () => {
        if (comment.trim() !== "" && username) {
            const newComment: IComment = {
                associated,
                paragraphId,
                date: moment().format("YYYY-MM-DD HH:mm"),
                value: comment,
                username: username
            }

            setComment("")
            dispatch(addComment(newComment))
        }
    }

    const commentInputChanged = (e: React.ChangeEvent<HTMLTextAreaElement>) => setComment(e.target.value);

    return username ? <div>
        <TextAreaAutoSize className="form-control comment-input-dark rounded borderless" name="new-comment" placeholder="Leave comment" value={comment} onChange={commentInputChanged} />
        <div className="justify-content-end d-flex mt-2">
            <input className="btn btn-outline-light btn-sm" type="button" name="add-comment" value="Add" onClick={addNewComment} />
        </div>
    </div> : <></>
}

export default NewComment