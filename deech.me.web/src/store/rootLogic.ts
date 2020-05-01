import { BookLogic } from "./book";
import { TitleLogic } from "./title";
import { AppLogic } from "./app";

export default [
    ...AppLogic,
    ...BookLogic,
    ...TitleLogic
];