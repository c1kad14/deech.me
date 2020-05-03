import { createLogic, Action } from "redux-logic"
import Axios from "axios"
import { domain } from "../config"
import { AppActionTypes } from "../app/types"
import { setLoading, setLoaded } from "../app/actions"
import { BookActionTypes, BookTypes } from "./types"
import { setBook } from "./actions"


type ActionExtractor<C> = Extract<BookActionTypes, { type: C }>

type T_BOOK = ActionExtractor<typeof BookTypes.SET_BOOK_ID>["type"]
type P_BOOk = ActionExtractor<typeof BookTypes.SET_BOOK_ID>["payload"]

const titleSearch = createLogic<{}, { action: Action<T_BOOK, P_BOOk> }>({
    type: BookTypes.SET_BOOK_ID,
    processOptions: {
        dispatchReturn: true
    },

    async process(
        { action }: { action: Action<T_BOOK, P_BOOk> },
        dispatch: (action: BookActionTypes | AppActionTypes) => void,
        done: () => void, ) {
        const { id } = <P_BOOk>action.payload
        const url = `${domain}/book/byId?id${id}`

        dispatch(setLoading())

        const response = await Axios.get(url)
        const booksSearchResults = await response.data

        dispatch(setBook(booksSearchResults))
        dispatch(setLoaded())
        done()
    }
})

export default [
    titleSearch
]