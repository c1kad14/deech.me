import React, { useEffect } from "react"
import { domain } from "../store/config"
import { IParagraph } from "../store/book/types"
import { useDispatch, useSelector } from "react-redux"
import { showComments, hideComments } from "../store/comments/actions"
import { RootState } from "../store/rootReducer"
import CommentsSection from "./CommentsSection"

const rawMarkup = (paragraph: IParagraph) => { return { __html: paragraph.value.replace(/<img src="/, `<img src="${domain}/books/`) } }

type ParagraphProps = {
    paragraph: IParagraph
}

const Paragraph: React.FC<ParagraphProps> = ({ paragraph }) => {
    const dispatch = useDispatch()
    let { paragraphId } = useSelector((state: RootState) => state.CommentsReducer)

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

    return <><p className="paragraph-element" key={paragraph.id}>
        <span dangerouslySetInnerHTML={rawMarkup(paragraph)}></span>
        {<span className="text-muted ml-2 px-1 paragraph-comments" onClick={() => setParagraph(paragraph.id)}>{paragraph.comments}</span>}
    </p>
        {paragraphId === paragraph.id && <CommentsSection />}
    </>
}

export default Paragraph