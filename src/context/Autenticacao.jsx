import React, { Children } from "react";
import { useState } from "react";
import { createContext } from "react";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { AuthProvider } from "./auth";
import { Token } from "@mui/icons-material";

export const AuthContext = createContext()

export const AuthProvider = ({ Children }) => {

    const navigate = useNavigate()

    const [usuario, setUsuario] = useState(null)

    const [loadingRoute, setLoadingRoute] = useState(true);

    useEffect(() => {
        const recoveredUsuario = localStorage.getItem("usuario")
        if (recoveredUsuario)
            setUsuario(JSON.parse(recoveredUsuario))

        setLoadingRoute(false)
    }, [])

    const login = () =>{

        const loggedUsuario = {
            id: usuario.id,
            nome: usuario.nome,
            email: usuario.email,
            perfil: usuario.perfil
        }
        localStorage.setItem("usuario", JSON.stringify(loggedUsuario));
        localStorage.setItem("accesstoken",Token)
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
        {Children}
    </AuthContext.Provider>
)
}