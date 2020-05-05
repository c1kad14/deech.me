import React from "react"
import { TitleInfo } from "../store/title/types"
import { domain } from "../store/config"

const TitleTile: React.FC<TitleInfo> = ({ id, cover, title }) => {
    const data = cover && `${domain}/books/${cover}`
    return <div key={id} className="card">
        <img className="card-img-top" src={data} />
        <h5 className="title-description crop">{title}</h5>
    </div>
}

export default TitleTile    