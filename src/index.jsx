import './index.css'
import ReactDOM from 'react-dom'
import React from 'react'
import { RouterProvider } from 'react-router-dom'
import { router } from './routes'

ReactDOM.render(
    <React.StrictMode>
        <RouterProvider router={router} />
    </React.StrictMode>,
    document.getElementById('root')
)