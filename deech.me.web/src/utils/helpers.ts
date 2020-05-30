import { domain } from "../config"

export const rawMarkupHelper = (value: string) => ({ __html: value.replace(/<img src="/, `<img src="${domain}/books/`) })
export const imgPathHelper = (value: string) => `${domain}/books/${value}`