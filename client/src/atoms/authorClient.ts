import {atom} from 'jotai';
import {authorClient} from "../baseUrl.ts";
import {type AuthorDto} from "../models/generated-client.ts";

export const authorsAtom = atom<AuthorDto[]>([]);
export const fetchAuthorsAtom = atom(
    null,
    async (_get, set) => {
        try {
            const authors = await authorClient.getAuthor();
            set(authorsAtom, authors);
        } catch (error) {
            console.error("Failed to fetch authors:", error);
        }
    }
);
