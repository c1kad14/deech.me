import { ITitleFilter, ITitleInfo, TitleTypes, SetFilter, ResetFilter, SetTitles, ClearTitles, AddTitles, LoadTitles, LoadMoreTitles } from "./types"

export function setFilter(filter: ITitleFilter): SetFilter {
    return {
        type: TitleTypes.SET_FILTER,
        payload: {
            filter
        }
    }
}

export function resetFilter(): ResetFilter {
    return {
        type: TitleTypes.RESET_FILTER
    }
}

export function setTitles(titles: ITitleInfo[]): SetTitles {
    return {
        type: TitleTypes.SET_TITLES,
        payload: {
            titles
        }
    }
}

export function clearTitles(): ClearTitles {
    return {
        type: TitleTypes.CLEAR_TITLES
    }
}

export function loadTitles(): LoadTitles {
    return {
        type: TitleTypes.LOAD_TITLES
    }
}

export function loadMoreTitles(): LoadMoreTitles {
    return {
        type: TitleTypes.LOAD_MORE_TITLES
    }
}

export function addTitles(titles: ITitleInfo[]): AddTitles {
    return {
        type: TitleTypes.ADD_TITLES,
        payload: {
            titles
        }
    }
}