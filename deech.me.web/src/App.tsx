import * as React from "react"
import { Route } from "react-router"
import Layout from "./components/Layout"
import Home from "./pages/Home"
import Book from "./pages/Book"
import Callback from "./pages/Callback"

import "./custom.css"

export default () => (
    <Layout>
        <Route exact path="/" component={Home} />
        <Route exact path="/book/:id" component={Book} />
        <Route exact path="/callback" component={Callback} />
    </Layout>
)
