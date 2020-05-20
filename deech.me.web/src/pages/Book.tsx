import React, { useEffect } from "react"
import { useDispatch, useSelector } from "react-redux"
import BookContent from "../components/BookContent"
import { setBookId, clearBook } from "../store/book/actions"
import { RouteComponentProps } from "react-router-dom"
import { Container } from "reactstrap"
import { RootState } from "../store/rootReducer"
import { Spinner } from "../components/Spinner"

interface BookParams {
    id: string
}

const Book: React.FC<RouteComponentProps<BookParams>> = ({ match }) => {
    const dispatch = useDispatch()
    const bookId = useSelector((state: RootState) => state.BookReducer.id)
    let { book } = useSelector((state: RootState) => state.BookReducer)
    const { id } = match.params
    let { loading } = useSelector((state: RootState) => state.AppReducer)

    useEffect(() => {
        if (!bookId) {
            dispatch(setBookId(id))
        }
        return () => {
            dispatch(clearBook())
        }
    }, [])

    if (!book || loading) {
        return <Spinner />
    }

    return <Container>
        <BookContent />
    </Container>
}

export default Book