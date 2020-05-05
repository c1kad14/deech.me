
import { connectRouter } from "connected-react-router"
import { combineReducers } from "redux"
import AppReducer from "./app/reducer"
import BookReducer from "./book/reducer"
import TitleReducer from "./title/reducer"
import { createBrowserHistory } from "history"

const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href") as string
const history = createBrowserHistory({ basename: baseUrl })

const rootReducer = combineReducers({
    ...AppReducer,
    ...BookReducer,
    ...TitleReducer,
    router: connectRouter(history)
})

export type RootState = ReturnType<typeof rootReducer>


export default rootReducer