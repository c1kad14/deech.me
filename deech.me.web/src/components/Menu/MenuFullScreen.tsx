import React, { useEffect } from "react"
import { Link } from "react-router-dom"
import $ from "jquery"
import "./menu.css"
import { NavLink } from "reactstrap"

type MenuFullScreenProps = {
    isOpen: boolean
    menuCloseClick: (event: React.MouseEvent<HTMLButtonElement, MouseEvent>) => void
}

export const MenuFullScreen: React.FC<MenuFullScreenProps> = ({ isOpen, menuCloseClick }) => {
    useEffect(() => {
        if (isOpen) {
            $('#menu-id').slideDown(400)
            $("body").css("overflow", "hidden")
        }
        return () => {
            $('#menu-id').slideUp(300)
            $("body").css("overflow", "scroll")
        }
    }, [isOpen])

    return <div id="menu-id" className="container-fluid menu-fullscreen bg-dark">
        <div className="row p-4">
            <div className="col text-light ml-5">
                <NavLink tag={Link} to="/" className="text-white" onClick={menuCloseClick}>DEECH.ME</NavLink>
            </div>

            <div className="col mr-5">
                <button type="button" className="close" aria-label="Close" onClick={menuCloseClick}>
                    <svg className="bi bi-x-circle" width="1em" height="1em" viewBox="0 0 16 16" fill="white" xmlns="http://www.w3.org/2000/svg">
                        <path fillRule="evenodd" d="M8 15A7 7 0 108 1a7 7 0 000 14zm0 1A8 8 0 108 0a8 8 0 000 16z" clipRule="evenodd" />
                        <path fillRule="evenodd" d="M11.854 4.146a.5.5 0 010 .708l-7 7a.5.5 0 01-.708-.708l7-7a.5.5 0 01.708 0z" clipRule="evenodd" />
                        <path fillRule="evenodd" d="M4.146 4.146a.5.5 0 000 .708l7 7a.5.5 0 00.708-.708l-7-7a.5.5 0 00-.708 0z" clipRule="evenodd" />
                    </svg>
                </button>
            </div>
        </div>
        <div className="text-white pl-5">
            <div className="row py-3">
                <div className="col-4">
                    <h3>My Library</h3>
                    <ul className="list-group">
                        <li>Books</li>
                        <li>Bookmarks</li>
                        <li>Collections</li>
                        <li>Citations</li>
                        <li>Comments</li>
                        <li>Notes</li>
                        <li>Reviews</li>
                    </ul>
                </div>
                <div className="col-4">
                    <h3>Books by</h3>
                    <ul className="list-group">
                        <li>Author</li>
                        <li>Title</li>
                        <li>Genre</li>
                        <li>Rating</li>
                        <li>Tag</li>
                        <li>Latest</li>
                    </ul>
                </div>
                <div className="col-4">
                    <h3>My Profile</h3>
                    <ul className="list-group">
                        <li>View profile</li>
                        <li>Preferences</li>
                        <li>Privacy</li>
                    </ul>
                </div>
            </div>
            <div className="row py-3">
                <div className="col-4">
                    <h3>Collections</h3>
                    <ul className="list-group">
                        <li>Top Rated</li>
                        <li>Most Popular</li>
                        <li>Following</li>
                    </ul>
                </div>
                <div className="col-4">
                    <h3>Community</h3>
                    <ul className="list-group">
                        <li>Contacts</li>
                        <li>Help Center</li>
                        <li>Polls</li>
                        <li>About</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
}