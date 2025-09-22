import {atom} from 'jotai';
import {BookClient, type BookDto } from "../models/generated-client.ts";


const bookClient = new BookClient('http://localhost:5173');
export const booksAtom = atom<BookDto[]>([]);
export const fetchBooksAtom = atom(
    null,
    async (_get, set) => {
      try {
          const books = await bookClient.getBooks();
            set(booksAtom, books);
        } catch (error) {
            console.error("Failed to fetch books:", error);
      }
    }
);