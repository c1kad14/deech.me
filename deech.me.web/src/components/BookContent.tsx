import React from "react"
import { useSelector } from "react-redux"
import { RootState } from "../store/rootReducer"
import { Spinner } from "./Spinner"
import { domain } from "../store/config"

const BookContent: React.FC = () => {
    let { book } = useSelector((state: RootState) => state.BookReducer)
    let { loading } = useSelector((state: RootState) => state.AppReducer)

    if (!book || loading) {
        return <Spinner />
    }

    let content = book!.contents[0].replace(/<image xlink:href="#/g, `<img width="50%" height="50%" src="${domain}/books/${book.file}/`)
    content = content.replace(/<img xlink:href="#/g, `<img width="50%" height="50%" src="${domain}/books/${book.file}/`)
    content = content.replace(/<img l:href="#/g, `<img width="50%" height="50%" src="${domain}/books/${book.file}/`)
    content = content.replace(/<image l:href="#/g, `<img width="50%" height="50%" src="${domain}/books/${book.file}/`)

    const rawMarkup = () => { return { __html: content } }
    return <>
        <span style={{ color: '#eeeeee' }} dangerouslySetInnerHTML={rawMarkup()} />
    </>

}

export default BookContent