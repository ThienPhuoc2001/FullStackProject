
import './App.css'
import {createBrowserRouter, type RouteObject, RouterProvider, useNavigate} from "react-router-dom";

import {useEffect} from "react";

import {booksAtom, fetchBooksAtom} from "./atoms/bookClient.ts";
import {genresAtom, fetchGenresAtom} from "./atoms/genreClient.ts";
import {authorsAtom, fetchAuthorsAtom} from "./atoms/authorClient.ts";

import {useAtom} from "jotai";

function BookList() {
    
    const [books, ] = useAtom(booksAtom);
    const [, fetchBooks] = useAtom(fetchBooksAtom);
    
    useEffect(() => {
        fetchBooks();
    }, [fetchBooks]);
    if (books.length === 0) {
        return <div>Loading books...</div>;
    }
    return (
        <div>
            <h2 className={"text-primary"}>Book List</h2>
            <ul>
                {books.map(book => (
                    <li key={book.id}>{book.title} - {book.pages} pages</li>
                ))}
            </ul>
        </div>
    );
}


function GenreList(){
    const [genres, ] = useAtom(genresAtom);
    const [, fetchGenres] = useAtom(fetchGenresAtom);
    
    useEffect(() => {
        fetchGenres();
    }, [fetchGenres]);
    if (genres.length === 0) {
        return <div>Loading genres...</div>;
    }
    return (
        <div>
            <h2>Genre List</h2>
            <ul>
                {genres.map(genre => (
                    <li key={genre.id}>{genre.name}</li>
                ))}
            </ul>
        </div>
    )

    
}


function AuthorList(){
    const [authors, ] = useAtom(authorsAtom);
    const [, fetchAuthors] = useAtom(fetchAuthorsAtom);
    
    useEffect(() => {
        fetchAuthors();
    }, [fetchAuthors]);
    if (authors.length === 0) {
        return <div>Loading authors...</div>;
    }
    return (
        <div>
            <h2>Author List</h2>
            <ul>
                {authors.map(author => (
                    <li key={author.id}>{author.name}</li>
                ))}
            </ul>
        </div>
    )
    
}




export function Home () {
    const navigate = useNavigate();
    return (
    <div className="home-container">
        <button onClick={() => {navigate('/authors')}}>Go to Authors </button>
        <button onClick={() => {navigate('/books')}}>Go to Books </button>
        <button onClick={() => {navigate('/genres')}}>Go to Genres </button>
    </div>
    )
    
}


const myRoutes: RouteObject[] = [
    {
        path: "/",
        element: <Home/>
        
    },
    {
        path: "/books",
        element: <BookList/>
    },
    {
        path: "/genres",
        element: <GenreList/>
    },
    {
        path: "/authors",
        element: <AuthorList/>
    }
    
    
]




export default function App() {
    return <RouterProvider router={createBrowserRouter(myRoutes)}/>
}

