import axios from "axios";


export const getClassRooms = () => async dispatch => {
  const response = await axios.get(
    "https://localhost:7129/api/Classrooms/GetClassRooms"
  );
  dispatch({
    type: "GET_CLASSROOMS",
    payload: response.data
  });
};

export const getClassRoom = id => async dispatch => {
  const response = await axios.get(
    `https://localhost:7129/api/Classrooms/${id}/GetClassRoom`
  );
  dispatch({
    type: "GET_CLASSROOM",
    payload: response.data
  });
};

export const deleteClassRoom = id => async dispatch => {
  await axios.delete(`https://localhost:7129/api/Classrooms/${id}/DeleteClassRoom`);
  dispatch({
    type: "DELETE_CLASSROOM",
    payload: id
  });
};

export const addClassRoom = classroom => async dispatch => {
  const response = await axios.post(
    "https://localhost:7129/api/Classrooms/PostClassRoom",
    classroom
  );
  dispatch({
    type: "ADD_CLASSROOM",
    payload: response.data
  });
};

export const updateClassRoom = classroom => async dispatch => {
  const response = await axios.put(

    `https://localhost:7129/api/Classrooms/${classroom.id}/PutClassRoom`,
    classroom
  );
  dispatch({
    type: "UPDATE_CLASSROOM",
    payload: response.data
  });
};
