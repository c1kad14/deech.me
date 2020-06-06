import { call, put, takeEvery, select, takeLatest } from "redux-saga/effects"
import Axios from "axios"
import { TitleTypes } from "./title/types"
import { setTitles, addTitles } from "./title/actions"
import { domain } from "../config"
import { setLoading, setLoaded } from "./app/actions"
import { BookTypes, GetBook, AddBookmark, AddCitation, AddNote, DeleteNote, DeleteCitation, IBookmark, ICitation, INote, IParagraph, DeleteBookmark } from "./book/types"
import { setBook, bookmarkAdded, citationAdded, noteAdded, noteDeleted, citationDeleted, bookmarkDeleted } from "./book/actions"
import { CommentTypes, AddComment, IComment, ShowComments } from "./comments/types"
import { commentAdded, setComments } from "./comments/actions"
import { RootState } from "./rootReducer"

export function* sagaWatcher() {
    yield takeLatest(TitleTypes.LOAD_TITLES, loadTitlesSaga)
    yield takeLatest(TitleTypes.LOAD_MORE_TITLES, loadMoreTitlesSaga)
    yield takeEvery(BookTypes.GET_BOOK, loadBookSaga)
    yield takeEvery(CommentTypes.COMMENT_ADD, addCommentSaga)
    yield takeEvery(CommentTypes.COMMENTS_SHOW, showCommentsSaga)

    yield takeEvery(BookTypes.ADD_BOOKMARK, addBookmarkSaga)
    yield takeEvery(BookTypes.ADD_CITATION, addCitationSaga)
    yield takeEvery(BookTypes.ADD_NOTE, addNoteSaga)
    yield takeEvery(BookTypes.DELETE_BOOKMARK, deleteBookmarkSaga)
    yield takeEvery(BookTypes.DELETE_CITATION, deleteCitationSaga)
    yield takeEvery(BookTypes.DELETE_NOTE, deleteNoteSaga)
}

const getAccessToken = ((state: RootState) => {
    return state.app.access_token
})

const getTitleCount = ((state: RootState) => {
    return state.title.titles.length
})

const getTitleFilter = ((state: RootState) => {
    return state.title.filter
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

        if (!title) {
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

export function* loadBookSaga(action: GetBook) {
    const accessToken = yield select(getAccessToken)
    Axios.defaults.headers['authorization'] = `Bearer ${accessToken}`
    try {
        yield put(setLoading())
        const payload = yield call(loadBookApiCall, action.payload.id)
        console.log(payload)
        payload.paragraphs = payload.paragraphs.sort((a: IParagraph, b: IParagraph) => a.sequence - b.sequence)
        yield put(setBook(payload))
        yield put(setLoaded())
    } catch (error) {
        console.log(error)
        yield put(setLoaded())
    }
}

export function* showCommentsSaga(action: ShowComments) {
    try {
        const payload = yield call(loadCommentsApiCall, action.payload.paragraphId)
        yield put(setComments(payload))
    } catch (error) {
        console.log(error)
    }
}

export function* addCommentSaga(action: AddComment) {
    try {
        const accessToken = yield select(getAccessToken)
        Axios.defaults.headers['authorization'] = `Bearer ${accessToken}`
        const payload = yield call(addCommentApiCall, action.payload.comment)
        yield put(commentAdded(payload))
    } catch (error) {
        console.log(error)
    }
}

export function* addBookmarkSaga(action: AddBookmark) {
    try {
        const accessToken = yield select(getAccessToken)
        Axios.defaults.headers['authorization'] = `Bearer ${accessToken}`
        const payload = yield call(addBookmarkApiCall, action.payload.bookmark)
        yield put(bookmarkAdded(payload))
    } catch (error) {
        console.log(error)
    }
}

export function* addCitationSaga(action: AddCitation) {
    try {
        const accessToken = yield select(getAccessToken)
        Axios.defaults.headers['authorization'] = `Bearer ${accessToken}`
        const payload = yield call(addCitationApiCall, action.payload.citation)
        yield put(citationAdded(payload))
    } catch (error) {
        console.log(error)
    }
}

export function* addNoteSaga(action: AddNote) {
    try {
        const accessToken = yield select(getAccessToken)
        Axios.defaults.headers['authorization'] = `Bearer ${accessToken}`
        const payload = yield call(addNoteApiCall, action.payload.note)
        yield put(noteAdded(payload))
    } catch (error) {
        console.log(error)
    }
}

export function* deleteBookmarkSaga(action: DeleteBookmark) {
    try {
        const accessToken = yield select(getAccessToken)
        Axios.defaults.headers['authorization'] = `Bearer ${accessToken}`
        const payload = yield call(deleteBookmarkApiCall, action.payload.bookmark)
        yield put(bookmarkDeleted(payload))
    } catch (error) {
        console.log(error)
    }
}

export function* deleteCitationSaga(action: DeleteCitation) {
    try {
        const accessToken = yield select(getAccessToken)
        Axios.defaults.headers['authorization'] = `Bearer ${accessToken}`
        const payload = yield call(deleteCitationApiCall, action.payload.citation)
        yield put(citationDeleted(payload))
    } catch (error) {
        console.log(error)
    }
}

export function* deleteNoteSaga(action: DeleteNote) {
    try {
        const accessToken = yield select(getAccessToken)
        Axios.defaults.headers['authorization'] = `Bearer ${accessToken}`
        const payload = yield call(deleteNoteApiCall, action.payload.note)
        yield put(noteDeleted(payload))
    } catch (error) {
        console.log(error)
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

async function loadBookApiCall(id: number) {
    const url = `${domain}/book?id=${id}`
    const response = await Axios.get(url)
    return await response.data
}

async function loadCommentsApiCall(paragraphId: number) {
    const url = `${domain}/comments/byparagraphid?paragraphid=${paragraphId}`
    const response = await Axios.get(url)
    return await response.data
}

async function addBookmarkApiCall(bookmark: IBookmark) {
    const url = `${domain}/bookmark/`
    const response = await Axios.post(url, bookmark)
    return await response.data
}

async function addCitationApiCall(citation: ICitation) {
    const url = `${domain}/citation/`
    const response = await Axios.post(url, citation)
    return await response.data
}

async function addNoteApiCall(note: INote) {
    const url = `${domain}/note/`
    const response = await Axios.post(url, note)
    return await response.data
}

async function deleteBookmarkApiCall(bookmark: IBookmark) {
    const url = `${domain}/bookmark/`
    const response = await Axios.delete(url, { data: bookmark })
    return await response.data
}

async function deleteCitationApiCall(citation: ICitation) {
    const url = `${domain}/citation/`
    const response = await Axios.delete(url, { data: citation })
    return await response.data
}

async function deleteNoteApiCall(note: INote) {
    const url = `${domain}/note/`
    const response = await Axios.delete(url, { data: note })
    return await response.data
}