import React from "react"
import { ITitleInfo } from "../store/title/types"
import { domain } from "../store/config"
import { useHistory } from "react-router-dom"
import { setBookId } from "../store/book/actions"
import { useDispatch } from "react-redux"

const TitleTile: React.FC<ITitleInfo> = ({ id, cover, title }) => {
    const dispatch = useDispatch()
    const data = cover && `${domain}/books/${cover}`
    const history = useHistory()

    const onHandleClick = (e: React.MouseEvent<HTMLElement>) => {
        dispatch(setBookId(id))
        history.push(`/book/${id}`)
    }

    return <li className="results-item-wrap" onClick={onHandleClick}>
        <span className="results-item">
            <div className="result-item-preview-wrap">
                <div className="result-item-preview" style={{ backgroundImage: `url(${data})` }}>
                </div>
            </div>

            <div className="result-item-footer">
                <div className="results-item-title crop">
                    {title}
                </div>
            </div>
        </span>
    </li>
}

export default TitleTile    