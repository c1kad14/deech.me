import { ITitleFilter, ITitleInfo, TitleTypes, SetFilter, ResetFilter, SetTitles, ClearTitles, SearchTitles } from "./types"

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

export function searchTitles(title: string): SearchTitles {
    return {
        type: TitleTypes.SEARCH_TITLES,
        payload: {
            title
        }
    }
}