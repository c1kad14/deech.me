import React from "react"
import "./menu.css"

type MenuButtonProps = {
    menuOpenClick: ((event: React.MouseEvent<HTMLDivElement, MouseEvent>) => void)
}

export const MenuButton: React.FC<MenuButtonProps> = ({ menuOpenClick }) => {
    return <div className="menu-button btn btn-outline-secondary pt-2" onClick={menuOpenClick}>
        <svg className="bi bi-list" width="2em" height="1.5em" viewBox="0 0 16 16" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
            <path fillRule="evenodd" d="M2.5 11.5A.5.5 0 013 11h10a.5.5 0 010 1H3a.5.5 0 01-.5-.5zm0-4A.5.5 0 013 7h10a.5.5 0 010 1H3a.5.5 0 01-.5-.5zm0-4A.5.5 0 013 3h10a.5.5 0 010 1H3a.5.5 0 01-.5-.5z" clipRule="evenodd" />
        </svg>
        <span className="text-light">Menu</span>
    </div>
}