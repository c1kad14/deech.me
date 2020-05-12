import React, { useEffect } from "react"
import { domain } from "../store/config"
import { IParagraph } from "../store/book/types"
import { useDispatch, useSelector } from "react-redux"
import { showComments } from "../store/comments/actions"
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
        dispatch(showComments(id))
    }

    return <><p className="paragraph-element" key={paragraph.id} dangerouslySetInnerHTML={rawMarkup(paragraph)} onClick={() => setParagraph(paragraph.id)}>
    </p>

        {paragraphId === paragraph.id && <CommentsSection />}
    </>
}

export default Paragraph