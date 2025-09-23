import {atom} from 'jotai';
import {type GenreDto} from "../models/generated-client.ts";
import {genreClient} from "../baseUrl.ts";

export const genresAtom = atom<GenreDto[]>([]);
export const fetchGenresAtom = atom(
    null,
    async (_get, set) => {
        try {
            const genres = await genreClient.getGenres();
            set(genresAtom, genres);
        } catch (error) {
            console.error("Failed to fetch genres:", error);
        }
    }
);
