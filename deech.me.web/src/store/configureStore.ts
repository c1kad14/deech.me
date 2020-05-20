import { applyMiddleware, compose, createStore } from "redux"
import { createLogger } from "redux-logger"
import rootReducer from "./rootReducer"
import createSagaMiddleware from "redux-saga"
import { sagaWatcher } from "./sagas"
import { persistStore, persistReducer } from "redux-persist"
import storage from "redux-persist/lib/storage"

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


//

const persistConfig = {
    key: 'root',
    storage,
}

const persistedReducer = persistReducer(persistConfig, rootReducer)

export default () => {
    let store = createStore(persistedReducer, enhancer)
    sagaMiddleware.run(sagaWatcher)
    let persistor = persistStore(store)
    return { store, persistor }
}