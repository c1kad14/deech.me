import React from "react"
import { TitleInfo } from "../store/title/types"

const TitleTile: React.FC<TitleInfo> = ({ id, cover, title }) => {
    const data = `data:image/jpg;base64, ${cover}`
    return <div key={id} className="card">
        <img className="card-img-top" src={data} />
        <h5 className="title-description crop">{title}</h5>
    </div>
}

export default TitleTile    