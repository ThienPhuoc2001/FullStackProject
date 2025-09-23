
import { AuthorClient, BookClient, GenreClient } from "./models/generated-client.ts";


const prod = "https://server-wild-sea-9606.fly.dev";
const dev = "http://localhost:5067";

const finalUrl = import.meta.env.PROD ? prod : dev;
export const bookClient = new BookClient(finalUrl)
export const authorClient = new AuthorClient(finalUrl)
export const genreClient = new GenreClient(finalUrl)
