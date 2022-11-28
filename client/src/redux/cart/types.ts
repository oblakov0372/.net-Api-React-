export type CartItem = {
  id: number;
  url: string;
  title: string;
  author: string;
  price: number;
  count: number;
};
export interface CartSliceState {
  items: CartItem[];
  totalPrice: number;
  totalBooks: number;
}
