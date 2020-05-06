import React from "react"
import { useDispatch } from 'react-redux'
import { TitleInfo } from "../store/title/types"
import { domain } from "../store/config"
import { useHistory } from "react-router-dom"

const TitleTile: React.FC<TitleInfo> = ({ id, cover, title }) => {
    const data = cover && `${domain}/books/${cover}`
    const history = useHistory();

    const onHandleClick = (e: React.MouseEvent<HTMLDivElement>) => {
        history.push(`/book/${id}`);
    }

    return <div key={id} className="card" onClick={onHandleClick}>
        <img className="card-img-top" src={data} />
        <h5 className="title-description crop">{title}</h5>
    </div>
}

export default TitleTile    