import { Action } from "redux"

export enum SettingsTypes {
    INCREASE_TEXT = "@@settings/INCREASE_TEXT",
    DECREASE_TEXT = "@@settings/DECREASE_TEXT"
}

export interface ITextSettingsState {
    readonly size: number
}

export interface IncreaseText extends Action {
    type: SettingsTypes.INCREASE_TEXT
}

export interface DecreaseText extends Action {
    type: SettingsTypes.DECREASE_TEXT
}