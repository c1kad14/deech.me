import { createLogic, Action } from "redux-logic"
import Axios from "axios"
import { domain } from "../config"
import { TitleInfo, TitleActionTypes, TitleActionType } from "./types"
import { loading, loaded } from "../app/actions"
import { setTitles } from "./actions"


type ActionExtractor<C> = Extract<TitleActionType, { type: C }>;

type T_SEARCH = ActionExtractor<typeof TitleActionTypes.SEARCH_TITLES>['type'];
type P_SEARCH = ActionExtractor<typeof TitleActionTypes.SEARCH_TITLES>['payload'];

const titleSearch = createLogic<{}, { action: Action<T_SEARCH, P_SEARCH> }>({
    type: TitleActionTypes.SEARCH_TITLES,
    processOptions: {
        dispatchReturn: true
    },

    async process(
        { action }: { action: Action<T_SEARCH, P_SEARCH> },
        dispatch: (searchAction: TitleActionType) => void,
        done: () => void, ) {
        const { filter } = <P_SEARCH>action.payload;
        const url = `${domain}/titleinfo/byTitle?title${filter.title}`;

        // dispatch(loading());

        const response = await Axios.get(url);
        const titlesSearchResults = await response.data as TitleInfo[];

        dispatch(setTitles(titlesSearchResults));
        // dispatch(loaded());
        done();
    }
});

export default [
    titleSearch
];