import React, { useEffect, useState } from "react"
import { useSelector, useDispatch } from "react-redux"
import TitleTile from "./TitleTile"
import { Spinner } from "reactstrap"
import { RootState } from "../store/rootReducer"
import InfiniteScroll from 'react-infinite-scroller'
import { loadTitles, loadMoreTitles, clearTitles } from "../store/title/actions"

const Titles: React.FC = () => {
    const dispatch = useDispatch()
    const { loading } = useSelector((state: RootState) => state.AppReducer)
    const { titles, hasMore } = useSelector((state: RootState) => state.TitleReducer)
    const loadingCSS = { display: loading ? "block" : "none" }
    const titleTiles = titles && titles.length > 0 && titles.map(title => <TitleTile key={title.id} id={title.id} cover={title.cover} title={title.title} />)

    useEffect(() => {
        return () => { dispatch(clearTitles()) }
    }, [])

    const loadMore = () => {
        dispatch(loadMoreTitles())
    }

    return <InfiniteScroll
        pageStart={0}
        loadMore={loadMore}
        hasMore={hasMore}
        loader={<div key="loader" className="text-center text-danger p-5">
            <span style={loadingCSS}><Spinner /></span>
        </div>}
    >
        <ul className="results">
            {titleTiles}
        </ul>

    </InfiniteScroll>
}

export default Titles