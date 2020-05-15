import React, { useState } from "react"
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from "reactstrap"
import { Link } from "react-router-dom"
import Search from "./Search"
import "./NavMenu.css"

const NavMenu: React.FC = () => {
    const [isOpen, setIsOpen] = useState<boolean>(false)

    return (
        <header className="sticky-top navbar-container">
            <div className="border-bottom box-shadow mb-3 p-2">
                <div className="container">
                    <NavbarBrand tag={Link} to="/" className="deech-me-logo">deech.me</NavbarBrand>


                    <div className="d-sm-inline-flex flex-sm-row">
                        <NavLink className="justify-content-start d-flex">Dashboard</NavLink>
                        <NavLink className="justify-content-start d-flex">Library</NavLink>
                        <div className="justify-content-end d-flex">
                            <Search />
                        </div>
                    </div>


                </div>
            </div>
        </header>
    )
}

export default NavMenu