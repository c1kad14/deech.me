import React, { useState } from "react"
import { NavbarBrand } from "reactstrap"
import { Link } from "react-router-dom"
import { Search } from "../Search"
import { MenuButton, MenuFullScreen } from "../Menu"
import { SignInButton } from "../SignIn/SignInButton"
import { SignOutButton } from "../SignIn/SignOutButton"
import { increaseText, decreaseText } from "../../store/settings/actions"
import { Deech } from "./Deech"
import "./NavMenu.css"
import { useDispatch, useSelector } from "react-redux"
import { RootState } from "../../store/rootReducer"

const NavMenu: React.FC = () => {
    const [isOpen, setIsOpen] = useState(false)
    const dispatch = useDispatch()
    let { username } = useSelector((state: RootState) => state.app)
    const menuOpenClick = () => setIsOpen(true)
    const menuCloseClick = () => setIsOpen(false)

    return (
        <header className="sticky-top navbar-container">
            <div className="border-bottom box-shadow p-2">
                <div className="row container mb-2">
                    <div className="col-md-4 offset-md-1">
                        <NavbarBrand tag={Link} to="/" className="deech-me-logo">
                            <Deech />
                        </NavbarBrand>
                        <MenuButton menuOpenClick={menuOpenClick} />
                    </div>
                    <div>
                        <button onClick={_ => dispatch(increaseText())}>+</button>
                        <button onClick={_ => dispatch(decreaseText())}>-</button>
                    </div>
                    <div className="col-md-5 mt-2">
                        <Search />
                    </div>
                    <div className="mt-2">
                        {username ? <SignOutButton /> : <SignInButton />}
                    </div>
                </div>
            </div>
            <MenuFullScreen isOpen={isOpen} menuCloseClick={menuCloseClick} />
        </header>
    )
}

export default NavMenu