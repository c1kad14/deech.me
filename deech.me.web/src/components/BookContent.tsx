import React from "react"
import { useSelector } from "react-redux"
import { RootState } from "../store/rootReducer"
import { Spinner } from "./Spinner"
import { domain } from "../store/config"
import { Paragraph } from "../store/book/types"

const rawMarkup = (paragraph: Paragraph) => { return { __html: paragraph.value.replace(/<img src="/, `<img src="${domain}/books/`) } }

const BookContent: React.FC = () => {
    let { book } = useSelector((state: RootState) => state.BookReducer)
    let { loading } = useSelector((state: RootState) => state.AppReducer)

    if (!book || loading) {
        return <Spinner />
    }

    const sorted = book.paragraphs.slice().sort((a, b) => a.sequence - b.sequence)

    let content = sorted.map(paragraph => {
        switch (paragraph.type) {
            case "image":
                return <img className="book-image" key={paragraph.id} src={`${domain}/books/${paragraph.value}`} />
            case "title":
                return <h3 className="paragraph-element" key={paragraph.id} dangerouslySetInnerHTML={rawMarkup(paragraph)}></h3>
            case "p":
                return <p className="paragraph-element" key={paragraph.id} dangerouslySetInnerHTML={rawMarkup(paragraph)}></p>
            case "table":
                return <table className="paragraph-element table" key={paragraph.id} dangerouslySetInnerHTML={rawMarkup(paragraph)}></table>
            default:
                return <span className="paragraph-element" key={paragraph.id} dangerouslySetInnerHTML={rawMarkup(paragraph)}></span>
        }
    })

    return <>
        {content}
    </>
}

export default BookContent