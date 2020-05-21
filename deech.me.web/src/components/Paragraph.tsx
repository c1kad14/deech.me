import React, { useEffect, useRef, useState } from "react"
import { domain } from "../store/config"
import { IParagraph } from "../store/book/types"
import { useDispatch, useSelector } from "react-redux"
import { showComments, hideComments } from "../store/comments/actions"
import { RootState } from "../store/rootReducer"
import CommentsSection from "./CommentsSection"
import { setProgress } from "../store/book/actions"

const rawMarkup = (paragraph: IParagraph) => { return { __html: paragraph.value.replace(/<img src="/, `<img src="${domain}/books/`) } }

type ParagraphProps = {
    paragraph: IParagraph
}

const Paragraph: React.FC<ParagraphProps> = ({ paragraph }) => {
    const dispatch = useDispatch()
    let { paragraphId } = useSelector((state: RootState) => state.comments)
    let { progress } = useSelector((state: RootState) => state.book)

    // useEffect(() => {
    //     const checkScrollDirectionIsUp = () => {
    //         const currentY = window.pageYOffset || document.documentElement.scrollTop
    //         setPrevY(currentY)
    //         return currentY > prevY
    //     }

    //     window.addEventListener("scroll", function (event) {
    //         const rect = element.current!.getBoundingClientRect()
    //         if (
    //             rect.top >= 0 &&
    //             rect.left >= 0 &&
    //             rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
    //             rect.right <= (window.innerWidth || document.documentElement.clientWidth)) {
    //             if (checkScrollDirectionIsUp()) {
    //                 if (paragraph.sequence > progress) {
    //                     dispatch(setProgress(paragraph.sequence))
    //                 }
    //             } else {
    //                 if (paragraph.sequence < progress) {
    //                     dispatch(setProgress(paragraph.sequence))
    //                 }
    //             }
    //         }
    //     })
    // }, [])


    const setParagraph = (id: number) => {
        if (paragraphId === id) {
            id = -1
        }
        if (id !== -1) {
            dispatch(showComments(id))
        } else {
            dispatch(hideComments())
        }
    }

    return <><p className="paragraph-element" key={paragraph.id} paragraph-seq={paragraph.sequence}>
        <span dangerouslySetInnerHTML={rawMarkup(paragraph)}></span>
        {<span className="text-muted ml-2 px-1 paragraph-comments" onClick={() => setParagraph(paragraph.id)}>{paragraph.comments}</span>}
    </p>
        {paragraphId === paragraph.id && <CommentsSection />}
    </>
}

export default Paragraph