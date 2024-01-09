import './index.css'
import ReactDOM from 'react-dom'
import React from 'react'
import { RouterProvider } from 'react-router-dom'
import { router } from './routes'
import AuthContext from './context/auth'

ReactDOM.render(
    <AuthContext.Provider value={{signed: true}}>
    <React.StrictMode>
        <RouterProvider router={router} />
    </React.StrictMode>,
    </AuthContext.Provider>,
    document.getElementById('root')
)