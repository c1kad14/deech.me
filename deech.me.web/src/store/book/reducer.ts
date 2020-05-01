// import BookConstants from "./constants";
// import produce from "immer";
// import {BookTypes, Session} from "./types";

// export default function AuthReducer(state = new Session(), action: BookTypes): Session {
//     return produce(state, draft => {
//         switch (action.type) {
//             case BookConstants.SET_BOOK:
//                 draft.name = action.payload.name;
//                 draft.updated = new Date();
//                 break;
//             case BookConstants.SET_SESSION:
//                 draft.session = action.payload.session;
//                 draft.updated = new Date();
//                 break;
//             case BookConstants.GET_SESSION:
//                 draft.updated = new Date();
//                 break;
//             case BookConstants.SET_ERROR:
//                 draft.error = action.payload.error;
//                 draft.updated = new Date();
//                 break;
//             default:
//                 return state;
//         }
//     });
// }