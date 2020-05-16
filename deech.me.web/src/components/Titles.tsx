import React, { useEffect, useRef, useState } from "react"
import { useSelector, useDispatch } from "react-redux"
import TitleTile from "./TitleTile"
import { Spinner } from "reactstrap"
import { RootState } from "../store/rootReducer"
import { loadMoreTitles } from "../store/title/actions"

const Titles: React.FC = () => {
    const { titles } = useSelector((state: RootState) => state.TitleReducer)
    const titleTiles = titles && titles.length > 0 && titles.map(title => <TitleTile key={title.id} id={title.id} cover={title.cover} title={title.title} />)
    const dispatch = useDispatch()
    const { loading } = useSelector((state: RootState) => state.AppReducer)
    const loadingCSS = { display: loading ? "block" : "none" };
    const loadingRef = useRef<HTMLDivElement>(null)
    const options = {
        root: null,
        rootMargin: "0px",
        threshold: 0.1
    };

    const [prevY, setPrevY] = useState(0)

    useEffect(() => {
        const observer = new IntersectionObserver(
            handleObserver,
            options
        );
        if (loadingRef) {
            observer.observe(loadingRef.current as Element);
        }
        return () => observer.disconnect()
    }, [])

    const handleObserver: IntersectionObserverCallback = (entities, observer) => {
        const { y } = entities[0].boundingClientRect as DOMRect

        if (prevY < y) {
            setPrevY(y)
            dispatch(loadMoreTitles());
        }
    }

    return <div>
        <ul className="results">
            {titleTiles}
        </ul>
        <div className="text-center text-danger p-5" ref={loadingRef}>
            <span style={loadingCSS}><Spinner /></span>
        </div>
    </div>
}

export default Titles