import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  isLogged: localStorage.getItem("jwtToken") ? true : false,
};

export const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    setIsLoggedStatus(state, action) {
      state.isLogged = action.payload;
      if (!action.payload) {
        localStorage.removeItem("jwtToken");
        location.reload();
      }
    },
  },
});

export const { setIsLoggedStatus } = userSlice.actions;

export default userSlice.reducer;
