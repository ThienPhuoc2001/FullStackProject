
import { AuthorClient, BookClient, GenreClient } from "./models/generated-client.ts";


const prod = "https://client-empty-cherry-1234.fly.dev";
const dev = "http://localhost:5067";

const finalUrl = import.meta.env.PROD ? prod : dev;
export const bookClient = new BookClient(finalUrl)
export const authorClient = new AuthorClient(finalUrl)
export const genreClient = new GenreClient(finalUrl)
