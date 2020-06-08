import React, { useEffect, ReactNode } from "react"
import { useSelector, useDispatch } from "react-redux"
import { RootState } from "../../store/rootReducer"
import Paragraph from "./Paragraph"
import { setProgress } from "../../store/book/actions"
import "./book.css"

let number = 0

const BookContent: React.FC = () => {
    const dispatch = useDispatch()
    let { book } = useSelector((state: RootState) => state.book)
    let content: ReactNode[] = []

    useEffect(() => {
        let userBookId: number | undefined
        let initialized: boolean

        const elements = document.getElementsByClassName("paragraph-element")

        if (book) {
            userBookId = book.userBookId
            initialized = userBookId === undefined

            const anchor = Array.from(elements).filter(elem => {
                const attr = elem.attributes.getNamedItem("paragraph-seq")
                return book && attr && attr.value && Number(attr.value) === book.progress
            })

            if (anchor.length > 0) {
                anchor[0].scrollIntoView()
            }
        }

        const observer = new IntersectionObserver(
            (changes) => {
                const paragraphSeqAttr = changes[0].target.attributes.getNamedItem("paragraph-seq")
                const rect = changes[0].boundingClientRect
                if (initialized) {
                    if (paragraphSeqAttr && paragraphSeqAttr.value) {
                        const paragraphSeq = Number(paragraphSeqAttr.value)
                        if (paragraphSeq) {
                            if (rect.top >= 0 &&
                                rect.left >= 0 &&
                                rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
                                rect.right <= (window.innerWidth || document.documentElement.clientWidth)) {
                                if (rect.top <= rect.height) {
                                    number = paragraphSeq
                                }
                            }
                            else {
                                if (rect.top < 0) {
                                    number = paragraphSeq
                                }
                            }
                        }
                    }
                } else {
                    number = book ? book.progress : 0
                    initialized = true
                }
            },
            {
                root: null, // relative to document viewport 
                rootMargin: '0px', // margin around root. Values are similar to css property. Unitless values not allowed
                threshold: 1.0 // visible amount of item shown in relation to root
            }
        )

        Array.from(elements).forEach((item) => {
            observer.observe(item)
        })

        const unloadHandler = () => {
            if (userBookId) {
                dispatch(setProgress(userBookId, number))
            }
        }

        window.addEventListener("beforeunload", unloadHandler)

        return () => {
            if (userBookId) {
                dispatch(setProgress(userBookId, number))
            }
            observer.disconnect()
            window.removeEventListener("beforeunload", unloadHandler)
        }
    }, [dispatch])

    if (book) {
        content = book.paragraphs.map(paragraph => <Paragraph key={paragraph.id} paragraph={paragraph} />)
    }

    return <div className="no-select">
        {content}
    </div>
}

export default BookContent