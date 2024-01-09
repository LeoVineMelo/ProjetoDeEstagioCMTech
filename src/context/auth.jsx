import React, { useState, createContext } from 'react'
import { useEffect } from 'react'
import { useNavigate } from 'react-router-dom/dist'
import api from '../services/api'
import { FC } from 'react'




const AuthContext = createContext({});

export const AuthProvider: React.FC = ({ children }) =>{

}

export default AuthContext;