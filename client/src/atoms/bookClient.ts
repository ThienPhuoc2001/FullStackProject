import { atom } from 'jotai';
import { bookClient}   from "../baseUrl.ts";
import { type BookDto } from '../models/generated-client';

export const booksAtom = atom<BookDto[]>([]);
export const booksIsLoadingAtom = atom(true);

export const fetchBooksAtom = atom(
  null,
  async (_get, set) => {
    set(booksIsLoadingAtom, true);
    try {
      const books = await bookClient.getBooks();
      set(booksAtom, books);
    } catch (e) {
      console.error("Failed to fetch books:", e);
      set(booksAtom, []);
    } finally {
      set(booksIsLoadingAtom, false);
    }
  }
);
