import React from "react"
import { useDispatch, useSelector } from "react-redux"
import { loadTitles, setFilter } from "../../store/title/actions"
import { RootState } from "../../store/rootReducer"

const SearchInput: React.FC = () => {
    const dispatch = useDispatch()
    const filter = useSelector((state: RootState) => state.title.filter)

    const onFilterChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        dispatch(setFilter({ title: e.target.value }))
    }

    const onKeyPressHandler = (e: React.KeyboardEvent) => {
        if (e.key === "Enter") {
            dispatch(loadTitles())
        }
    }

    const title = filter ? filter.title : ''

    return <input className="search-input input borderless comment-input-dark" type="text" name="title" placeholder="type book or author" onChange={onFilterChange} onKeyPress={onKeyPressHandler} value={title} />
}

export default SearchInput