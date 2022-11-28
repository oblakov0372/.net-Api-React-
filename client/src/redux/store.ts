import { configureStore } from "@reduxjs/toolkit";
import pizza from "./book/slice";
import cart from "./cart/slice";
export const store = configureStore({
  reducer: {
    pizza,
    cart,
  },
});

export type RootState = ReturnType<typeof store.getState>;

export type AppDispatch = typeof store.dispatch;
