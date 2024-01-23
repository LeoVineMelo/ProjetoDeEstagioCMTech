import './index.css'
import ReactDOM from 'react-dom/client'
import React from 'react'
import AppRoutes from './routes'
import Login from './pages/Login'

ReactDOM.createRoot(document.getElementById('root')).render(
    <React.StrictMode>
      <AppRoutes />
    </React.StrictMode>
  )
  