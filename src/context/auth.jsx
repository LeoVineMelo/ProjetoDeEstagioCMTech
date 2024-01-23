import React from "react";
import { useState } from "react";
import { createContext } from "react";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { Token } from "@mui/icons-material";

export const AuthContext = createContext()

export const AuthProvider = ({ children }) => {

    const navigate = useNavigate()

    const [usuario, setUsuario] = useState(null)

    const [loadingRoute, setLoadingRoute] = useState(true);

    useEffect(() => {
        const recoveredUsuario = localStorage.getItem("usuario")
        if (recoveredUsuario)
            setUsuario(JSON.parse(recoveredUsuario))

        setLoadingRoute(false)
    }, [])

    const login = (user, token) =>{

        const loggedUsuario = {
            id: user.id,
            nome: user.nome,
            email: user.email,
            perfil: user.perfil
        }
        localStorage.setItem("usuario", JSON.stringify(loggedUsuario));
        localStorage.setItem("accesstoken",token)
        setUsuario(loggedUsuario)
        navigate("/home")
    }

    const logout = () => {
        localStorage.removeItem("usuario")
        localStorage.removeItem("accesstoken")
        setUsuario(null)
        navigate("/")
    }


    return (
        <AuthContext.Provider value={{ authenticated: !!usuario, usuario, loadingRoute, login, logout}}>
            {children}
        </AuthContext.Provider>
    )
}