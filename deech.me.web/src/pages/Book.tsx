import React, { useEffect } from "react"
import { useDispatch } from "react-redux"
import BookContent from "../components/BookContent"
import { setBookId } from "../store/book/actions"
import { RouteComponentProps } from "react-router-dom"
import { Container } from "reactstrap"

interface BookParams {
    id: string
}

const Book: React.FC<RouteComponentProps<BookParams>> = ({ match }) => {
    const dispatch = useDispatch()
    const { id } = match.params

    useEffect(() => {
        dispatch(setBookId(id))
    }, [id])

    return <Container>
        <BookContent />
    </Container>
}

export default Book