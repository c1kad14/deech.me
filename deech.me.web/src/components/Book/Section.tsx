import React from "react"
import { rawMarkupHelper, imgPathHelper } from "../../utils/helpers"
import { RootState } from "../../store/rootReducer";
import { useSelector } from "react-redux";
import { BookmarkButton } from "./BookmarkButton";

export type SectionProps = {
    id: number,
    value: string,
    type: string
}

export const Section: React.FC<SectionProps> = ({ id, value, type }) => {
    let { book } = useSelector((state: RootState) => state.book)
    let { size } = useSelector((state: RootState) => state.settings)
    let sectionValue;
    let bookmark;

    if (book && book.bookmarks) {
        bookmark = book.bookmarks.filter(b => b.paragraphId === id)[0]
    }

    const style = { fontSize: `${size}rem`}

    switch (type) {
        case "image":
            sectionValue = <img className="book-image" key={id} src={imgPathHelper(value)} alt="" />
            break
        case "title":
            sectionValue = <h3 key={id} dangerouslySetInnerHTML={rawMarkupHelper(value)}></h3>
            break
        case "table":
            sectionValue = <table className="table" key={id} dangerouslySetInnerHTML={rawMarkupHelper(value)}></table>
            break
        default:
            sectionValue = <span style={style} key={id} dangerouslySetInnerHTML={rawMarkupHelper(value)}></span>
    }

    return <span>
        {bookmark && <BookmarkButton />}
        {sectionValue}
    </span>
}