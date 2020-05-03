import { createLogic, Action } from "redux-logic"
import Axios from "axios"
import { domain } from "../config"
import { TitleActionTypes, TitleTypes } from "./types"
import { setTitles } from "./actions"
import { AppActionTypes } from "../app/types"
import { setLoading, setLoaded } from "../app/actions"


type ActionExtractor<C> = Extract<TitleActionTypes, { type: C }>

type T_SEARCH = ActionExtractor<typeof TitleTypes.SEARCH_TITLES>["type"]
type P_SEARCH = ActionExtractor<typeof TitleTypes.SEARCH_TITLES>["payload"]

const titleSearch = createLogic<{}, { action: Action<T_SEARCH, P_SEARCH> }>({
    type: TitleTypes.SEARCH_TITLES,
    processOptions: {
        dispatchReturn: true
    },

    async process(
        { action }: { action: Action<T_SEARCH, P_SEARCH> },
        dispatch: (action: TitleActionTypes | AppActionTypes) => void,
        done: () => void, ) {
        const { title } = <P_SEARCH>action.payload

        const url = `${domain}/titleinfo/bytitle?title=${title}`

        dispatch(setLoading())

        const response = await Axios.get(url)
        const titlesSearchResults = await response.data

        console.log(titlesSearchResults)
        // dispatch(setTitles(titlesSearchResults))
        dispatch(setLoaded())
        done()
    }
})

export default [
    titleSearch
]