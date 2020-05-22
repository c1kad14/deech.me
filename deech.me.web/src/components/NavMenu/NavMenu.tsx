import React, { useState, useEffect } from "react"
import { NavbarBrand, NavLink } from "reactstrap"
import { Link } from "react-router-dom"
import { Search } from "../Search"
import { MenuButton, MenuFullScreen } from "../Menu"
import { SignInButton } from "../SignIn/SignInButton"
import { Deech } from "./Deech"
import "./navmenu.css"

const NavMenu: React.FC = () => {
    const [isOpen, setIsOpen] = useState(false)
    const menuOpenClick = () => setIsOpen(true)
    const menuCloseClick = () => setIsOpen(false)

    return (
        <header className="sticky-top navbar-container">
            <div className="border-bottom box-shadow p-2">
                <div className="row container">
                    <div className="col-md-4 offset-md-1">
                        <NavbarBrand tag={Link} to="/" className="deech-me-logo">
                            <Deech />
                        </NavbarBrand>
                        <MenuButton menuOpenClick={menuOpenClick} />
                    </div>
                    <div className="col-md-5">
                        <Search />
                    </div>
                    <div className="">
                        <SignInButton />
                    </div>
                </div>
            </div>
            <MenuFullScreen isOpen={isOpen} menuCloseClick={menuCloseClick} />
        </header>
    )
}

export default NavMenu