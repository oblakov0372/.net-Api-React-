import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { Book, BookSliceState } from "./types";

const initialState: BookSliceState = {
  items: [],
};

export const bookSlice = createSlice({
  name: "book",
  initialState,
  reducers: {
    setItems(state, action: PayloadAction<Book[]>) {
      state.items = action.payload;
    },
  },
});

export const { setItems } = bookSlice.actions;

export default bookSlice.reducer;
