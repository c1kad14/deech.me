import React from "react"
import { useSelector } from "react-redux"
import { RootState } from "../store/rootReducer"
import { Spinner } from "./Spinner"
import BookComment from "./Comment"
import NewComment from "./NewComment"

const CommentsSection: React.FC = () => {
    let { comments, paragraphId } = useSelector((state: RootState) => state.comments)
    let { loading } = useSelector((state: RootState) => state.app)

    if (!comments || loading) {
        return <Spinner />
    }

    const commentsJSX = comments.map(comment => <BookComment key={comment.id} comment={comment} />)

    return <div className="mb-3">
        <NewComment paragraphId={paragraphId} />
        <div className="h-divider"></div>
        {commentsJSX}
    </div>
}

export default CommentsSection