const initialState = {
  classRooms: [],
  contact: {}
};

export default function(state = initialState, action) {
  switch (action.type) {
    case "GET_CONTACTS":
      return { ...state, classRooms: action.payload };
    case "GET_CONTACT":
      return { ...state, contact: action.payload };
    case "DELETE_CONTACT":
      return {
        ...state,
        classRooms: state.classRooms.filter(
          contact => contact.id !== action.payload
        )
      };
    case "ADD_CONTACT":
      return { ...state, classRooms: [action.payload, ...state.classRooms] };
    case "UPDATE_CONTACT":
      return {
        ...state,
        classRooms: state.classRooms.map(contact =>
          contact.id === action.payload.id
            ? (contact = action.payload)
            : contact
        )
      };
    default:
      return state;
  }
}
