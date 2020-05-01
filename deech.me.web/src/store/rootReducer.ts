import { combineReducers } from "redux";
import { BookReducer } from "./book";
import { AppReducer } from "./app";
import { TitleReducer } from "./title";

export default combineReducers({
    ...AppReducer,
    ...BookReducer,
    ...TitleReducer
})