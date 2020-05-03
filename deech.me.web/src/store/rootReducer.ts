import { combineReducers } from "redux"
import { AppReducer } from "./app/reducer"
import { BookReducer } from "./book/reducer"
import { TitleReducer } from "./title/reducer"

export default combineReducers({
    ...AppReducer,
    ...BookReducer,
    ...TitleReducer
})