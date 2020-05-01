import { createLogic } from "redux-logic";
import Axios from "axios";
import { domain } from "../config";
import titleConstants from "./constants";
import { TitleInfo } from "./types";

const titleSearch = createLogic({
    type: titleConstants.SET_SEARCH_FILTER,
    processOptions: {
        dispatchReturn: true
    },

    async process({ action }, dispatch, done) {
         const title = action.payload as SearchFilter;
        const url = `${domain}/titleinfo/byTitle?title${title}`;

        dispatch(appActions.setAppState(appConstants.LOADING));

        const response = await Axios.get(url);
        const titlesSearchResults = await response.data;

        dispatch(titleActions.setSearchResult(titlesSearchResults as TitleInfo []));
        dispatch(appActions.setAppState(appConstants.SEARCHING));
        done();
    }
});

export default [
    titleSearch
];