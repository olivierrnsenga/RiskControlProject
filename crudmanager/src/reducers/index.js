import { combineReducers } from "redux";
import crudtReducer from "./crudReducer";

export default combineReducers({
  contact: crudtReducer
});
