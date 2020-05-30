import React, { useEffect, useState, ReactNode } from "react"
import { useSelector, useDispatch } from "react-redux"
import { RootState } from "../../store/rootReducer"
import { domain } from "../../config"
import { IParagraph } from "../../store/book/types"
import Paragraph from "./Paragraph"
import { setProgress } from "../../store/book/actions"
import "./book.css"

const rawMarkup = (paragraph: IParagraph) => { return { __html: paragraph.value.replace(/<img src="/, `<img src="${domain}/books/`) } }

let number: number = 0

const BookContent: React.FC = () => {
    const dispatch = useDispatch()
    let { book, progress } = useSelector((state: RootState) => state.book)
    let content: ReactNode[] = []

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
                        // dispatch(setProgress(paragraphSeq))
                        number = paragraphSeq
                    }
                }
                else {
                    if (rect.top < 0) {
                        // dispatch(setProgress(paragraphSeq))
                        number = paragraphSeq
                    }
                }
            }
        }
    }

    useEffect(() => {
        const elements = document.getElementsByClassName("paragraph-element")
        const observer = new IntersectionObserver(
            handleCallback,
            options
        )

        Array.from(elements).forEach((item) => {
            observer.observe(item)
        })

        if (progress > 0) {
            const anchor = Array.from(elements).filter(elem => {
                const attr = elem.attributes.getNamedItem("paragraph-seq")
                return attr && attr.value && Number(attr.value) === progress
            })

            if (anchor.length > 0) {
                anchor[0].scrollIntoView()
            }
        }
        const unloadHandler = () => {
            dispatch(setProgress(number))
        }

        window.addEventListener("beforeunload", unloadHandler)

        return () => {
            dispatch(setProgress(number))
            observer.disconnect()
            window.removeEventListener("beforeunload", unloadHandler)
        }
    }, [])

    console.log("*** BOOK CONTENT RERENDER ***")
    const sorted = book!.paragraphs.slice().sort((a, b) => a.sequence - b.sequence)
    content = sorted.map(paragraph => {
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
        {content.length > 0 && content}
    </div>
}

export default BookContent