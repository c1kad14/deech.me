import React, { useState } from "react"
import { domain } from "../../config"
import { IParagraph } from "../../store/book/types"
import { useDispatch, useSelector } from "react-redux"
import { RootState } from "../../store/rootReducer"
import CommentsSection from "../Comments/CommentsSection"
import { setParagraph } from "../../store/book/actions"
import { ReplyButton } from "./ReplyButton"
import { CitationButton } from "./CitationButton"
import { BookmarkButton } from "./BookmarkButton"
import { NoteButton } from "./NoteButton"
import { rawMarkupHelper } from "../../utils/helpers"
import { Section } from "./Section"
import "./book.css"

type ParagraphProps = {
    paragraph: IParagraph
}

const Paragraph: React.FC<ParagraphProps> = ({ paragraph }) => {
    const dispatch = useDispatch()
    // let { paragraphId } = useSelector((state: RootState) => state.comments)
    let { paragraphId } = useSelector((state: RootState) => state.book)
    const [reply, setReply] = useState(false)


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
    const paragraphClasses = paragraphId === paragraph.id ? "paragraph-element paragraph-element-selected rounded" : "paragraph-element"

    const paragraphSelected = (event: React.MouseEvent<HTMLElement, MouseEvent>, id: number) => {
        event.stopPropagation();
        dispatch(setParagraph(id))
    }

    return <>
        <p className={paragraphClasses} onClick={(e) => paragraphSelected(e, paragraph.id)}>
            <Section id={paragraph.id} sequence={paragraph.sequence} type={paragraph.type} value={paragraph.value} />

            {paragraph.id === paragraphId && <span className="justify-content-end d-flex">
                <>
                    <BookmarkButton />
                    <NoteButton />
                    <CitationButton />
                    <ReplyButton onClick={_ => setReply(!reply)} />
                    <span className="paragraph-comments">({paragraph.comments})</span>
                </>
            </span>
            }

        </p>

        {paragraphId === paragraph.id && reply && <CommentsSection />}
    </>
}

export default Paragraph