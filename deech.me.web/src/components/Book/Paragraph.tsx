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
    const [selected, setSelected] = useState(false)
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
    const paragraphClasses = selected ? "paragraph-element paragraph-element-selected rounded" : "paragraph-element"

    const paragraphSelected = (event: React.MouseEvent<HTMLElement, MouseEvent>) => {
        event.stopPropagation()
        setSelected(!selected)
    }

    const replyButtonClick = (event: React.MouseEvent<HTMLElement, MouseEvent>) => {
        event.stopPropagation()

        dispatch(setParagraph(paragraph.id))
        setReply(!reply)
    }

    const bookmarkButtonClick = (event: React.MouseEvent<HTMLElement, MouseEvent>) => {
        event.stopPropagation()
        if (!user) {
            setShowSignInRequired(true)
        }
    }

    return <div>
        <div className={paragraphClasses} paragraph-seq={paragraph.sequence} onClick={(e) => paragraphSelected(e)}>
            <Section id={paragraph.id} type={paragraph.type} value={paragraph.value} />

            {selected && <span className="justify-content-end d-flex">
                <>
                    <BookmarkButton onClick={bookmarkButtonClick} />
                    <NoteButton />
                    <CitationButton />
                    <ReplyButton onClick={replyButtonClick} />
                    <span className="paragraph-comments">({paragraph.comments})</span>
                </>
            </span>
            }

        </div>

        {paragraphId === paragraph.id && reply && <CommentsSection />}

        <SignInRequired isOpen={showSignInRequired} setIsOpen={setShowSignInRequired} />
    </div>
}

export default Paragraph