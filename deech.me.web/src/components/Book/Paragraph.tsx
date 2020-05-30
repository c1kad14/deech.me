import React, { useEffect, useRef, useState } from "react"
import { domain } from "../../config"
import { IParagraph } from "../../store/book/types"
import { useDispatch, useSelector } from "react-redux"
import { showComments, hideComments } from "../../store/comments/actions"
import { RootState } from "../../store/rootReducer"
import CommentsSection from "../Comments/CommentsSection"
import { setParagraph } from "../../store/book/actions"
import { ReplyButton } from "./ReplyButton"
import { CitationButton } from "./CitationButton"
import { BookmarkButton } from "./BookmarkButton"
import { NoteButton } from "./NoteButton"

const rawMarkup = (paragraph: IParagraph) => { return { __html: paragraph.value.replace(/<img src="/, `<img src="${domain}/books/`) } }

type ParagraphProps = {
    paragraph: IParagraph
}

const Paragraph: React.FC<ParagraphProps> = ({ paragraph }) => {
    const dispatch = useDispatch()
    // let { paragraphId } = useSelector((state: RootState) => state.comments)
    let { progress, paragraphId } = useSelector((state: RootState) => state.book)

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


    // const showParagraphComments = (id: number) => {
    //     if (paragraphId === id) {
    //         id = -1
    //     }
    //     if (id !== -1) {
    //         dispatch(showComments(id))
    //     } else {
    //         dispatch(hideComments())
    //     }
    // }

    const paragraphSelected = (event: React.MouseEvent<HTMLParagraphElement, MouseEvent>, id: number) => {
        event.stopPropagation();
        dispatch(setParagraph(id))
    }

    return <><p className="paragraph-element" key={paragraph.id} paragraph-seq={paragraph.sequence} onClick={(e) => paragraphSelected(e, paragraph.id)}>
        <span dangerouslySetInnerHTML={rawMarkup(paragraph)}></span>

        {paragraph.id === paragraphId && <>
            <BookmarkButton />
            <NoteButton />
            <CitationButton />


            <ReplyButton>

            </ReplyButton>
        </>}
        {/* {<span className="text-muted ml-2 px-1 paragraph-comments" onClick={() => showParagraphComments(paragraph.id)}>{paragraph.comments}</span>} */}
    </p>
        {paragraphId === paragraph.id && <CommentsSection />}
    </>
}

export default Paragraph