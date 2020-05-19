import React, { useEffect, useState } from "react"
import { useSelector, useDispatch } from "react-redux"
import { RootState } from "../store/rootReducer"
import { domain } from "../store/config"
import { IParagraph } from "../store/book/types"
import Paragraph from "./Paragraph"
import { setProgress } from "../store/book/actions"

const rawMarkup = (paragraph: IParagraph) => { return { __html: paragraph.value.replace(/<img src="/, `<img src="${domain}/books/`) } }

const BookContent: React.FC = () => {
    const dispatch = useDispatch()
    let { book, progress } = useSelector((state: RootState) => state.BookReducer)

    let options = {
        root: null, // relative to document viewport 
        rootMargin: '0px', // margin around root. Values are similar to css property. Unitless values not allowed
        threshold: 1.0 // visible amount of item shown in relation to root
    }

    const handleCallback: IntersectionObserverCallback = (changes, observer) => {
        const paragraphSeqAttr = changes[0].target.attributes.getNamedItem("paragraph-seq")
        const rect = changes[0].boundingClientRect
        if (paragraphSeqAttr && paragraphSeqAttr.value) {
            const paragraphSeq = Number(paragraphSeqAttr.value)
            if (paragraphSeq) {
                if (rect.top >= 0 &&
                    rect.left >= 0 &&
                    rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
                    rect.right <= (window.innerWidth || document.documentElement.clientWidth)) {
                    if (rect.top <= rect.height) {
                        dispatch(setProgress(paragraphSeq))
                    }

                }
                else {
                    if (rect.top < 0) {
                        dispatch(setProgress(paragraphSeq))
                    }
                }
            }
        }
    }

    useEffect(() => {
        const observer = new IntersectionObserver(
            handleCallback,
            options
        )
        const elements = document.getElementsByClassName("paragraph-element")
        Array.from(elements).forEach(function (item) {
            observer.observe(item)
        })

        return () => {
            observer.disconnect()
        }
    }, [])

    const sorted = book!.paragraphs.slice().sort((a, b) => a.sequence - b.sequence)

    let content = sorted.map(paragraph => {
        switch (paragraph.type) {
            case "image":
                return <img className="book-image paragraph-element" key={paragraph.id} paragraph-seq={paragraph.sequence} src={`${domain}/books/${paragraph.value}`} />
            case "title":
                return <h3 className="paragraph-element" key={paragraph.id} paragraph-seq={paragraph.sequence} dangerouslySetInnerHTML={rawMarkup(paragraph)}></h3>
            case "p":
                return <Paragraph key={paragraph.id} paragraph={paragraph} />
            case "table":
                return <table className="paragraph-element table" key={paragraph.id} paragraph-seq={paragraph.sequence} dangerouslySetInnerHTML={rawMarkup(paragraph)}></table>
            default:
                return <span className="paragraph-element" key={paragraph.id} paragraph-seq={paragraph.sequence} dangerouslySetInnerHTML={rawMarkup(paragraph)}></span>
        }
    })

    return <div className="no-select">
        {content}
    </div>
}

export default BookContent