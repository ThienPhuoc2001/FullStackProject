
import './App.css'
import {createBrowserRouter, type RouteObject, RouterProvider} from "react-router-dom";
import {useEffect} from "react";
import {booksAtom, fetchBooksAtom} from "./atoms/bookClient.ts";
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
            <h2>Book List</h2>
            <ul>
                {books.map(book => (
                    <li key={book.id}>{book.title} - {book.pages} pages</li>
                ))}
            </ul>
        </div>
    );
}


const myRoutes: RouteObject[] = [
    {
        path: "/",
        element: <Home/>
    },
    {
        path: "/books",
        element: <BookList/>
    }
    
]



export function Home () {
    return <div>This is the  Library homepage</div>
}

export default function App() {

    return <RouterProvider router={createBrowserRouter(myRoutes)}/>
    
}

