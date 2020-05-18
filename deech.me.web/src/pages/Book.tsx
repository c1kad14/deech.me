import React, { useEffect } from "react"
import { useDispatch, useSelector } from "react-redux"
import BookContent from "../components/BookContent"
import { setBookId, clearBook } from "../store/book/actions"
import { RouteComponentProps } from "react-router-dom"
import { Container } from "reactstrap"
import { RootState } from "../store/rootReducer"

interface BookParams {
    id: string
}

const Book: React.FC<RouteComponentProps<BookParams>> = ({ match }) => {
    const dispatch = useDispatch()
    const bookId = useSelector((state: RootState) => state.BookReducer.id)
    const { id } = match.params

    useEffect(() => {
        if (!bookId) {
            dispatch(setBookId(id))
        }
        return () => {
            dispatch(clearBook())
        }
    }, [])

    return <Container>
        <BookContent />
    </Container>
}

export default Book