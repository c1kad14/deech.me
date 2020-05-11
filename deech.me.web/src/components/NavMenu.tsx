import React, { useState } from "react"
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from "reactstrap"
import { Link } from "react-router-dom"
import "./NavMenu.css"

const NavMenu: React.FC = () => {
    const [isOpen, setIsOpen] = useState<boolean>(false)

    const toogle = () => {
        setIsOpen(!isOpen)
    }

    return (
        <header className="sticky-top navbar-container">
            <Navbar className="navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow mb-3" light>
                <Container>
                    <NavbarBrand tag={Link} to="/" className="deech-me-logo">deech.me</NavbarBrand>
                    <NavbarToggler onClick={toogle} className="mr-2" />
                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={isOpen} navbar>
                        <ul className="navbar-nav flex-grow">
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
                            </NavItem>
                        </ul>
                    </Collapse>
                </Container>
            </Navbar>
        </header>
    )
}

export default NavMenu