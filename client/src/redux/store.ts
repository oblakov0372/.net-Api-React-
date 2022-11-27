import { configureStore } from "@reduxjs/toolkit";
import pizza from "./book/slice";
export const store = configureStore({
  reducer: {
    pizza,
  },
});

export type RootState = ReturnType<typeof store.getState>;

export type AppDispatch = typeof store.dispatch;
