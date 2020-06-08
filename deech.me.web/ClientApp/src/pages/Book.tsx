import React, { useEffect } from "react"
import { useDispatch, useSelector } from "react-redux"
import BookContent from "../components/Book/BookContent"
import { getBook, clearBook } from "../store/book/actions"
import { RouteComponentProps } from "react-router-dom"
import { RootState } from "../store/rootReducer"
import { Spinner } from "../components/Shared/Spinner"

interface BookParams {
    id: string
}

const Book: React.FC<RouteComponentProps<BookParams>> = ({ match }) => {
    const dispatch = useDispatch()
    let { loading } = useSelector((state: RootState) => state.app)
    const { id } = match.params

    useEffect(() => {
        dispatch(getBook(parseInt(id)))
        return () => {
            dispatch(clearBook())
        }
    }, [dispatch, id])

    if (loading) {
        return <div className="text-center pt-5 mt-5"><Spinner /></div>
    }

    return <div className="container pt-3 book-root">
        <BookContent />
    </div>
}

export default Book