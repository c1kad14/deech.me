import React from "react"
import { ActionButton, ActionButtonProps } from "./ActionButton"

export const BookmarkButton: React.FC<ActionButtonProps> = ({ onClick }) => {
    const icon = <svg className="bi bi-bookmark" width="1.2em" height="1.2em" viewBox="0 0 15 16" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
        <path fillRule="evenodd" d="M8 12l5 3V3a2 2 0 0 0-2-2H5a2 2 0 0 0-2 2v12l5-3zm-4 1.234l4-2.4 4 2.4V3a1 1 0 0 0-1-1H5a1 1 0 0 0-1 1v10.234z" />
    </svg>
    const hoverIcon = <svg className="bi bi-bookmark-fill" width="1.2em" height="1.2em" viewBox="0 0 16 16" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
        <path fillRule="evenodd" d="M3 3a2 2 0 0 1 2-2h6a2 2 0 0 1 2 2v12l-5-3-5 3V3z" />
    </svg>

    return <ActionButton icon={icon} hoverIcon={hoverIcon} onClick={onClick} />
}