import React, { useState } from "react"
import { useDispatch, useSelector } from "react-redux"
import { loadTitles, setFilter } from "../store/title/actions"
import { RootState } from "../store/rootReducer"

const Search: React.FC = () => {
    const dispatch = useDispatch()
    const { filter } = useSelector((state: RootState) => state.TitleReducer)

    const onFilterChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        dispatch(setFilter({ title: e.target.value }))
    }

    const onKeyPressHandler = (e: React.KeyboardEvent) => {
        if (e.key === "Enter") {
            if (filter && filter.title)
                dispatch(loadTitles())
        }
    }

    const searchButtonClickHandler = () => {
        dispatch(loadTitles())
    }

    return <div className="input-group rounded">
        <input className="input comment-input-dark borderless pl-2 pt-1 pb-1 rounded-left" type="text" name="title" placeholder="type book or author" onChange={onFilterChange} onKeyPress={onKeyPressHandler} />
        <div className="input-group-append">
            <button className="bg-dark borderless rounded-right" onTouchStart={searchButtonClickHandler}>
                <svg className="bi bi-search" width="1em" height="1em" viewBox="0 0 16 16" fill="white" xmlns="http://www.w3.org/2000/svg">
                    <path fillRule="evenodd" d="M10.442 10.442a1 1 0 011.415 0l3.85 3.85a1 1 0 01-1.414 1.415l-3.85-3.85a1 1 0 010-1.415z" clipRule="evenodd" />
                    <path fillRule="evenodd" d="M6.5 12a5.5 5.5 0 100-11 5.5 5.5 0 000 11zM13 6.5a6.5 6.5 0 11-13 0 6.5 6.5 0 0113 0z" clipRule="evenodd" />
                </svg>
            </button>
        </div>
    </div>
}

export default Search