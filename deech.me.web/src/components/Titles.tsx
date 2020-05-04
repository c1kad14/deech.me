import React from 'react'
import { useSelector } from 'react-redux';
import { RootState } from '../store/rootReducer';
import TitleTile from './TitleTile';

const Titles: React.FC = () => {

    let { titles } = useSelector((state: RootState) => state.TitleReducer);
    let titleTiles = titles && titles.length > 0 ? titles.map(title => <TitleTile key={title.id} id={title.id} cover={title.cover} title={title.title} />) : <></>;


    return <div className="row">
        {titleTiles}
    </div>
}

export default Titles