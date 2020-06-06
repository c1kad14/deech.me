import React, { useState } from "react"
import moment from "moment"
import { IParagraph } from "../../store/book/types"
import { useDispatch, useSelector } from "react-redux"
import { RootState } from "../../store/rootReducer"
import CommentsSection from "../Comments/CommentsSection"
import { addBookmark } from "../../store/book/actions"
import { ReplyButton } from "./ReplyButton"
import { CitationButton } from "./CitationButton"
import { BookmarkButton } from "./BookmarkButton"
import { NoteButton } from "./NoteButton"
import { Section } from "./Section"
import SignInRequired from "../Modals/SignInRequired"
import "./book.css"
import { showComments } from "../../store/comments/actions"

type ParagraphProps = {
    paragraph: IParagraph
}

const Paragraph: React.FC<ParagraphProps> = ({ paragraph }) => {
    const dispatch = useDispatch()
    let { paragraphId } = useSelector((state: RootState) => state.comments)
    let { username } = useSelector((state: RootState) => state.app)
    let { book } = useSelector((state: RootState) => state.book)
    const [selected, setSelected] = useState(false)
    const [reply, setReply] = useState(false)
    const [showSignInRequired, setShowSignInRequired] = useState(false)
    const paragraphClasses = selected ? "paragraph-element paragraph-element-selected rounded" : "paragraph-element"
    let bookmark;

    const paragraphSelected = (event: React.MouseEvent<HTMLElement, MouseEvent>) => {
        event.stopPropagation()
        setSelected(!selected)
    }

    const replyButtonClick = (event: React.MouseEvent<HTMLElement, MouseEvent>) => {
        event.stopPropagation()
        dispatch(showComments(paragraph.id))
        setReply(!reply)
    }

    const bookmarkButtonClick = (event: React.MouseEvent<HTMLElement, MouseEvent>) => {
        event.stopPropagation()
        if (!username) {
            setShowSignInRequired(true)
        } else {
            if (book && book.userBookId) {
                dispatch(addBookmark({ userBookId: book.userBookId, paragraphId: paragraph.id, created: moment().format("YYYY-MM-DD HH:mm") }))
            }
        }
    }

    if (book && book.bookmarks) {
        bookmark = book.bookmarks.filter(b => b.paragraphId === paragraph.id)[0]
    }

    return <div>
        {bookmark && <span>***</span>}
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