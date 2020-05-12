import React from "react"
import { useSelector } from "react-redux"
import { RootState } from "../store/rootReducer"
import { Spinner } from "./Spinner"
import BookComment from "./BookComment"
import NewComment from "./NewComment"

const CommentsSection: React.FC = () => {
    let { comments, paragraphId } = useSelector((state: RootState) => state.CommentsReducer)
    let { loading } = useSelector((state: RootState) => state.AppReducer)

    if (!comments || loading) {
        return <Spinner />
    }

    const commentsJSX = comments.map(comment => <BookComment key={comment.id} comment={comment} />)

    return <>
        <NewComment paragraphId={paragraphId} />
        <div className="h-divider"></div>
        {commentsJSX}
    </>
}

export default CommentsSection