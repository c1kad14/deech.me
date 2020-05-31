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
import { Section } from "./Section"
import SignInRequired from "../Modals/SignInRequired"
import "./book.css"

type ParagraphProps = {
    paragraph: IParagraph
}

const Paragraph: React.FC<ParagraphProps> = ({ paragraph }) => {
    const dispatch = useDispatch()
    // let { paragraphId } = useSelector((state: RootState) => state.comments)
    let { paragraphId } = useSelector((state: RootState) => state.book)
    let { user } = useSelector((state: RootState) => state.app)
    const [reply, setReply] = useState(false)
    const [showSignInRequired, setShowSignInRequired] = useState(false)


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
        event.stopPropagation()
        if (id === paragraphId) {
            id = -1
        }
        dispatch(setParagraph(id))
    }

    const replyButtonClick = (event: React.MouseEvent<HTMLElement, MouseEvent>) => {
        event.stopPropagation()
        setReply(!reply)
    }

    const bookmarkButtonClick = (event: React.MouseEvent<HTMLElement, MouseEvent>) => {
        event.stopPropagation()
        if (!user) {
            setShowSignInRequired(true)
        }
    }

    return <>
        <p className={paragraphClasses} paragraph-seq={paragraph.sequence} onClick={(e) => paragraphSelected(e, paragraph.id)}>
            <Section id={paragraph.id} type={paragraph.type} value={paragraph.value} />

            {paragraph.id === paragraphId && <span className="justify-content-end d-flex">
                <>
                    <BookmarkButton onClick={bookmarkButtonClick} />
                    <NoteButton />
                    <CitationButton />
                    <ReplyButton onClick={replyButtonClick} />
                    <span className="paragraph-comments">({paragraph.comments})</span>
                </>
            </span>
            }

        </p>

        {paragraphId === paragraph.id && reply && <CommentsSection />}

        <SignInRequired isOpen={showSignInRequired} setIsOpen={setShowSignInRequired} />
    </>
}

export default Paragraph