import { call, put, takeEvery } from "redux-saga/effects"
import Axios from "axios"
import { TitleTypes, TitleActionTypes } from "./title/types"
import { setTitles } from "./title/actions"
import { domain } from "./config"
import { setLoading, setLoaded } from "./app/actions"
import { SearchTitles } from "./title/types"

export function* sagaWatcher() {
    yield takeEvery(TitleTypes.SEARCH_TITLES, searchTitlesSaga)
}

export function* searchTitlesSaga(action: SearchTitles) {
    try {
        yield put(setLoading())
        const payload = yield call(loadTitles, action.payload.title)
        yield put(setTitles(payload))
        yield put(setLoaded())
    } catch (error) {
        console.log(error)
        yield put(setLoaded())
    }
}

async function loadTitles(title: string) {
    const url = `${domain}/titleinfo/bytitle?title=${title}`
    const response = await Axios.get(url)
    return await response.data
}