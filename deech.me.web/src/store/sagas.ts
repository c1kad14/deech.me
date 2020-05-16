import { call, put, takeEvery, select, takeLatest } from "redux-saga/effects"
import Axios from "axios"
import { TitleTypes } from "./title/types"
import { setTitles, addTitles } from "./title/actions"
import { domain } from "./config"
import { setLoading, setLoaded } from "./app/actions"
import { BookTypes, SetBookId } from "./book/types"
import { setBook } from "./book/actions"
import { CommentTypes, AddComment, IComment, ShowComments } from "./comments/types"
import { commentAdded, setComments } from "./comments/actions"
import { RootState } from "./rootReducer"

export function* sagaWatcher() {
    yield takeLatest(TitleTypes.LOAD_TITLES, loadTitlesSaga)
    yield takeLatest(TitleTypes.LOAD_MORE_TITLES, loadMoreTitlesSaga)
    yield takeEvery(BookTypes.SET_BOOK_ID, loadBookSaga)
    yield takeEvery(CommentTypes.COMMENT_ADD, addCommentSaga)
    yield takeEvery(CommentTypes.COMMENTS_SHOW, showCommentsSaga)
}

const getTitleCount = ((state: RootState) => {
    return state.TitleReducer.titles.length
})

const getTitleFilter = ((state: RootState) => {
    return state.TitleReducer.filter
})

export function* loadTitlesSaga() {
    try {
        yield put(setLoading())

        const filter = yield select(getTitleFilter)
        let title = filter && filter.title

        if (!title) {
            title = ""
        }

        const payload = yield call(loadTitlesApiCall, title)

        yield put(setTitles(payload))
        yield put(setLoaded())
    } catch (error) {
        console.log(error)
        yield put(setLoaded())
    }
}

export function* loadMoreTitlesSaga() {
    try {
        yield put(setLoading())

        const filter = yield select(getTitleFilter)
        const skip = yield select(getTitleCount)
        let title = filter && filter.title

        if(!title) {
            title = ""
        }

        const payload = yield call(loadMoreTitlesApiCall, title, skip)

        yield put(addTitles(payload))
        yield put(setLoaded())
    } catch (error) {
        console.log(error)
        yield put(setLoaded())
    }
}

export function* loadBookSaga(action: SetBookId) {
    try {
        yield put(setLoading())
        const payload = yield call(loadBookApiCall, action.payload.id)
        yield put(setBook(payload))
        yield put(setLoaded())
    } catch (error) {
        console.log(error)
        yield put(setLoaded())
    }
}

export function* showCommentsSaga(action: ShowComments) {
    try {
        //yield put(setLoading())
        const payload = yield call(loadCommentsApiCall, action.payload.paragraphId)
        yield put(setComments(payload))
        //yield put(setLoaded())
    } catch (error) {
        console.log(error)
        yield put(setLoaded())
    }
}

export function* addCommentSaga(action: AddComment) {
    try {
        // yield put(setLoading())
        const payload = yield call(addCommentApiCall, action.payload.comment)
        yield put(commentAdded(payload))
        // yield put(setLoaded())
    } catch (error) {
        console.log(error)
        yield put(setLoaded())
    }
}

async function addCommentApiCall(comment: IComment) {
    const url = `${domain}/comments`
    const response = await Axios.post(url, comment)
    return await response.data
}

async function loadTitlesApiCall(title: string) {
    const url = `${domain}/titleinfo/bytitle?title=${title}`
    const response = await Axios.get(url)
    return await response.data
}

async function loadMoreTitlesApiCall(title: string, skip: number) {
    const url = `${domain}/titleinfo/bytitle?title=${title}&skip=${skip}`
    const response = await Axios.get(url)
    return await response.data
}

async function loadBookApiCall(id: string) {
    const url = `${domain}/book/bytitleid?titleid=${id}`
    const response = await Axios.get(url)
    return await response.data
}

async function loadCommentsApiCall(paragraphId: number) {
    const url = `${domain}/comments/byparagraphid?paragraphid=${paragraphId}`
    const response = await Axios.get(url)
    return await response.data
}