import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  isLogged: false,
};

export const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    setIsLogged(state, action) {
      state.isLogged = action.payload;
    },
  },
});

export const { setIsLogged } = userSlice.actions;

export default userSlice.reducer;
