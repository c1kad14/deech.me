import { call, put, takeEvery } from "redux-saga/effects"
import Axios from "axios"
import { TitleTypes, SearchTitles } from "./title/types"
import { setTitles } from "./title/actions"
import { domain } from "./config"
import { setLoading, setLoaded } from "./app/actions"
import { BookTypes, SetBookId } from "./book/types"
import { setBook } from "./book/actions"

export function* sagaWatcher() {
    yield takeEvery(TitleTypes.SEARCH_TITLES, searchTitlesSaga)
    yield takeEvery(BookTypes.SET_BOOK_ID, searchBook)
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

export function* searchBook(action: SetBookId) {
    try {
        yield put(setLoading())
        const payload = yield call(loadBook, action.payload.id)
        console.log(payload)
        yield put(setBook(payload))
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

async function loadBook(id: string) {
    const url = `${domain}/book/bytitleid?titleid=${id}`
    const response = await Axios.get(url)
    return await response.data
}