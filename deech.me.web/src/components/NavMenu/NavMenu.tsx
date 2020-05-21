import React, { useState } from "react"
import { NavbarBrand, NavLink } from "reactstrap"
import { Link } from "react-router-dom"
import { Search } from "../Search/"
import { MenuButton } from "../MenuButton/"
import { SignInButton } from "../SignInButton/"
import "./NavMenu.css"

const NavMenu: React.FC = () => {
    const [] = useState<boolean>(false)

    return (
        <header className="sticky-top navbar-container">
            <div className="border-bottom box-shadow p-2">
                <div className="row container">
                    <NavbarBrand tag={Link} to="/" className="deech-me-logo col-2">deech.me</NavbarBrand>

                    <MenuButton />
                    <div className="col">
                        <Search />
                    </div>
                    <div>
                        <SignInButton />
                    </div>
                </div>
            </div>
        </header>
    )
}

export default NavMenu