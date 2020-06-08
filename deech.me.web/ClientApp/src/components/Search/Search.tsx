import React from "react"
import SearchDropdown from "./SearchDropdown"
import SearchButton from "./SearchButton"
import SearchInput from "./SearchInput"
import "./search.css"

const Search: React.FC = () => {
    return <div className="search-container-wrapper">
        <div className="search-container">
            <div className="input-group-prepend">
                <SearchDropdown />
            </div>
            <div className="search-input-container">
                <SearchInput />
            </div>
            <div className="input-group-append">
                <SearchButton />
            </div>
        </div>
    </div>
}

export default Search