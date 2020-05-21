import React, { useState } from "react"
import { TitleFilters } from "../../constants"

const SearchDropdown: React.FC = () => {
    const [selectedItem, setSelectedItem] = useState('All')

    const dropdownItemChanged = (event: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
        console.log(event)
        if (event.currentTarget.textContent) {
            setSelectedItem(event.currentTarget.textContent)
        }
    }

    const dropdownItems = TitleFilters.map(filter => <button className="dropdown-item text-light" onClick={dropdownItemChanged}>{filter}</button>)

    return (<div className="search-dropdown rounded-left bg-dark borderless">
        <button className="search-dropdown-button text-muted dropdown-toggle btn pt-2" type="button"
            data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">{selectedItem}</button>
        <div className="dropdown-menu dropdown bg-dark" aria-labelledby="dropdownMenuButton">
            {dropdownItems}
        </div>
    </div>)
}

export default SearchDropdown