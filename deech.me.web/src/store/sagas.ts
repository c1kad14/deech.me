import { call, put, takeEvery } from "redux-saga/effects"
import Axios from "axios"
import { TitleTypes, SearchTitles } from "./title/types"
import { setTitles } from "./title/actions"
import { domain } from "./config"
import { setLoading, setLoaded } from "./app/actions"
import { BookTypes, SetBookId } from "./book/types"
import { setBook } from "./book/actions"
import { CommentTypes, AddComment, IComment, ShowComments } from "./comments/types"
import { commentAdded, showComments, setComments } from "./comments/actions"

export function* sagaWatcher() {
    yield takeEvery(TitleTypes.SEARCH_TITLES, searchTitlesSaga)
    yield takeEvery(BookTypes.SET_BOOK_ID, searchBookSaga)
    yield takeEvery(CommentTypes.COMMENT_ADD, addCommentSaga)
    yield takeEvery(CommentTypes.COMMENTS_SHOW, showCommentsSaga)
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

export function* searchBookSaga(action: SetBookId) {
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

export function* showCommentsSaga(action: ShowComments) {
    try {
        //yield put(setLoading())
        const payload = yield call(loadComments, action.payload.paragraphId)
        console.log(payload)
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
        const payload = yield call(addComment, action.payload.comment)
        console.log(payload)
        yield put(commentAdded(payload))
        // yield put(setLoaded())
    } catch (error) {
        console.log(error)
        yield put(setLoaded())
    }
}

async function addComment(comment: IComment) {
    const url = `${domain}/comments`
    const response = await Axios.post(url, comment)
    return await response.data
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

async function loadComments(paragraphId: number) {
    const url = `${domain}/comments/byparagraphid?paragraphid=${paragraphId}`
    const response = await Axios.get(url)
    return await response.data
}