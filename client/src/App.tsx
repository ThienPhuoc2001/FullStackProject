
import './App.css'
import {createBrowserRouter, type RouteObject, RouterProvider} from "react-router-dom";


const myRoutes: RouteObject[] = [
    {
        path: "/",
        element: <Home/>
    },
    
    {
        path: "/books",
        element: <div>This is the books page</div>
    },
    {
        path: "/authors",
        element: <div>This is the authors page</div>
    }
    ,
    {
        path: "/genres",
        element: <div>This is the genres page</div>
    }
    
]

export function Home () {
    return <div>This is the  Library homepage</div>
}

export default function App() {

    return <RouterProvider router={createBrowserRouter(myRoutes)}/>
    
}

