export type Book = {
  id: number;
  url: string;
  title: string;
  author: string;
  price: number;
};
export interface BookSliceState {
  items: Book[];
}
