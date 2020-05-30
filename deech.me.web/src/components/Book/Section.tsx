import React from "react"
import { rawMarkupHelper, imgPathHelper } from "../../utils/helpers"

export type SectionProps = {
    id: number,
    value: string,
    type: string
}

export const Section: React.FC<SectionProps> = ({ id, value, type }) => {
    switch (type) {
        case "image":
            return <img className="book-image" key={id} src={imgPathHelper(value)} />
        case "title":
            return <h3 key={id} dangerouslySetInnerHTML={rawMarkupHelper(value)}></h3>
        case "p":
            return <p key={id} dangerouslySetInnerHTML={rawMarkupHelper(value)}></p>
        case "table":
            return <table className="table" key={id} dangerouslySetInnerHTML={rawMarkupHelper(value)}></table>
        default:
            return <span key={id} dangerouslySetInnerHTML={rawMarkupHelper(value)}></span>
    }
}