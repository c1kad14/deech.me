import * as React from "react"
import { Route } from "react-router"
import Layout from "./components/Shared/Layout"
import Home from "./pages/Home"
import Book from "./pages/Book"
import SignInCallback from "./pages/SignInCallback"
import SignOutCallback from "./pages/SignOutCallback"
import SilentRenewCallback from "./pages/SilentRenewCallback"
import "./custom.css"
import Oidc from "oidc-client"

const App: React.FC = () => {

    Oidc.Log.logger = console;
    Oidc.Log.level = Oidc.Log.INFO;

    return <Layout>
        <Route exact path="/" component={Home} />
        <Route exact path="/book/:id" component={Book} />
        <Route exact path="/sicb" component={SignInCallback} />
        <Route exact path="/socb" component={SignOutCallback} />
        <Route exact path="/renew" component={SilentRenewCallback} />
    </Layout>
}

export default App