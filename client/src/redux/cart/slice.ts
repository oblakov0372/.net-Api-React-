import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { CartItem, CartSliceState } from "./types";
import axios from "axios";
const initialState: CartSliceState = {
  items: [],
  totalPrice: 0,
  totalBooks: 0,
};

export const cartSlice = createSlice({
  name: "cart",
  initialState,
  reducers: {
    setItems(state, action: PayloadAction<CartItem[]>) {
      state.items = action.payload;
      state.totalPrice = state.items.reduce(
        (sum, obj) => sum + obj.price * obj.count,
        0
      );
      state.totalBooks = state.items.reduce((sum, obj) => sum + obj.count, 0);
    },
    plusCount(state, action) {
      axios.post(
        `https://localhost:7040/api/books/addBookToCart?bookId=${action.payload.id}`
      );
      var item = state.items.find((item) => item.id === action.payload.id);
      if (item !== undefined) {
        item.count += 1;
        state.totalPrice += item.price;
      } else {
        state.items.push(...state.items, action.payload);
        state.totalPrice += action.payload.price;
      }
      state.totalBooks += 1;
    },
    minusCount(state, action) {
      axios.delete(
        `https://localhost:7040/api/Books/RemoveBookFromCart${action.payload}`
      );
      var item = state.items.find((item) => item.id === action.payload);
      if (item !== undefined) {
        item.count -= 1;
        state.totalPrice -= item.price;
        state.totalBooks -= 1;

        if (item.count < 1) {
          state.items = state.items.filter(
            (item) => item.id !== action.payload
          );
        }
      }
    },
    clearRow(state, action) {
      axios.delete(
        `https://localhost:7040/api/Books/ClearRowInCart${action.payload}`
      );
      state.items = state.items.filter((item) => item.id !== action.payload);
      state.totalPrice = state.items.reduce(
        (sum, obj) => sum + obj.price * obj.count,
        0
      );
      state.totalBooks = state.items.reduce((sum, obj) => sum + obj.count, 0);
    },
    clearCart(state) {
      axios.delete(`https://localhost:7040/api/Books/ClearCart`);
      state.items = initialState.items;
      state.totalBooks = initialState.totalBooks;
      state.totalPrice = initialState.totalPrice;
    },
  },
});

export const { setItems, plusCount, minusCount, clearRow, clearCart } =
  cartSlice.actions;

export default cartSlice.reducer;
