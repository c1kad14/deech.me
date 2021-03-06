import React from "react"
import { ITitleInfo } from "../../store/title/types"
import { domain } from "../../config"
import { useHistory } from "react-router-dom"

const TitleTile: React.FC<ITitleInfo> = ({ id, cover, title }) => {
    const data = cover ? `${domain}/books/${cover}` : `${domain}/images/cover.png`
    const history = useHistory()

    const onHandleClick = (e: React.MouseEvent<HTMLElement>) => {
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