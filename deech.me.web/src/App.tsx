import * as React from "react"
import { Route } from "react-router"
import Layout from "./components/Layout"
import Home from "./pages/Home"

import "./custom.css"
import Book from "./pages/Book"

export default () => (
    <Layout>
        <Route exact path="/" component={Home} />
        <Route exact path="/book/:id" component={Book} />
    </Layout>
)
