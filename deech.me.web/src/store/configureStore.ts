import { createLogicMiddleware } from "redux-logic"
import { applyMiddleware, compose, createStore } from "redux"
import { createLogger } from "redux-logger"
import rootReducer from "./rootReducer"
import rootLogic from "./rootLogic"

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