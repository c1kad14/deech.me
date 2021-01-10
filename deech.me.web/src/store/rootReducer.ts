
import { connectRouter } from "connected-react-router"
import { combineReducers } from "redux"
import AppReducer from "./app/reducer"
import BookReducer from "./book/reducer"
import CommentsReducer from "./comments/reducer"
import SettingsReducer from "./settings/reducer"
import TitleReducer from "./title/reducer"
import { createBrowserHistory } from "history"

const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href") as string
const history = createBrowserHistory({ basename: baseUrl })

const rootReducer = combineReducers({
    app: AppReducer.AppReducer,
    book: BookReducer.BookReducer,
    title: TitleReducer.TitleReducer,
    comments: CommentsReducer.CommentsReducer,
    settings: SettingsReducer.SettingsReducer,
    router: connectRouter(history)
})

export type RootState = ReturnType<typeof rootReducer>


export default rootReducer