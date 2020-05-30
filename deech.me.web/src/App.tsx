import * as React from "react"
import { Route } from "react-router"
import Layout from "./components/Shared/Layout"
import Home from "./pages/Home"
import Book from "./pages/Book"
import SignInCallback from "./pages/SignInCallback"
import SignOutCallback from "./pages/SignOutCallback"
import { useEffect } from "react"
import Oidc from "oidc-client"
import { useSelector } from "react-redux"
import { RootState } from "./store/rootReducer"
import "./custom.css"

const App: React.FC = () => {
    return <Layout>
        <Route exact path="/" component={Home} />
        <Route exact path="/book/:id" component={Book} />
        <Route exact path="/sicb" component={SignInCallback} />
        <Route exact path="/socb" component={SignOutCallback} />
    </Layout>
}

export default App