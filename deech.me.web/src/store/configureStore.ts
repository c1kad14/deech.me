import { applyMiddleware, compose, createStore } from "redux"
import { createLogger } from "redux-logger"
import rootReducer from "./rootReducer"
import createSagaMiddleware from "redux-saga"
import { sagaWatcher } from "./sagas"

const sagaMiddleware = createSagaMiddleware()
const loggerMiddleware = createLogger()
const middleware = applyMiddleware(sagaMiddleware, loggerMiddleware)


// using compose to allow for applyMiddleware Redux Dev Tools
const enhancer = (window as any)["devToolsExtension"] && process.env.NODE_ENV === "development"
    ? compose(middleware,
        (window as any).__REDUX_DEVTOOLS_EXTENSION__ &&
        (window as any).__REDUX_DEVTOOLS_EXTENSION__()
    )
    : middleware

const store = createStore(rootReducer, enhancer)

sagaMiddleware.run(sagaWatcher)

export default function configureStore() {
    return store
}