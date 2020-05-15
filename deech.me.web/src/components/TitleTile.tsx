import React from "react"
import { ITitleInfo } from "../store/title/types"
import { domain } from "../store/config"
import { useHistory } from "react-router-dom"

const TitleTile: React.FC<ITitleInfo> = ({ id, cover, title }) => {
    const data = cover && `${domain}/books/${cover}`
    const history = useHistory();

    const onHandleClick = (e: React.MouseEvent<HTMLElement>) => {
        history.push(`/book/${id}`);
    }

    return <li key={id} className="results-item-wrap" onClick={onHandleClick}>
        <span className="results-item">
            <div className="result-item-preview-wrap">
                <div className="result-item-preview" style={{ backgroundImage: `url(${data})` }}>
                </div>
            </div>

            <div className="result-item-footer">
                <div className="results-item-title">
                    {title}
                </div>
            </div>
        </span>
    </li>
}

export default TitleTile    