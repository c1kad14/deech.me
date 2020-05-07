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

    let content = book!.paragraphs.map(paragraph => {
        switch (paragraph.type) {
            case "image":
                return <img src={`${domain}/books/${paragraph.value}`} />
            default:
                const element = paragraph.value.replace(/<img src="/, `<img src="${domain}/books/`)

                const rawMarkup = () => { return { __html: element } }
                return <p key={paragraph.id} dangerouslySetInnerHTML={rawMarkup()}></p>

        }

    })

    console.log(content)

    return <>
        {content}
    </>
}

export default BookContent