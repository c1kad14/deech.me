import { createLogicMiddleware } from "redux-logic"
import { applyMiddleware, compose, createStore, Store, Action } from "redux"
import { createLogger } from "redux-logger"
import rootLogic from "./rootLogic"
import rootReducer from "./rootReducer"

const logicMiddleware = createLogicMiddleware(rootLogic as any)
const loggerMiddleware = createLogger()
const middleware = applyMiddleware(logicMiddleware, loggerMiddleware)

// using compose to allow for applyMiddleware Redux Dev Tools
const enhancer = (window as any)["devToolsExtension"] && process.env.NODE_ENV === "development"
    ? compose(middleware,
        (window as any).__REDUX_DEVTOOLS_EXTENSION__ &&
        (window as any).__REDUX_DEVTOOLS_EXTENSION__()
    )
    : middleware

export default function configureStore() {
    return createStore(rootReducer, enhancer)
}