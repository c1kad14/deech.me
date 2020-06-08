import "bootstrap/dist/css/bootstrap.css"

import * as React from "react"
import * as ReactDOM from "react-dom"
import { Provider } from "react-redux"
import { ConnectedRouter } from "connected-react-router"
import { createBrowserHistory } from "history"
import configureStore from "./store/configureStore"
import App from "./App"
import registerServiceWorker from "./registerServiceWorker"
import { PersistGate } from "redux-persist/integration/react"

// Create browser history to use in the Redux store
const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href") as string
const history = createBrowserHistory({ basename: baseUrl })

ReactDOM.render(
    <Provider store={configureStore().store}>
        <PersistGate loading={null} persistor={configureStore().persistor}>
            <ConnectedRouter history={history}>
                <App />
            </ConnectedRouter>
        </PersistGate>
    </Provider>,
    document.getElementById("root"))

registerServiceWorker()
