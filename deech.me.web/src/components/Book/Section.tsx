import React from "react"
import { rawMarkupHelper, imgPathHelper } from "../../utils/helpers"
import { useSelector, useDispatch } from "react-redux"
import { RootState } from "../../store/rootReducer"
import { setParagraph } from "../../store/book/actions"

export type SectionProps = {
    id: number,
    sequence: number,
    value: string,
    type: string
}

export const Section: React.FC<SectionProps> = ({ id, sequence, value, type }) => {
    switch (type) {
        case "image":
            return <img className="book-image" key={id} paragraph-seq={sequence} src={imgPathHelper(value)} />
        case "title":
            return <h3 key={id} paragraph-seq={sequence} dangerouslySetInnerHTML={rawMarkupHelper(value)}></h3>
        case "p":
            return <p key={id} paragraph-seq={sequence} dangerouslySetInnerHTML={rawMarkupHelper(value)}></p>
        case "table":
            return <table className="table" key={id} paragraph-seq={sequence} dangerouslySetInnerHTML={rawMarkupHelper(value)}></table>
        default:
            return <span key={id} paragraph-seq={sequence} dangerouslySetInnerHTML={rawMarkupHelper(value)}></span>
    }
}