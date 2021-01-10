import { DecreaseText, IncreaseText, SettingsTypes } from "./types";

export function increaseText(): IncreaseText {
    return {
        type: SettingsTypes.INCREASE_TEXT
    }
}

export function decreaseText(): DecreaseText {
    return {
        type: SettingsTypes.DECREASE_TEXT
    }
}